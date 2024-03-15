using System.ComponentModel;

namespace FormativaAPI.Enums;

public enum StatusEmprestimo
{
    [Description("Disponível")]
    Disponivel = 1,
    [Description("Aguardando")]
    Aguardando  = 2,
    [Description("Retirada")]
    Retirada  = 3,
    [Description("Emprestado")]
    Emprestado  = 4
    
}