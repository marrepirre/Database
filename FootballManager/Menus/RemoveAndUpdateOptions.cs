using FootballManager.Models;
using FootballManager.Repositories;
using FootballManager.Services;

namespace FootballManager.Menus;

public class RemoveAndUpdateOptions
{
    private readonly PlayerService _playerService;
    private readonly ClubService _clubService;

    public RemoveAndUpdateOptions(PlayerService playerService, ClubService clubService)
    {
        _playerService = playerService;
        _clubService = clubService;
    }

    public async Task RemovingPlayerAsync()
    {

        Console.Clear();
        Console.WriteLine("Remove Player");
        Console.Write("Enter player email to remove: ");
        var playerEmail = Console.ReadLine()!;

        var form = new PlayerRegistrationForm { PlayerEmail = playerEmail };

        var result = await _playerService.RemovePlayerAsync(form);

        if (result)
            Console.WriteLine("Player removed successfully!");
        else
            Console.WriteLine("Failed to remove player!");

        Console.ReadKey();

    }

    public async Task UpdateAPlayerAsync()
    {
        Console.Clear();
        Console.WriteLine("Update Player");
        Console.Write("Enter player email to update: ");
        var playerEmail = Console.ReadLine()!;

        var existingPlayer = await _playerService.GetAPlayerAsync(playerEmail);

        if (existingPlayer != null)
        {
            Console.WriteLine($"Current Information: {existingPlayer.FirstName} {existingPlayer.LastName} (Age: {existingPlayer.Age}, Position: {existingPlayer.Position})");

            var form = new PlayerRegistrationForm();
            Console.Write("Enter new first name: ");
            form.FirstName = Console.ReadLine()!;
            Console.Write("Enter new last name: ");
            form.LastName = Console.ReadLine()!;
            Console.Write("Enter new age: ");
            form.Age = Console.ReadLine()!;
            Console.Write("Enter new position: ");
            form.Position = Console.ReadLine()!;

            var result = await _playerService.UpdatePlayerAsync(playerEmail, form);

            if (result)
                Console.WriteLine("Player updated successfully!");
            else
                Console.WriteLine("Failed to update player!");
        }
        else
        {
            Console.WriteLine("Player not found!");
        }

        Console.ReadKey();
    }
}
