using FormativaAPI.Data;
using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormativaAPI.Repositorios;

public class AvaliacaoRepositorio : IAvaliacaoRepositorio
{
    private readonly SistemaBibliotecaDBContex _dbContext;    
    public AvaliacaoRepositorio(SistemaBibliotecaDBContex SistemaBibliotecaDBContex)
    {
        _dbContext = SistemaBibliotecaDBContex;
    }
    public async Task<AvaliacaoModel> Create(AvaliacaoModel avaliacao)
    {
        await _dbContext.Avaliacaos.AddAsync(avaliacao);
        await _dbContext.SaveChangesAsync();

        return avaliacao;
    }

    public async Task<AvaliacaoModel> Read(int id)
    {
        return await _dbContext.Avaliacaos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<AvaliacaoModel> Update(AvaliacaoModel avaliacao, int id)
    {
        AvaliacaoModel avaliacaoPorId = await Read(id);


        if (avaliacaoPorId == null)
        {
            throw new Exception($"Avaliacao do ID: {id} não foi encontrado");
        }
        
        avaliacaoPorId.Pontuacao = avaliacao.Pontuacao;
        avaliacaoPorId.Comentario = avaliacao.Comentario;
        avaliacaoPorId.DataAvaliacao = avaliacao.DataAvaliacao;

        _dbContext.Avaliacaos.Update(avaliacaoPorId);
        await _dbContext.SaveChangesAsync();

        return avaliacaoPorId;
    }

    public async Task<bool> Delete(int id)
    {
        AvaliacaoModel avaliacaoPorId = await Read(id);
        if (avaliacaoPorId == null)
        {
            throw new Exception($"Avaliacao do Id: {id} não foi encontrado");
        }

        _dbContext.Avaliacaos.Remove(avaliacaoPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<AvaliacaoModel>> ReadAll()
    {
        return await _dbContext.Avaliacaos.ToListAsync();
    }
}