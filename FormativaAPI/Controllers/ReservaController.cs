using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormativaAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class ReservaController : ControllerBase
{
    private readonly IReservaRepositorio _reservaRepositorio;

    public ReservaController(IReservaRepositorio reservaRepositorio)
    {
        _reservaRepositorio = reservaRepositorio;
    }

    [HttpPost]
    public async Task<ActionResult<ReservaModel>> Create([FromBody] ReservaModel reservaModel)
    {
        ReservaModel reserva = await _reservaRepositorio.Create(reservaModel);
        return Ok(reserva);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReservaModel>> Read(int id)
    {
        ReservaModel reserva = await _reservaRepositorio.Read(id);

        return Ok(reserva);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReservaModel>> Update(int id, [FromBody] ReservaModel reservaModel)
    {
        reservaModel.Id = id;
        ReservaModel reserva = await _reservaRepositorio.Update(reservaModel, id);
        return Ok(reserva);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ReservaModel>> Delete(int id)
    {
        bool apagado = await _reservaRepositorio.Delete(id);
        return Ok(apagado);
    }

    [HttpGet]
    public async Task<ActionResult<List<ReservaModel>>> ReadAll()
    {
        List<ReservaModel> reservas = await _reservaRepositorio.ReadAll();
        return Ok(reservas);
    }
}