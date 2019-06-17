using System;
using System.Linq;
using System.Reflection;
using Customer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Data
{
    public static class Extensions
    {
        /// <summary>
        ///     Auto initialize or update currently date time for any class based on class ModelBase
        /// </summary>
        public static void AddAuditInfo(this DbContext dbContext)
        {
            var entries = dbContext.ChangeTracker.Entries().Where(e =>
                e.Entity is ModelBase && (e.State is EntityState.Added || e.State is EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.State is EntityState.Added) ((ModelBase)entry.Entity).CreatedAt = DateTime.UtcNow;
                ((ModelBase)entry.Entity).UpdatedAt = DateTime.UtcNow;
            }
        }

        /// <summary>
        ///     Auto find and apply all IEntityTypeConfiguration to modelBuilder
        /// </summary>
        public static void ApplyAllConfigurations<TDbContext>(this ModelBuilder modelBuilder)
            where TDbContext : DbContext
        {
            var applyConfigurationMethodInfo = modelBuilder
                .GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .First(m => m.Name.Equals("ApplyConfiguration", StringComparison.OrdinalIgnoreCase));

            var ret = typeof(TDbContext).Assembly
                .GetTypes()
                .Select(t => (t,
                    i: t.GetInterfaces().FirstOrDefault(i =>
                        i.Name.Equals(typeof(IEntityTypeConfiguration<>).Name, StringComparison.Ordinal))))
                .Where(it => it.i != null)
                .Select(it => (et: it.i.GetGenericArguments()[0], cfgObj: Activator.CreateInstance(it.t)))
                .Select(it =>
                    applyConfigurationMethodInfo.MakeGenericMethod(it.et).Invoke(modelBuilder, new[] { it.cfgObj }))
                .ToList();
        }
    }
}