using CacauShowApi324133124.Data;
using CacauShowApi324133124.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CacauShowApi324133124.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LotesController : ControllerBase
{
    private readonly AppDbContext context;
    public LotesController(AppDbContext ctx){
        context = ctx;
    }
    [HttpGet]
    public async Task<ActionResult> Get(){
        var lotes = context.Lotes.ToList();
        return Ok(lotes);
    }

    [HttpPost]
    public async Task<ActionResult> Post(LoteProducao lote){
        if (context.Produtos.AnyAsync(p => p.Id == lote.ProdutoId) == null) return BadRequest("Este produto não existe.");
        else if (lote.DataFabricacao > DateTime.Now) return Conflict("Lote inválido: Data de fabricação não pode ser maior que a data atual.");
        context.Lotes.Add(lote);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), lote);
    }

    [HttpPatch]
    public async Task<ActionResult> Patch(LoteProducao lote)
    {
        var loteCache = context.Lotes.FirstOrDefault(l => l.Id == lote.Id);
        if (loteCache == null) return BadRequest("Este lote não existe.");
        else if (loteCache.Status.ToLower().Equals("descartado")) return BadRequest("Um lote descartado não pode ser alterado.");
        context.Lotes.Update(lote);
        await context.SaveChangesAsync();
        return Ok();
    }
}
