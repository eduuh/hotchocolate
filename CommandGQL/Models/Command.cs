using System.ComponentModel.DataAnnotations;

namespace CommandGQL.Models;

public class Command
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string HowTo { get; set; }
    [Required]
    public string CommandLine { get; set; }

    [Required]
    public int platformId { get; set; }

    public Platform Platform { get; set; }
}
