
using FootballManager.Contexts;
using FootballManager.Entities;

namespace FootballManager.Repositories;

public class NationalTeamRepository : Repo<NationalTeamEntity>
{
    public NationalTeamRepository(DataContext context) : base(context)
    {
    }
}
