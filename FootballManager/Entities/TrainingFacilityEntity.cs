using System.ComponentModel.DataAnnotations;

namespace FootballManager.Entities;

public class TrainingFacilityEntity
{
    [Key]
    public int Id { get; set; }
    public string FacilityName { get; set; } = null!;
    public string Location { get; set; } = null!;
    public int ClubId { get; set; }
}
