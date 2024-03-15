using FormativaAPI.Data;
using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormativaAPI.Repositorios;

public class ReservaRepositorio : IReservaRepositorio
{
    private readonly SistemaBibliotecaDBContex _dbContext;    
    public ReservaRepositorio(SistemaBibliotecaDBContex SistemaBibliotecaDBContex)
    {
        _dbContext = SistemaBibliotecaDBContex;
    }
    public async Task<ReservaModel> Create(ReservaModel reserva)
    {
        await _dbContext.Reservas.AddAsync(reserva);
        await _dbContext.SaveChangesAsync();

        return reserva;
    }

    public async Task<ReservaModel> Read(int id)
    {
        return await _dbContext.Reservas.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ReservaModel> Update(ReservaModel reserva, int id)
    {
        ReservaModel reservaPorId = await Read(id);


        if (reservaPorId == null)
        {
            throw new Exception($"Livro do ID: {id} não foi encontrado");
        }
        
        reservaPorId.DataReserva = reserva.DataReserva;
        reservaPorId.Status = reserva.Status;

        _dbContext.Reservas.Update(reservaPorId);
        await _dbContext.SaveChangesAsync();

        return reservaPorId;
    }

    public async Task<bool> Delete(int id)
    {
        ReservaModel reservaPorId = await Read(id);
        if (reservaPorId == null)
        {
            throw new Exception($"Reserva do Id: {id} não foi encontrado");
        }

        _dbContext.Reservas.Remove(reservaPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<ReservaModel>> ReadAll()
    {
        return await _dbContext.Reservas.ToListAsync();
    }
}