using FootballManager.Entities;
using FootballManager.Models;
using FootballManager.Services;

namespace FootballManager.Menus;

public class CreateMenuOptions
{
    private readonly ClubService _clubService;
    private readonly TrophyService _trophyService;
    private readonly PlayerService _playerService;
    private readonly SponsorService _sponsorService;
    public CreateMenuOptions(ClubService clubService, TrophyService trophyService, PlayerService playerService, SponsorService sponsorService)
    {
        _clubService = clubService;
        _trophyService = trophyService;
        _playerService = playerService;
        _sponsorService = sponsorService;
    }


    public async Task CreateClubAsync()
    {
        try 
        { 
            var form = new ClubRegistrationForm();
            Console.Clear();
            Console.WriteLine("Club Name");
            form.ClubName = Console.ReadLine()!;
            Console.WriteLine("What year was the club founded?");
            form.FoundedYear = Console.ReadLine()!;
            Console.WriteLine("Manager first name: ");
            form.ManagerFirstName = Console.ReadLine()!;
            Console.WriteLine("Manager last name: ");
            form.ManagerLastName = Console.ReadLine()!;
            Console.WriteLine("Manager email: ");
            form.ManagerEmail = Console.ReadLine()!;
            Console.WriteLine("Clubs stadium name: ");
            form.StadiumName = Console.ReadLine()!;
            Console.WriteLine("Stadium location: ");
            form.StadiumLocation = Console.ReadLine()!;
            Console.WriteLine("Training facility name: ");
            form.TrainingFacilityName = Console.ReadLine()!;
            Console.WriteLine("Training facility location: ");
            form.TrainingFacilityLocation = Console.ReadLine()!;
            Console.WriteLine("Clubs youth team name: ");
            form.YouthTeamName = Console.ReadLine()!;

            var result = await _clubService.CreateClubAsync(form);
            if (result)
                Console.WriteLine("Club was created!");
            else
                Console.WriteLine("Unable to create club!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in CreateClubAsync: {ex.Message}");
        }
        Console.ReadKey();
    }
    public async Task CreatePlayerAsync()
    {
        try 
        { 
            var form = new PlayerRegistrationForm();
            Console.Clear();
            Console.WriteLine("Player first name:");
            form.FirstName = Console.ReadLine()!;
            Console.WriteLine("Player last name:");
            form.LastName = Console.ReadLine()!;
            Console.WriteLine("Player age:");
            form.Age = Console.ReadLine()!;
            Console.WriteLine("Player position:");
            form.Position = Console.ReadLine()!;
            Console.WriteLine("Player email:");
            form.PlayerEmail = Console.ReadLine()!;
            var result = await _playerService.CreatePlayerAsync(form);
            if (result)
                Console.WriteLine("Player was created!");
            else
                Console.WriteLine("Unable to create player!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in CreateClubAsync: {ex.Message}");
        }
        Console.ReadKey();
    }

    public async Task CreateTrophyAsync()
    {
        try
        {
            Console.Clear();
            var form = new TrophyRegistrationForm();
            Console.WriteLine("Trophy Name :");
            form.TrophyName = Console.ReadLine()!;
            Console.WriteLine("Trophy year :");
            form.Year = Console.ReadLine()!;

            var result = await _trophyService.CreateTrophyAsync(form);
            if (result)
                Console.WriteLine("Trophy was added!");
            else
                Console.WriteLine("Unable to create trophy!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in CreateClubAsync: {ex.Message}");
        }
        Console.ReadKey();
    }
    public async Task CreateSponsorAsync()
    {
        try
        {
            Console.Clear();
            var form = new SponsorRegistrationForm();
            Console.WriteLine("Sponsor Name :");
            form.SponsorName = Console.ReadLine()!;
            Console.WriteLine("Sponsor email :");
            form.SponsorEmail = Console.ReadLine()!;

            var result = await _sponsorService.CreateSponsorAsync(form);
            if (result)
                Console.WriteLine("Sponsor was added!");
            else
                Console.WriteLine("Unable to create sponsor!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in CreateClubAsync: {ex.Message}");
        }
        Console.ReadKey();
    }
}
