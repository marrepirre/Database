using System.ComponentModel.DataAnnotations;

namespace FootballManager.Entities;

public class PlayerEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PlayerEmail { get; set; } = null!;
    public string Position { get; set; } = null!;
    public string Age { get; set; } = null!;
    public int? ClubId { get; set; }
    public int? NationalTeamId { get; set; }
}