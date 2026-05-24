using Microsoft.EntityFrameworkCore;
using TEMPO.DataLayer.Contexts;
using TEMPO.DataLayer.Entities;
using TEMPO.DataLayer.Interfaces;

namespace TEMPO.DataLayer.Repositories;

public class ProjectRepository(ApplicationDbContext dbContext) : IProjectRepository
{
  private readonly ApplicationDbContext _dbContext = dbContext;
  private readonly DbSet<Project> _projects = dbContext.Set<Project>();
  public async Task<IEnumerable<Project>> GetAllAsync()
  {
    return await _projects.ToListAsync();
  }
  public async Task<Project?> GetByIdAsync(Guid id)
  {
    return await _projects.FirstOrDefaultAsync(p => p.Id == id);
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
