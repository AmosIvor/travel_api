namespace travel_api.Repositories
{
    public interface IBaseRepo<TEntity, TEntityDTO, TKey> 
        where TEntity : class 
        where TEntityDTO : class
        where TKey : struct
    {
        Task<IEnumerable<TEntityDTO>> GetAllAsync();
        Task<TEntityDTO> GetByIdAsync(TKey id);
        Task<TEntityDTO> AddAsync(TEntityDTO entityDto);
        Task<TEntityDTO> UpdateAsync(TEntityDTO entityDto);
        Task<TEntityDTO> DeleteAsync(TKey id);
        Task<bool> IsEntityExistAsync(TKey id);
    }
}
