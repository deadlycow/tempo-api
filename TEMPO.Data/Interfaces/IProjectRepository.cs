using TEMPO.Data.Entities;

namespace TEMPO.Data.Interfaces;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(Guid id, bool includeTimeEntries = false);
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project> CreateAsync(Project project);
    Task DeleteAsync(Guid id);
    Task<bool> UpdateAsync(Project project);
}