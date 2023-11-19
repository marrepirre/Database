using FootballManager.Contexts;
using FootballManager.Entities;

namespace FootballManager.Repositories;

public class YouthTeamRepository : Repo<YouthTeamEntity>
{
    public YouthTeamRepository(DataContext context) : base(context)
    {
    }
}
