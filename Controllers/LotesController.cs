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
        var lotes = context.LotesProducao.ToList();
        return Ok(lotes);
    }

    [HttpPost]
    public async Task<ActionResult> Post(LoteProducao lote){
        var produtoExiste = await context.Produtos.AnyAsync(p => p.Id == lote.ProdutoId);
        if (!produtoExiste)
            return BadRequest("Este produto não existe.");
        if (lote.DataFabricacao > DateTime.Now)
            return Conflict("Lote inválido: Data de fabricação não pode ser maior que a data atual.");
        context.LotesProducao.Add(lote);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), lote);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> Patch(int id, [FromBody] string novoStatus)
    {
        var lote = await context.LotesProducao.FirstOrDefaultAsync(l => l.Id == id);
        if (lote == null) return BadRequest("Este lote não existe.");
        if (lote.Status.ToLower() == "descartado")
        {
            // Não pode voltar para nenhum status
            return BadRequest("Um lote descartado não pode ter seu status alterado.");
        }
        lote.Status = novoStatus;
        await context.SaveChangesAsync();
        return Ok(lote);
    }
}
