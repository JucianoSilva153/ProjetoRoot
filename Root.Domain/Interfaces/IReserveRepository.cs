using Root.Domain.Entities;

namespace Root.Domain.Interfaces;

public interface IReserveRepository : IRepository<Reserve>
{
    public Task<bool> CancelReserveAsync(Guid reserveId);
}