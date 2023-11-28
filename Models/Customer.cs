using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers_crud.Models;

public partial class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Tz { get; set; } = null!;
    [Required]
    public string FullName { get; set; } = null!;

    public string? Email { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }
}
