namespace movies.Domain.Repositories
{
    public interface ICrudRepository<TDomain, ID>
    {
        Task<IReadOnlyList<TDomain>> GetAllAsync();
    }
}
