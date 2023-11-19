using FootballManager.Entities;
using FootballManager.Models;
using FootballManager.Repositories;

namespace FootballManager.Services;

public class SponsorService
{
    private readonly SponsorRepository _sponsorRepository;

    public SponsorService(SponsorRepository sponsorRepository)
    {
        _sponsorRepository = sponsorRepository;
    }

    public async Task<bool> CreateSponsorAsync(SponsorRegistrationForm form)
    {
        try
        {
            if (!await _sponsorRepository.ExistsAsync(x => x.SponsorEmail == form.SponsorEmail))
            {

                //Skapa spelare
                var sponsorEntity = await _sponsorRepository.CreateAsync(new SponsorEntity
                {
                    SponsorName = form.SponsorName,
                    SponsorEmail = form.SponsorEmail,
                });
                if (sponsorEntity != null)
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

    public async Task<IEnumerable<SponsorEntity>> GetAllAsync()
    {
        try
        {
            var clubs = await _sponsorRepository.GetAllAsync();
            return clubs;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in GetAllAsync: {ex.Message}");
            return Enumerable.Empty<SponsorEntity>();
        }
    }
}
