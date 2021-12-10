using System.ComponentModel.DataAnnotations;

namespace Programming005.WebProj.Models.Customers
{
    public class CustomerModel
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required for registration")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Range(18, 100, ErrorMessage = "Your age should be at least 18")]
        public int Age { get; set; }
    }
}
