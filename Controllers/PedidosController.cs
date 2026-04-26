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
        var produto = await context.Produtos.FirstOrDefaultAsync(p => p.Id == pedido.ProdutoId);
        if (produto == null) return BadRequest("Este produto não existe.");
        var unidade = await context.Franquias.FirstOrDefaultAsync(f => f.Id == pedido.UnidadeId);
        if (unidade == null) return BadRequest("Esta unidade não existe.");
        var quantidadeTotal = await context.Pedidos
            .Where(p => p.UnidadeId == pedido.UnidadeId)
            .SumAsync(p => p.Quantidade);
        if (quantidadeTotal + pedido.Quantidade > unidade.CapacidadeEstoque)
            return BadRequest("Capacidade logística da loja excedida. Não é possível receber mais produtos.");

        pedido.ValorTotal = produto.PrecoBase * pedido.Quantidade;
        if (produto.Tipo.ToLower() == "sazonal")
        {
            pedido.ValorTotal += 15.00m;
            Console.WriteLine("Produto sazonal detectado: Adicionando embalagem de presente premium!");
        }
        context.Pedidos.Add(pedido);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), pedido);
    }
}
