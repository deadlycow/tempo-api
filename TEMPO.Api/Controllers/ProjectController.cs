using Microsoft.AspNetCore.Mvc;
using TEMPO.Api.Dtos;
using TEMPO.ServiceLayer.Command;
using TEMPO.ServiceLayer.Services;

namespace TEMPO.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController(ProjectService projectService) : ControllerBase
{
    private readonly ProjectService _projectService = projectService;
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetAllAsync();
        // Logic to retrieve projects
        return Ok(projects);
    }
    [HttpGet]
    public async Task<IActionResult> Get([FromBody] GetProjectRequest request)
    {
        throw new NotImplementedException();
        // return Ok($"Project with ID {request.Id}");
    }


    [HttpPost]
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
        // Logic to create a new project
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteProjectRequest request)
    {
        // Logic to delete a project
        return Ok($"Project with ID {request.Id} deleted successfully.");
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateProjectRequest request)
    {
        // Logic to update a project
        return Ok($"Project '{request.Name}' updated successfully.");
    }
}