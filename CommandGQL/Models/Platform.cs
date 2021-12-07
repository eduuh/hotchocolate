using System.ComponentModel.DataAnnotations;

namespace CommandGQL.Models;

public class Platform
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string LicenseKey { get; set; } = string.Empty;
}
