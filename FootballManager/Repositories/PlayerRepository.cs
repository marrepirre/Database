
using FootballManager.Contexts;
using FootballManager.Entities;

namespace FootballManager.Repositories;

public class PlayerRepository : Repo<PlayerEntity>
{
    public PlayerRepository(DataContext context) : base(context)
    {
    }
}
