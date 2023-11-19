using System.ComponentModel.DataAnnotations;

namespace FootballManager.Entities;

public class ClubEntity
{
    [Key]
    public int Id { get; set; } 
    public string ClubName { get; set; } = null!;
    public string FoundedYear { get; set; } = null!;
}
