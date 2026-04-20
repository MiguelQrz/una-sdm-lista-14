using CacauShowApi324133124.Data;
using CacauShowApi324133124.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CacauShowApi324133124.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext context;
    public ProdutosController(AppDbContext ctx){
        context = ctx;
    }
    [HttpGet]
    public async Task<ActionResult> Get(){
        var produtos = context.Produtos.ToList();
        return Ok(produtos);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Produto produto){
        context.Produtos.Add(produto);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), produto);
    }
}
