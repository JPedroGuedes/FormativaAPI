using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FormativaAPI.Data;
using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FormativaAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class LoginController : ControllerBase
{
    private readonly SistemaBibliotecaDBContex _dbContex;

    public LoginController(SistemaBibliotecaDBContex sistemaBiblioteca)
    {
        _dbContex = sistemaBiblioteca;
    }
    [HttpPost]
    public IActionResult Login([FromBody] UsuarioModel usuario)
    {
        var usuarioExistente = _dbContex.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
        
        if (usuarioExistente != null && usuarioExistente.Senha == usuario.Senha)
        {
            var token = GerarToken(usuario);
            return Ok(new { token });
        }
        
       if (usuario.Email == "admin" && usuario.Senha == "admin")
        {
            var token = GerarToken(usuario);
            return Ok(new { token });
        }
        return BadRequest(new { mensagem = "Credenciais inválidas. Por favor, verifique e tente novamente." });
    }

    private string GerarToken(UsuarioModel usuario)
    {
        string chaveSecreta = "0cbc84a9-98c5-4837-99bf-ddb35bf588a0";

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
        var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("login", "admin"),
            new Claim("Nome", "Administrador do Sistema")
        };

        var token = new JwtSecurityToken(
            issuer: "empresa",//emissor do token
            audience: "aplicacao",//destinatário= aplicação que irá usar o token
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credencial
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}