using FootballManager.Contexts;
using FootballManager.Entities;
namespace FootballManager.Repositories;

public class TrainingFacilityRepository : Repo<TrainingFacilityEntity>
{
    public TrainingFacilityRepository(DataContext context) : base(context)
    {
    }
}
