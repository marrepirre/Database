using System.ComponentModel.DataAnnotations;

namespace FootballManager.Entities;

public class StadiumEntity
{
    [Key]
    public int Id { get; set; }
    public string StadiumName { get; set; } = null!;
    public string Location { get; set; } = null!;
    public int ClubId { get; set; }
}
