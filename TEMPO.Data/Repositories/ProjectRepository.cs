using Microsoft.EntityFrameworkCore;
using TEMPO.Data.Contexts;
using TEMPO.Data.Entities;
using TEMPO.Data.Interfaces;

namespace TEMPO.Data.Repositories;

public class ProjectRepository(ApplicationDbContext dbContext) : IProjectRepository
{
  private readonly ApplicationDbContext _dbContext = dbContext;
  private readonly DbSet<Project> _projects = dbContext.Set<Project>();
  public async Task<Project?> GetByIdAsync(Guid id, bool includeTimeEntries = false)
  {
    IQueryable<Project> query = _projects;
    if (includeTimeEntries)
      query = query.Include(x => x.TimeEntries);

    return await query.FirstOrDefaultAsync(x => x.Id == id);
  }
  public async Task<IEnumerable<Project>> GetAllAsync()
  {
    return await _projects.ToListAsync();
  }
  public async Task<Project> CreateAsync(Project project)
  {
    await _projects.AddAsync(project);
    await _dbContext.SaveChangesAsync();

    return project;
  }
  public async Task DeleteAsync(Guid id)
  {
    var project = await _projects.FindAsync(id);

    if (project == null)
      return;

    _projects.Remove(project);
    await _dbContext.SaveChangesAsync();
  }
  public async Task<bool> UpdateAsync(Project project)
  {
    _projects.Update(project);
    return await _dbContext.SaveChangesAsync() > 0;
  }
}
