using FootballManager.Entities;
using FootballManager.Models;
using FootballManager.Repositories;
using System.Linq.Expressions;

namespace FootballManager.Services;

public class PlayerService
{
    private readonly PlayerRepository _playerRepository;

    public PlayerService(PlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<bool> CreatePlayerAsync(PlayerRegistrationForm form)
    {
      try
      {
            if (!await _playerRepository.ExistsAsync(x => x.PlayerEmail == form.PlayerEmail))
            {
            
                //Skapa spelare
                var playerEntity = await _playerRepository.CreateAsync(new PlayerEntity 
                { 
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Age = form.Age,
                    PlayerEmail = form.PlayerEmail,
                    Position = form.Position
                });
                if (playerEntity != null)
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

    public async Task<IEnumerable<PlayerEntity>> GetAllAsync()
    {
        try
        {
            var clubs = await _playerRepository.GetAllAsync();
            return clubs;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in GetAllAsync: {ex.Message}");
            return Enumerable.Empty<PlayerEntity>();
        }

    }

    public async Task<PlayerEntity?> GetAPlayerAsync(string playerEmail)
    {
        try
        {
            var player = await _playerRepository.GetAsync(x => x.PlayerEmail == playerEmail);
            return player;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in GetAPlayerAsync: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> RemovePlayerAsync(PlayerRegistrationForm form)
    {
        try
        {
            var player = await _playerRepository.GetAsync(x => x.PlayerEmail == form.PlayerEmail);

            if (player == null)
                return false; // Spelaren finns inte

            // Skapa ett uttryck för att matcha spelaren som ska tas bort
            Expression<Func<PlayerEntity, bool>> expression = x => x.Id == player.Id;


            // Ta bort spelaren från databasen
            var result = await _playerRepository.RemoveAsync(expression);

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in RemovePlayerAsync: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> UpdatePlayerAsync(string playerEmail, PlayerRegistrationForm form)
    {
        try
        {
            var player = await _playerRepository.GetAsync(x => x.PlayerEmail == playerEmail);

            if (player == null)
                return false; // Spelaren finns inte

            // Uppdatera spelaren med nya uppgifter från formuläret
            player.FirstName = form.FirstName;
            player.LastName = form.LastName;
            player.Age = form.Age;
            player.Position = form.Position;

            // Anropa UpdateAsync från PlayerRepository
            var result = await _playerRepository.UpdateAsync(player);

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in UpdatePlayerAsync: {ex.Message}");
            return false;
        }
    }
}
