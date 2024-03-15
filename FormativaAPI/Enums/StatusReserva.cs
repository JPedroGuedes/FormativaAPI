using System.ComponentModel;

namespace FormativaAPI.Enums;

public enum StatusReserva
{
    [Description("Disponível")]
    Disponivel = 1,
    [Description("Reservado")]
    Reservado = 2
}