using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FootballManager.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Nackademin\FootballManager\FootballManager\Contexts\database.mdf;Integrated Security=True;Connect Timeout=30");
        return new DataContext(optionBuilder.Options);
    }
}
