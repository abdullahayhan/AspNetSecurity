using System.ComponentModel.DataAnnotations.Schema;

namespace DataProtection.Security.Models;

public partial class Product
{
    [NotMapped]
    public string? EncrypedId { get; set; }
}
