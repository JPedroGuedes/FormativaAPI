using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormativaAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class EmprestimoController : ControllerBase
{
    private readonly IEmprestimoRepositorio _emprestimoRepositorio;

    public EmprestimoController(IEmprestimoRepositorio emprestimoRepositorio)
    {
        _emprestimoRepositorio = emprestimoRepositorio;
    }

    [HttpPost]
    public async Task<ActionResult<EmprestimoModel>> Create([FromBody] EmprestimoModel emprestimoModel)
    {
        EmprestimoModel emprestimo = await _emprestimoRepositorio.Create(emprestimoModel);
        return Ok(emprestimo);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmprestimoModel>> Read(int id)
    {
        EmprestimoModel emprestimo = await _emprestimoRepositorio.Read(id);

        return Ok(emprestimo);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EmprestimoModel>> Update(int id, [FromBody] EmprestimoModel emprestimoModel)
    {
        emprestimoModel.Id = id;
        EmprestimoModel emprestimo = await _emprestimoRepositorio.Update(emprestimoModel, id);
        return Ok(emprestimo);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<EmprestimoModel>> Delete(int id)
    {
        bool apagado = await _emprestimoRepositorio.Delete(id);
        return Ok(apagado);
    }

    [HttpGet]
    public async Task<ActionResult<List<EmprestimoModel>>> ReadAll()
    {
        List<EmprestimoModel> emprestimos = await _emprestimoRepositorio.ReadAll();
        return Ok(emprestimos);
    }
}