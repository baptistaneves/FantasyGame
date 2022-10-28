namespace FantasyGame.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> Salvar(CancellationToken cancellationToken);
    }
}
