using System;

namespace Customer.Domain.Models
{
    public class Customer : ModelBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(string name, string email, string address, int age, string phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Address = address;
            Age = age;
            PhoneNumber = phoneNumber;
        }
    }
}