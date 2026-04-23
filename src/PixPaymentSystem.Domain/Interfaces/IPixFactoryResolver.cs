using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Domain.Interfaces;

/// <summary>
/// Interface responsável por resolver a fábrica de transações Pix com base no tipo de Pix e no contexto fornecido.
/// </summary>
public interface IPixFactoryResolver
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tipo"></param>
    /// <returns></returns>
    IPixFactory Criar(TipoPix tipo);
}
