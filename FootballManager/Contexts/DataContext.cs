using FootballManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<ClubEntity> Clubs { get; set; }
    public DbSet<ManagerEntity> Managers { get; set; }
    public DbSet<NationalTeamEntity> NationalTeams { get; set; }
    public DbSet<PlayerEntity> Players { get; set; }
    public DbSet<SponsorEntity> Sponsors { get; set;}
    public DbSet<StadiumEntity> Stadiums { get; set;}
    public DbSet<StaffEntity> Staffs { get; set;}
    public DbSet<TrainingFacilityEntity> TrainingFacilities { get; set; }
    public DbSet<TrophyEntity> Trophys { get; set;}
    public DbSet<YouthTeamEntity> YouthTeams { get; set;}
}
