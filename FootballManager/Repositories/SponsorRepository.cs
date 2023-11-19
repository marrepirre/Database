
using FootballManager.Contexts;
using FootballManager.Entities;

namespace FootballManager.Repositories;

public class SponsorRepository : Repo<SponsorEntity>
{
    public SponsorRepository(DataContext context) : base(context)
    {
    }
}
