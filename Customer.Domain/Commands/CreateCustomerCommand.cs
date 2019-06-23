using System.ComponentModel.DataAnnotations;
using Customer.Domain.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Customer.Domain.Commands
{
    public class CreateCustomerCommand : CommandBase<CustomerDto>
    {
        public CreateCustomerCommand()
        {
        }

        [JsonConstructor]
        public CreateCustomerCommand(string name, string email, string address, int age, string phoneNumber)
        {
            Name = name;
            Email = email;
            Address = address;
            Age = age;
            PhoneNumber = phoneNumber;
        }

        [JsonProperty("name")]
        [Required]
        [MaxLength(255)]
        public string Name { get; }
        [JsonProperty("email")]
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; }
        [JsonProperty("address")]
        [Required]
        [MaxLength(255)]
        public string Address { get; }
        [JsonProperty("age")]
        [Required]
        public int Age { get; }
        [JsonProperty("phone_number")]
        [Required]
        [Phone]
        public string PhoneNumber { get; }
    }
}