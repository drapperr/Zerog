namespace Zerog.Web.ViewModels.Addresses
{
    using System.ComponentModel.DataAnnotations;

    public class AddressInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Addreess { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        public string ZipCode { get; set; }

        [Required]
        [RegularExpression(@"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$")]
        public string PhoneNumber { get; set; }
    }
}
