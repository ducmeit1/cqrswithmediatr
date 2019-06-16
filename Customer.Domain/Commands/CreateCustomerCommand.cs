using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Customer.Domain.Commands
{
    public class CreateCustomerCommand : CommandBase
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
        public string Name { get; set; }
        [JsonProperty("email")]
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        [JsonProperty("address")]
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }
        [JsonProperty("age")]
        [Required]
        public int Age { get; set; }
        [JsonProperty("phone_number")]
        [Required]
        [RegularExpression(@"^[\d-]{10, 20}$")]
        public string PhoneNumber { get; set; }
    }
}