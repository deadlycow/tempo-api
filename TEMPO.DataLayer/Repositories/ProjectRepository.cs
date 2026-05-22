using Microsoft.EntityFrameworkCore;
using TEMPO.DataLayer.Contexts;
using TEMPO.DataLayer.Entities;

namespace TEMPO.DataLayer.Repositories;

public class ProjectRepository(ApplicationDbContext dbContext)
{
  private readonly ApplicationDbContext _dbContext = dbContext;
  private readonly DbSet<Project> _projects = dbContext.Set<Project>();
  public async Task<IEnumerable<Project>> GetAllAsync()
  {
    return await _projects.ToListAsync();
  }
  public async Task<Project> GetByIdAsync(Guid id)
  {
    return await _projects.FindAsync(id) ?? throw new KeyNotFoundException($"Project with ID {id} not found.");
  }
  public async Task<Project> CreateAsync(Project project)
  {
    await _projects.AddAsync(project);
    await _dbContext.SaveChangesAsync();

    return project;
  }
  public async Task<string> DeleteAsync(Guid id)
  {
    var project = await GetByIdAsync(id);
    _projects.Remove(project);
    await _dbContext.SaveChangesAsync();
    return $"Project with ID {id} deleted successfully.";
  }
  public async Task<string> UpdateAsync(Project project)
  {
    _projects.Update(project);
    await _dbContext.SaveChangesAsync();
    return $"Project '{project.Name}' updated successfully.";
  }
}