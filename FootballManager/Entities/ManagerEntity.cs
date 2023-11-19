using System.ComponentModel.DataAnnotations;

namespace FootballManager.Entities;

public class ManagerEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string ManagerEmail { get; set; } = null!;
    public int ClubId { get; set; }
}
