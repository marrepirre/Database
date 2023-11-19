using FootballManager.Contexts;
using FootballManager.Menus;
using FootballManager.Repositories;
using FootballManager.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FootballManager;

public class Program
{
    static async Task Main(string[] args)
    {
            var services = new ServiceCollection();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Nackademin\FootballManager\FootballManager\Contexts\database.mdf;Integrated Security=True;Connect Timeout=30"));

            //Repos
            services.AddScoped<ClubRepository>();
            services.AddScoped<PlayerRepository>();
            services.AddScoped<ManagerRepository>();
            services.AddScoped<NationalTeamRepository>();
            services.AddScoped<SponsorRepository>();
            services.AddScoped<StadiumRepository>();
            services.AddScoped<StaffRepository>();
            services.AddScoped<TrainingFacilityRepository>();
            services.AddScoped<ITrophyRepository,TrophyRepository>();
            services.AddScoped<YouthTeamRepository>();
            //Services
            services.AddScoped<ClubService>();
            services.AddScoped<PlayerService>();
            services.AddScoped<SponsorService>();
            services.AddScoped<TrophyService>();
            //Menyer
            services.AddScoped<MainMenu>();
            services.AddScoped<ViewMenuOptions>();
            services.AddScoped<CreateMenuOptions>();
            services.AddScoped<RemoveAndUpdateOptions>();
            var sp = services.BuildServiceProvider();
            var mainMenu = sp.GetRequiredService<MainMenu>();
            await mainMenu.StartAsync();
      
            
        
    }
}