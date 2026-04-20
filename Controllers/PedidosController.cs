using CacauShowApi324133124.Data;
using CacauShowApi324133124.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CacauShowApi324133124.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly AppDbContext context;
    public PedidosController(AppDbContext ctx){
        context = ctx;
    }
    [HttpGet]
    public async Task<ActionResult> Get(){
        var pedidos = context.Pedidos.ToList();
        return Ok(pedidos);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Pedido pedido){
        var produto = context.Produtos.AnyAsync(p => p.Id == pedido.ProdutoId);
        if (produto == null) return BadRequest("Este produto não existe.");
        var quantidadeTotal = context.Pedidos
        .Where(p => p.ProdutoId.Equals(pedido.ProdutoId) && p.UnidadeId == pedido.UnidadeId)
        .Sum(p => p.Quantidade);
        var unidade = context.Franquias.AnyAsync(f => f.Id == pedido.UnidadeId);
        context.Pedidos.Add(pedido);

        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), pedido);
    }
}
