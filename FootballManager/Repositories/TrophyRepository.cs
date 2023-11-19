using FootballManager.Contexts;
using FootballManager.Entities;

namespace FootballManager.Repositories;

public interface ITrophyRepository : IRepo<TrophyEntity>
{
}
public class TrophyRepository : Repo<TrophyEntity>, ITrophyRepository
{

    public TrophyRepository(DataContext context) : base(context)
    {
    }
}
