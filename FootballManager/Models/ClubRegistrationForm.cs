namespace FootballManager.Models;

public class ClubRegistrationForm
{
    public string ClubName { get; set; } = null!;
    public string FoundedYear { get; set; } = null!;
    public string ManagerFirstName { get; set; } = null!;
    public string ManagerLastName { get; set; } = null!;
    public string ManagerEmail { get; set; } = null!;

    public string StadiumName { get; set; } = null!;
    public string StadiumLocation { get; set; } = null!;
    public string TrainingFacilityName { get; set; } = null!;
    public string TrainingFacilityLocation { get; set; } = null!;
    public string YouthTeamName { get; set; } = null!;
}
