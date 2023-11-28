using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Customers_crud.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("customer ID")]
        public string Tz { get; set; } = null!;
        [Required]
        [DisplayName("Full name")]
        public string FullName { get; set; } = null!;

        [DisplayName("E-mail")]
        public string? Email { get; set; }
        [Required]
        [DisplayName("Date of birth")]
        public DateTime BirthDate { get; set; }

        public string? Gender { get; set; }

        public string? Phone { get; set; }
    }
}
