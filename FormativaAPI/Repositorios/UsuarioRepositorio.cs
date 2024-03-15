using FormativaAPI.Data;
using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormativaAPI.Repositorios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly SistemaBibliotecaDBContex _dbContext;    
    public UsuarioRepositorio(SistemaBibliotecaDBContex SistemaBibliotecaDBContex)
    {
        _dbContext = SistemaBibliotecaDBContex;
    }
    public async Task<UsuarioModel> Create(UsuarioModel usuario)
    {
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();

        return usuario;
    }

    public async Task<UsuarioModel> Read(int id)
    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UsuarioModel> Update(UsuarioModel usuario, int id)
    {
        UsuarioModel usuarioPorId = await Read(id);


        if (usuarioPorId == null)
        {
            throw new Exception($"Livro do ID: {id} não foi encontrado");
        }
        
        usuarioPorId.Email = usuario.Email;
        usuarioPorId.Senha = usuario.Senha;

        _dbContext.Usuarios.Update(usuarioPorId);
        await _dbContext.SaveChangesAsync();

        return usuarioPorId;
    }

    public async Task<bool> Delete(int id)
    {
        UsuarioModel usuarioPorId = await Read(id);
        if (usuarioPorId == null)
        {
            throw new Exception($"Reserva do Id: {id} não foi encontrado");
        }

        _dbContext.Usuarios.Remove(usuarioPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<UsuarioModel>> ReadAll()
    {
        return await _dbContext.Usuarios.ToListAsync();
    }
}