using CacauShowApi324133124.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace CacauShowApi324133124.Controllers;

[ApiController]
[Route("api/intelligence")]
public class ChocolateIntelligenceController : ControllerBase
{
    private readonly AppDbContext context;
    public ChocolateIntelligenceController(AppDbContext ctx){
        context = ctx;
    }

    [HttpGet("estoque-regional")]
    public async Task<ActionResult> EstoqueRegional()
    {
        Thread.Sleep(2000);
        var result = await context.Franquias
            .Select(f => new {
                Cidade = f.Cidade,
                ItensVendidos = context.Pedidos
                    .Where(p => p.UnidadeId == f.Id)
                    .Sum(p => p.Quantidade)
            })
            .GroupBy(x => x.Cidade)
            .Select(g => new { Cidade = g.Key, ItensVendidos = g.Sum(x => x.ItensVendidos) })
            .ToListAsync();
        return Ok(result);
    }
}
