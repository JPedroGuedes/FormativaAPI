using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormativaAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class AvaliacaoController : ControllerBase
{
    private readonly IAvaliacaoRepositorio _avaliacaoRepositorio;

    public AvaliacaoController(IAvaliacaoRepositorio avaliacaoRepositorio)
    {
        _avaliacaoRepositorio = avaliacaoRepositorio;
    }

    [HttpPost]
    public async Task<ActionResult<AvaliacaoModel>> Create([FromBody] AvaliacaoModel avaliacaoModel)
    {
        AvaliacaoModel avaliacao = await _avaliacaoRepositorio.Create(avaliacaoModel);
        return Ok(avaliacao);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AvaliacaoModel>> Read(int id)
    {
        AvaliacaoModel avaliacao = await _avaliacaoRepositorio.Read(id);

        return Ok(avaliacao);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AvaliacaoModel>> Update(int id, [FromBody] AvaliacaoModel avaliacaoModel)
    {
        avaliacaoModel.Id = id;
        AvaliacaoModel avaliacao = await _avaliacaoRepositorio.Update(avaliacaoModel, id);
        return Ok(avaliacao);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<AvaliacaoModel>> Delete(int id)
    {
        bool apagado = await _avaliacaoRepositorio.Delete(id);
        return Ok(apagado);
    }

    [HttpGet]
    public async Task<ActionResult<List<AvaliacaoModel>>> ReadAll()
    {
        List<AvaliacaoModel> avaliacoes = await _avaliacaoRepositorio.ReadAll();
        return Ok(avaliacoes);
    }
}