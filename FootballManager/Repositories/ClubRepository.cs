using FootballManager.Contexts;
using FootballManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Repositories;

public class ClubRepository : Repo<ClubEntity>
{
    public ClubRepository(DataContext context) : base(context)
    {
    }
}
