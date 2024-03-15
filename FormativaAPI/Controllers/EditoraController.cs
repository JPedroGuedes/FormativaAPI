using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormativaAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class EditoraController : ControllerBase
{
    private readonly IEditoraRepositorio _editoraRepositorio;

    public EditoraController(IEditoraRepositorio editoraRepositorio)
    {
        _editoraRepositorio = editoraRepositorio;
    }

    [HttpPost]
    public async Task<ActionResult<EditoraModel>> Create([FromBody] EditoraModel editoraModel)
    {
        EditoraModel editora = await _editoraRepositorio.Create(editoraModel);
        return Ok(editora);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EditoraModel>> Read(int id)
    {
        EditoraModel editora = await _editoraRepositorio.Read(id);

        return Ok(editora);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EditoraModel>> Update(int id, [FromBody] EditoraModel editoraModel)
    {
        editoraModel.Id = id;
        EditoraModel editora = await _editoraRepositorio.Update(editoraModel, id);
        return Ok(editora);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<EditoraModel>> Delete(int id)
    {
        bool apagado = await _editoraRepositorio.Delete(id);
        return Ok(apagado);
    }

    [HttpGet]
    public async Task<ActionResult<List<EditoraModel>>> ReadAll()
    {
        List<EditoraModel> editoras = await _editoraRepositorio.ReadAll();
        return Ok(editoras);
    }
}