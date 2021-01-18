using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class UserRegistration
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="First Name")]
        [Required(ErrorMessage ="First name is required.")]
        [StringLength(100, ErrorMessage = "Maximum length should be 100 characters")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        [Required(ErrorMessage ="Last name is required.")]
        [StringLength(100, ErrorMessage = "Maximum length should be 100 characters")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}