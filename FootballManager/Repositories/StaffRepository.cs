using FootballManager.Contexts;
using FootballManager.Entities;

namespace FootballManager.Repositories;

public class StaffRepository : Repo<StaffEntity>
{
    public StaffRepository(DataContext context) : base(context)
    {
    }
}
