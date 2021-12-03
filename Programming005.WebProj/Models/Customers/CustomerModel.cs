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
        [Required]
        public string Email { get; set; }
    }
}
