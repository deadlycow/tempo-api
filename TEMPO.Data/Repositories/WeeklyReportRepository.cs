using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TEMPO.Data.Contexts;
using TEMPO.Data.Entities;

namespace TEMPO.Data.Repositories;

public class WeeklyReport(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;
    private readonly DbSet<WeeklyReport> weeklyReports = context.Set<WeeklyReport>();

    public async Task<WeeklyReport> Get(string id)
    {
        var result = await weeklyReports.FirstOrDefaultAsync(wr => wr.)
        throw new NotImplementedException();
    }
    public async Task<ICollection<WeeklyReport>> GetAll()
    {
        throw new NotImplementedException();
    }
    public async Task Create()
    {
        throw new NotImplementedException();
    }
    public async Task Update()
    {
        throw new NotImplementedException();
    }
    public Task Delete()
    {
        throw new NotImplementedException();
    }
    
}
