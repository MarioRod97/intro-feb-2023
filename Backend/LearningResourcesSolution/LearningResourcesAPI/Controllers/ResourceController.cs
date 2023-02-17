using LearningResourcesApi.Models;
using LearningResourcesAPI.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace LearningResourcesApi.Controllers;

public class ResourcesController : ControllerBase
{
    private readonly LearningResourcesDataContext _context;

    public ResourcesController(LearningResourcesDataContext context)
    {
        _context = context;
    }

    [HttpPost("/resources")]
    public async Task<ActionResult> AddItem([FromBody] CreateResourceItem request)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }
        var response = new GetResourceItem
        {
            Id = Guid.NewGuid().ToString(),
            Description = request.Description,
            Link = request.Link,
            Type = request.Type,
        };
        return Ok(response);
    }

    [HttpGet("/resources")]
    public async Task<ActionResult> GetResources()
    {
        var items = await _context.Items
            .Select(item => new GetResourceItem
            {
                Id = item.Id.ToString(),
                Description = item.Description,
                Link = item.Link,
                Type = item.Type
            }).ToListAsync();

        var response = new GetResourcesResponse { Items = items };
        return Ok(response);
    }
}