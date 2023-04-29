using System.ComponentModel.DataAnnotations;

public class Platform
{
    [Key] // Primary Key
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Publisher { get; set; } = string.Empty;

    [Required]
    public string Cost { get; set; } = string.Empty;
}