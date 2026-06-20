using BugTracker.Api.DTOs.Projects;

namespace BugTracker.Api.Interfaces;

public interface IProjectService
{
    Task<ProjectResponseDto> CreateAsync(CreateProjectDto dto);

    Task<IEnumerable<ProjectResponseDto>> GetAllAsync();

    Task<ProjectResponseDto?> GetByIdAsync(Guid id);

    Task<bool> UpdateAsync(Guid id, UpdateProjectDto dto);

    Task<bool> DeleteAsync(Guid id);
}