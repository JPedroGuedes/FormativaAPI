using FormativaAPI.Data;
using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormativaAPI.Repositorios;

public class EmprestimoRepositorio : IEmprestimoRepositorio
{
    private readonly SistemaBibliotecaDBContex _dbContext;    
    public EmprestimoRepositorio(SistemaBibliotecaDBContex SistemaBibliotecaDBContex)
    {
        _dbContext = SistemaBibliotecaDBContex;
    }
    public async Task<EmprestimoModel> Create(EmprestimoModel emprestimo)
    {
        await _dbContext.Emprestimos.AddAsync(emprestimo);
        await _dbContext.SaveChangesAsync();

        return emprestimo;
    }

    public async Task<EmprestimoModel> Read(int id)
    {
        return await _dbContext.Emprestimos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<EmprestimoModel> Update(EmprestimoModel emprestimo, int id)
    {
        EmprestimoModel emprestimoPorId = await Read(id);


        if (emprestimoPorId == null)
        {
            throw new Exception($"Avaliacao do ID: {id} não foi encontrado");
        }
        
        emprestimoPorId.DataEmprestimo = emprestimo.DataEmprestimo;
        emprestimoPorId.DataDevolucao = emprestimo.DataDevolucao;
        emprestimoPorId.Status = emprestimo.Status;

        _dbContext.Emprestimos.Update(emprestimoPorId);
        await _dbContext.SaveChangesAsync();

        return emprestimoPorId;
    }

    public async Task<bool> Delete(int id)
    {
        EmprestimoModel emprestimoPorId = await Read(id);
        if (emprestimoPorId == null)
        {
            throw new Exception($"Editora do Id: {id} não foi encontrado");
        }

        _dbContext.Emprestimos.Remove(emprestimoPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<EmprestimoModel>> ReadAll()
    {
        return await _dbContext.Emprestimos.ToListAsync();
    }
}