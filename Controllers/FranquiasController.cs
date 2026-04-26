using CacauShowApi324133124.Data;
using CacauShowApi324133124.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CacauShowApi324133124.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FranquiasController : ControllerBase
{
    private readonly AppDbContext context;
    public FranquiasController(AppDbContext ctx){
        context = ctx;
    }
    [HttpGet]
    public async Task<ActionResult> Get(){
        var franquias = await context.Franquias.ToListAsync();
        return Ok(franquias);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Franquia franquia){
        context.Franquias.Add(franquia);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), franquia);
    }
}
