

using FootballManager.Contexts;
using FootballManager.Entities;

namespace FootballManager.Repositories;

public class ManagerRepository : Repo<ManagerEntity>
{
    public ManagerRepository(DataContext context) : base(context)
    {
    }
}
