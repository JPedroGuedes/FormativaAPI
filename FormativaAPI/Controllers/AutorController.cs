using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormativaAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class AutorController : ControllerBase
{
    private readonly IAutorRepositorio _autorRepositorio;

    public AutorController(IAutorRepositorio autorRepositorio)
    {
        _autorRepositorio = autorRepositorio;
    }

    [HttpPost]
    public async Task<ActionResult<AutorModel>> Create([FromBody] AutorModel autorModel)
    {
        AutorModel autor = await _autorRepositorio.Create(autorModel);
        return Ok(autor);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AutorModel>> Read(int id)
    {
        AutorModel autor = await _autorRepositorio.Read(id);

        return Ok(autor);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AutorModel>> Update(int id, [FromBody] AutorModel autorModel)
    {
        autorModel.Id = id;
        AutorModel autor = await _autorRepositorio.Update(autorModel, id);
        return Ok(autor);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<AutorModel>> Delete(int id)
    {
        bool apagado = await _autorRepositorio.Delete(id);
        return Ok(apagado);
    }

    [HttpGet]
    public async Task<ActionResult<List<AutorModel>>> ReadAll()
    {
        List<AutorModel> autores = await _autorRepositorio.ReadAll();
        return Ok(autores);
    }
}