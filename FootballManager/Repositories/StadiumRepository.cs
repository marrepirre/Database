using FootballManager.Contexts;
using FootballManager.Entities;
namespace FootballManager.Repositories;

public class StadiumRepository : Repo<StadiumEntity>
{
    public StadiumRepository(DataContext context) : base(context)
    {
    }
}
