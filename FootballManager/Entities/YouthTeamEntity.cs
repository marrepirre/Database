using System.ComponentModel.DataAnnotations;

namespace FootballManager.Entities;

public class YouthTeamEntity
{
    [Key]
    public int Id { get; set; }
    public string TeamName { get; set; } = null!;
    public int ClubId { get; set; }
}
