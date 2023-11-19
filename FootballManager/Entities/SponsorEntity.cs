using System.ComponentModel.DataAnnotations;

namespace FootballManager.Entities;

public class SponsorEntity
{
    [Key]
    public int Id { get; set; }
    public string SponsorName { get; set; } = null!;
    public string SponsorEmail { get; set; } = null!;
    public int ClubId { get; set; }
}
