using System.ComponentModel.DataAnnotations;

namespace FootballManager.Entities;

public class StaffEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Position { get; set; } = null!;
    public int ClubId { get; set; }
}
