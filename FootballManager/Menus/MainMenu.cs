namespace FootballManager.Menus;

public class MainMenu
{

   private readonly ViewMenuOptions _viewMenuOptions;
   private readonly CreateMenuOptions _createMenuOptions;
   private readonly RemoveAndUpdateOptions _removeAndUpdateOptions;

    public MainMenu(CreateMenuOptions createMenuOptions, ViewMenuOptions viewMenuOptions, RemoveAndUpdateOptions removeAndUpdateOptions)
    {
        _createMenuOptions = createMenuOptions;
        _viewMenuOptions = viewMenuOptions;
        _removeAndUpdateOptions = removeAndUpdateOptions;
    }


    public async Task StartAsync()
    {
        try
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Football Manager Console app!");
                Console.WriteLine("1. Create Menu");
                Console.WriteLine("2. View Menu");
                Console.WriteLine("3. Update players");
                Console.WriteLine("4. Delete players");
                Console.WriteLine("5. Close program");
                Console.Write("Chose one option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        await CreateMenu();
                        break;
                    case "2":
                        await ViewMenu();
                        break;
                    case "3":
                        await _removeAndUpdateOptions.UpdateAPlayerAsync();
                        break;
                    case "4":
                        await _removeAndUpdateOptions.RemovingPlayerAsync();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                }

            } while (true);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in CreateClubAsync: {ex.Message}");
        }

    }
    public async Task CreateMenu()
    {
        try
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Football Manager Console app!");
                Console.WriteLine("1. Create Club");
                Console.WriteLine("2. Create Player");
                Console.WriteLine("3. Create Trophy");
                Console.WriteLine("4. Create Sponsor");
                Console.WriteLine("5. Go back to main menu");
                Console.Write("Chose one option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        await _createMenuOptions.CreateClubAsync();
                        break;
                    case "2":
                        await _createMenuOptions.CreatePlayerAsync();
                        break;
                    case "3":
                        await _createMenuOptions.CreateTrophyAsync();
                        break;
                    case "4":
                        await _createMenuOptions.CreateSponsorAsync();
                        break;
                    case "5":
                        await StartAsync();
                        break;
                }

            } while (true);
        }

        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in CreateClubAsync: {ex.Message}");
        }
    }
    public async Task ViewMenu()
    {
        try
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Football Manager Console app!");
                Console.WriteLine("1. View all clubs");
                Console.WriteLine("2. View all players");
                Console.WriteLine("3. Go back to main menu");
                Console.Write("Chose one option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        await _viewMenuOptions.ListAllClubsAsync();
                        break;
                    case "2":
                        await _viewMenuOptions.ListAllPlayersAsync();
                        break;
                    case "3":
                        await StartAsync();
                        break;
                }

            } while (true);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in CreateClubAsync: {ex.Message}");
        }

    }
}
