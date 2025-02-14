using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Locadora.Models;

public class Game{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public int LimitAge { get; set; }
    [Required]
    public DateTime ReleaseDate { get; set; }
}   