namespace travel_api.Repositories
{
    public interface IBaseRepo<TEntity, TEntityDTO, TEntityRequest, TKey> 
        where TEntity : class 
        where TEntityDTO : class
        where TEntityRequest : class
        where TKey : struct
    {
        Task<IEnumerable<TEntityDTO>> GetAllAsync();
        Task<TEntityDTO> GetByIdAsync(TKey id);
        Task<TEntityDTO> AddAsync(TEntityRequest entityDto);
        Task<TEntityDTO> UpdateAsync(TEntityRequest entityDto);
        Task<TEntityDTO> DeleteAsync(TKey id);
        Task<bool> IsEntityExistAsync(TKey id);
    }
}
