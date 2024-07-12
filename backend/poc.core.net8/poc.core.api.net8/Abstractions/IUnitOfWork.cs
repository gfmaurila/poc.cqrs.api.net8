namespace poc.core.api.net8.Abstractions;

/// <summary>
/// Unidade de Trabalho.
/// Responsável por salvar as alterações na base de escrita e disparar os eventos.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
}

