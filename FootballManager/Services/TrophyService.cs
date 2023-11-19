using FootballManager.Entities;
using FootballManager.Models;
using FootballManager.Repositories;

namespace FootballManager.Services;

public class TrophyService
{
    private readonly ITrophyRepository _trophyRepository;

    public TrophyService(ITrophyRepository trophyRepository)
    {
        _trophyRepository = trophyRepository;
    }

    public async Task<bool> CreateTrophyAsync(TrophyRegistrationForm form)
    {
        try
        {
            if (!await _trophyRepository.ExistsAsync(x => x.TrophyName == form.TrophyName && x.Year == form.Year))
            {

                //Skapa spelare
                var trophyEntity = await _trophyRepository.CreateAsync(new TrophyEntity
                {
                   TrophyName = form.TrophyName,
                   Year = form.Year,

                });
                if (trophyEntity != null)
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

    public async Task<IEnumerable<TrophyEntity>> GetAllAsync()
    {
        try
        {
            var clubs = await _trophyRepository.GetAllAsync();
            return clubs;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in GetAllAsync: {ex.Message}");
            return Enumerable.Empty<TrophyEntity>();
        }
    }
}
