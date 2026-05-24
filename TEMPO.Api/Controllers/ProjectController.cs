using Microsoft.AspNetCore.Mvc;
using TEMPO.Api.Dtos;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Command;
using TEMPO.ServiceLayer.Interfaces;

namespace TEMPO.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ProjectModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromQuery] GetProjectRequest request)
    {
        var result = await _projectService.GetByIdAsync(request.Id);
        if (!result.Success)
            return NotFound(result.ErrorMessage);
        return Ok(result.Data);
    }
    private readonly IProjectService _projectService = projectService;
    [HttpGet("all")]
    [ProducesResponseType(typeof(IEnumerable<ProjectModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetAllAsync();
        if (projects == null || !projects.Success)
            return NotFound(projects?.ErrorMessage ?? "No projects found.");
        return Ok(projects);
    }
    [HttpPost]
    [ProducesResponseType(typeof(CreateProjectRequest), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateProjectRequest request)
    {
        var command = new CreateProjectCommand
        {
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };
        var result = await _projectService.CreateAsync(command);
        if (!result.Success)
            return BadRequest(result.ErrorMessage);
        return CreatedAtAction(nameof(Get), new { id = result.Data?.Id }, result.Data);
    }
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromQuery] DeleteProjectRequest request)
    {
        var result = await _projectService.DeleteAsync(request.Id);

        if (!result.Success)
            return NotFound(result.ErrorMessage);

        return NoContent();
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdateProjectRequest request)
    {
        var command = new UpdateProjectCommand
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };
        var result = await _projectService.UpdateAsync(command);
        if (!result.Success)
            return BadRequest(result.ErrorMessage);
        return Ok(result.Data);
    }
}