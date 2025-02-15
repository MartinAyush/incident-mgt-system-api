using IncidentMgtSystem.API.DTOs;
using IncidentMgtSystem.API.Models;
using IncidentMgtSystem.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IncidentMgtSystem.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class IncidentController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly IncidentService _incService;
    public IncidentController(ILogger<AccountController> logger, IncidentService incService)
    {
        _logger = logger;
        _incService = incService;
    }

    [HttpPost(Name = "Save")]
    [Authorize]
    public IncidentSaveAPIResponse Save([FromBody] IncidentSaveAPIRequest request)
    {
        var userId = HttpContext.User.FindFirst("Id").Value;
        var response = _incService.SaveIncident(request, Int32.Parse(userId));
        return response;
    }

    [HttpPost(Name = "SaveComment")]
    [Authorize]
    public IncidentCommentSaveAPIResponse SaveComment([FromBody] IncidentCommentSaveAPIRequest request)
    {
        var userId = HttpContext.User.FindFirst("Id").Value;
        var response = _incService.SaveIncidentComment(request, Int32.Parse(userId));
        return response;
    }

    [HttpPost(Name = "GetAll")]
    [Authorize]
    public List<IncidentMaster> GetAll()
    {
        var userId = HttpContext.User.FindFirst("Id").Value;
        var response = _incService.GetAll();
        return response;
    }

    [HttpGet(Name = "GetById/{id}")]
    [Authorize]
    public IncidentMaster GetById(int id)
    {
        var userId = HttpContext.User.FindFirst("Id").Value;
        var response = _incService.GetById(id);
        return response;
    }
}
