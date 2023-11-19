using System.ComponentModel.DataAnnotations;

namespace FootballManager.Entities;

public class NationalTeamEntity
{
    [Key]
    public int Id { get; set; }
    public string Country { get; set; } = null!;
}
