using FootballManager.Models;
using FootballManager.Repositories;
using FootballManager.Services;

namespace FootballManager.Menus;

public class ViewMenuOptions
{
    private readonly PlayerRepository _playerRepository;
    private readonly ClubRepository _clubRepository;
 

    public ViewMenuOptions(PlayerRepository playerRepository, ClubRepository clubRepository)
    {
        _playerRepository = playerRepository;
        _clubRepository = clubRepository;
  
    }

    public async Task ListAllPlayersAsync()
    {
        try
        {
            var players = await _playerRepository.GetAllAsync();
            foreach (var player in players)
            {
                Console.WriteLine($"{player.FirstName} {player.LastName} {player.Position}");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in CreateClubAsync: {ex.Message}");
        }

    }
    public async Task ListAllClubsAsync()
    {
        try
        {
            var clubs = await _clubRepository.GetAllAsync();
            foreach (var club in clubs)
            {
                Console.WriteLine($"{club.ClubName} {club.FoundedYear}");

                Console.WriteLine();
            }
        }
    
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in CreateClubAsync: {ex.Message}");
        }
        Console.ReadKey();
    }

}
