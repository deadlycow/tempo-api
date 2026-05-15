using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TEMPO.DataLayer.Contexts;

    public class ApplicationDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\tempo-backend\\TEMPO.DataLayer\\tempo.mdf;Integrated Security=True;Connect Timeout=30");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }