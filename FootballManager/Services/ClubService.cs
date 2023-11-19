using FootballManager.Entities;
using FootballManager.Models;
using FootballManager.Repositories;

namespace FootballManager.Services;

public class ClubService
{
    private readonly ClubRepository _clubRepository;
    private readonly ManagerRepository _managerRepository;
    private readonly StadiumRepository _stadiumRepository;
    private readonly TrainingFacilityRepository _trainingFacilityRepository;
    private readonly YouthTeamRepository _youthTeamRepository;

    public ClubService(ClubRepository clubRepository, ManagerRepository managerRepository, StadiumRepository stadiumRepository, TrainingFacilityRepository trainingFacilityRepository, YouthTeamRepository youthTeamRepository)
    {
        _clubRepository = clubRepository;
        _managerRepository = managerRepository;
        _stadiumRepository = stadiumRepository;
        _trainingFacilityRepository = trainingFacilityRepository;
        _youthTeamRepository = youthTeamRepository;
    }

    public async Task<bool> CreateClubAsync(ClubRegistrationForm form)
    {
        try 
        { 
            if(! await _clubRepository.ExistsAsync(x => x.ClubName == form.ClubName))
            {
                //Kolla ifall managern finns
                var manager = await _managerRepository.GetAsync(x => x.ManagerEmail == form.ManagerEmail);
                manager ??= await _managerRepository.CreateAsync(new ManagerEntity { ManagerEmail = form.ManagerEmail, FirstName = form.ManagerFirstName, LastName = form.ManagerLastName});
                //Kolla om stadion finns
                var stadium = await _stadiumRepository.GetAsync(x => x.StadiumName == form.StadiumName && x.Location == form.StadiumLocation);
                stadium ??= await _stadiumRepository.CreateAsync(new StadiumEntity { Location = form.StadiumLocation, StadiumName = form.StadiumName });
                //Kolla om träningscentret finns
                var trainingFacility = await _trainingFacilityRepository.GetAsync(x => x.FacilityName == form.TrainingFacilityName && x.Location == form.TrainingFacilityLocation);
                trainingFacility ??= await _trainingFacilityRepository.CreateAsync(new TrainingFacilityEntity { Location = form.TrainingFacilityLocation, FacilityName = form.TrainingFacilityName });
                //Kolla om ungdomslaget finns
                var youthTeam = await _youthTeamRepository.GetAsync(x => x.TeamName == form.YouthTeamName);
                youthTeam ??= await _youthTeamRepository.CreateAsync(new YouthTeamEntity { TeamName = form.YouthTeamName });
                //Skapa klubb
                var clubEntity = await _clubRepository.CreateAsync(new ClubEntity { ClubName = form.ClubName, FoundedYear = form.FoundedYear });
                if (clubEntity != null)
                    return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in CreateClubAsync: {ex.Message}");
            return false;
        }
    }

    public async Task<IEnumerable<ClubEntity>> GetAllAsync()
    {
        try
        {
            var clubs = await _clubRepository.GetAllAsync();
            return clubs;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in GetAllAsync: {ex.Message}");
            return Enumerable.Empty<ClubEntity>();
        }
    }

    
}
