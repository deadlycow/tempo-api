using TEMPO.DataLayer.Entities;

namespace TEMPO.DataLayer.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(Guid id);
    Task<Project> CreateAsync(Project project);
    Task DeleteAsync(Guid id);
    Task<bool> UpdateAsync(Project project);
}