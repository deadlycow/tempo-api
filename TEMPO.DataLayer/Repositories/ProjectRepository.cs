using Microsoft.EntityFrameworkCore;
using TEMPO.DataLayer.Contexts;
using TEMPO.DataLayer.Entities;
using TEMPO.Domain.Models;

namespace TEMPO.DataLayer.Repositories;

public class ProjectRepository(ApplicationDbContext dbContext)
{
  private readonly ApplicationDbContext _dbContext = dbContext;
  private readonly DbSet<Project> _projects = dbContext.Set<Project>();
  public async Task<List<Project>> GetAllAsync()
  {
    // Logic to retrieve projects from the database
    return await _projects.ToListAsync();
  }
  public async Task<string> GetProjectByIdAsync(Guid id)
  {
    // Logic to retrieve a specific project by ID from the database
    return $"Project with ID {id}";
  }
  public async Task<Project> CreateProjectAsync(Project project)
  {
    await _projects.AddAsync(project);
    await _dbContext.SaveChangesAsync();

    return project;
  }
  public async Task<string> DeleteProjectAsync(Guid id)
  {
    // Logic to delete a project from the database
    return $"Project with ID {id} deleted successfully.";
  }
  public async Task<string> UpdateProjectAsync(Guid id, string projectName)
  {
    // Logic to update a project in the database
    return $"Project '{projectName}' updated successfully.";
  }
}