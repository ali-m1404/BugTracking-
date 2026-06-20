using BugTracker.Api.Data;
using BugTracker.Api.DTOs.Projects;
using BugTracker.Api.Entities;
using BugTracker.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Api.Services;

public class ProjectService : IProjectService
{
    private readonly AppDbContext _context;

    public ProjectService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProjectResponseDto> CreateAsync(CreateProjectDto dto)
    {
        var project = new ProjectEntity
        {
            Name = dto.Name,
            Description = dto.Description,
            ManagerId = dto.ManagerId
        };

        _context.Projects.Add(project);

        await _context.SaveChangesAsync();

        return new ProjectResponseDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            IsArchived = project.IsArchived,
            ManagerId = project.ManagerId
        };
    }

    public async Task<IEnumerable<ProjectResponseDto>> GetAllAsync()
    {
        return await _context.Projects
            .Include(p => p.Manager)
            .Select(p => new ProjectResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                IsArchived = p.IsArchived,
                ManagerId = p.ManagerId,
                ManagerName = p.Manager.FirstName + " " + p.Manager.LastName
            })
            .ToListAsync();
    }

    public async Task<ProjectResponseDto?> GetByIdAsync(Guid id)
    {
        return await _context.Projects
            .Include(p => p.Manager)
            .Where(p => p.Id == id)
            .Select(p => new ProjectResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                IsArchived = p.IsArchived,
                ManagerId = p.ManagerId,
                ManagerName = p.Manager.FirstName + " " + p.Manager.LastName
            })
            .FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateProjectDto dto)
    {
        var project = await _context.Projects
            .FirstOrDefaultAsync(p => p.Id == id);

        if (project == null)
            return false;

        project.Name = dto.Name;
        project.Description = dto.Description;
        project.IsArchived = dto.IsArchived;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var project = await _context.Projects
            .FirstOrDefaultAsync(p => p.Id == id);

        if (project == null)
            return false;

        _context.Projects.Remove(project);

        await _context.SaveChangesAsync();

        return true;
    }
}