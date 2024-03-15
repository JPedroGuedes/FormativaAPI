using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormativaAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class LivroController : ControllerBase
{
    private readonly ILivroRepositorio _livroRepositorio;

    public LivroController(ILivroRepositorio livroRepositorio)
    {
        _livroRepositorio = livroRepositorio;
    }

    [HttpPost]
    public async Task<ActionResult<LivroModel>> Create([FromBody] LivroModel livroModel)
    {
        LivroModel livro = await _livroRepositorio.Create(livroModel);
        return Ok(livro);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LivroModel>> Read(int id)
    {
        LivroModel livro = await _livroRepositorio.Read(id);

        return Ok(livro);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<LivroModel>> Update(int id, [FromBody] LivroModel livroModel)
    {
        livroModel.Id = id;
        LivroModel livro = await _livroRepositorio.Update(livroModel, id);
        return Ok(livro);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<LivroModel>> Delete(int id)
    {
        bool apagado = await _livroRepositorio.Delete(id);
        return Ok(apagado);
    }

    [HttpGet]
    public async Task<ActionResult<List<LivroModel>>> ReadAll()
    {
        List<LivroModel> livros = await _livroRepositorio.ReadAll();
        return Ok(livros);
    }
}