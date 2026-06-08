using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TEMPO.Contracts.Dtos;
using TEMPO.Service.Command;
using TEMPO.Service.Interfaces;

namespace TEMPO.Api.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;
    [HttpGet]
    [ProducesResponseType(typeof(ProjectResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get([FromQuery] GetProjectRequest request)
    {
        var result = await _projectService.GetByIdAsync(request.Id, request.IncludeTimeEntries);
        if (!result.Success)
            return NotFound(result.ErrorMessage);
        return Ok(result.Data);
    }
    [HttpGet("all")]
    [ProducesResponseType(typeof(IEnumerable<ProjectResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetAll()
    {
        var result = await _projectService.GetAllAsync();
        if (result == null || !result.Success)
            return NotFound(result?.ErrorMessage ?? "No projects found.");
        return Ok(result.Data);
    }
    [HttpPost]
    [ProducesResponseType(typeof(CreateProjectRequest), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create(CreateProjectRequest request)
    {
        var result = await _projectService.CreateAsync(new CreateProjectCommand
        {
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        });
        if (!result.Success)
            return BadRequest(result.ErrorMessage);
        return CreatedAtAction(nameof(Get), new { id = result.Data?.Id }, result.Data);
    }
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete([FromQuery] DeleteProjectRequest request)
    {
        var result = await _projectService.DeleteAsync(request.Id);

        if (!result.Success)
            return NotFound(result.ErrorMessage);

        return NoContent();
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Update(UpdateProjectRequest request)
    {
        var result = await _projectService.UpdateAsync(new UpdateProjectCommand
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        });
        if (!result.Success)
            return BadRequest(result.ErrorMessage);
        return Ok(result.Data);
    }
}