using FormativaAPI.Models;

namespace FormativaAPI.Repositorios.Interfaces;

public interface IReservaRepositorio
{
    Task<ReservaModel> Create(ReservaModel reserva);
    Task<ReservaModel> Read(int id);
    Task<ReservaModel> Update(ReservaModel reserva, int id);
    Task<bool> Delete(int id);
    Task<List<ReservaModel>> ReadAll();
}