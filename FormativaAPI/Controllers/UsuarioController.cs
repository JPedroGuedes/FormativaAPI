using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormativaAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioModel>> Create([FromBody] UsuarioModel usuarioModel)
    {
        UsuarioModel usuario = await _usuarioRepositorio.Create(usuarioModel);
        return Ok(usuario);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioModel>> Read(int id)
    {
        UsuarioModel usuario = await _usuarioRepositorio.Read(id);

        return Ok(usuario);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UsuarioModel>> Update(int id, [FromBody] UsuarioModel usuarioModel)
    {
        usuarioModel.Id = id;
        UsuarioModel usuario = await _usuarioRepositorio.Update(usuarioModel, id);
        return Ok(usuario);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UsuarioModel>> Delete(int id)
    {
        bool apagado = await _usuarioRepositorio.Delete(id);
        return Ok(apagado);
    }

    [HttpGet]
    public async Task<ActionResult<List<UsuarioModel>>> ReadAll()
    {
        List<UsuarioModel> usuarios = await _usuarioRepositorio.ReadAll();
        return Ok(usuarios);
    }
}