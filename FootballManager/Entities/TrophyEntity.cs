using System.ComponentModel.DataAnnotations;

namespace FootballManager.Entities;

public class TrophyEntity
{
    [Key]
    public int Id { get; set; }
    public string TrophyName { get; set; } = null!;
    public string Year { get; set; } = null!;
    public int ClubId { get; set; }
}
