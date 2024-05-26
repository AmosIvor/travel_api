using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Exceptions;
using travel_api.Repositories;

namespace travel_api.Services
{
    public class BaseRepo<TEntity, TEntityDTO, TKey> : IBaseRepo<TEntity, TEntityDTO, TKey>
        where TEntity : class
        where TEntityDTO : class
        where TKey : struct
    {
        protected readonly DataContext _context;
        private DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;

        public BaseRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<TEntityDTO>> GetAllAsync()
        {
            var entityList = await _dbSet.ToListAsync();

            var entityListDto = _mapper.Map<IEnumerable<TEntityDTO>>(entityList);

            return entityListDto;
        }

        public async Task<TEntityDTO> GetByIdAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                throw new NotFoundException("Entity not found");
            }

            var entityDtoResult = _mapper.Map<TEntityDTO>(entity);

            return entityDtoResult;
        }

        public async Task<TEntityDTO> AddAsync(TEntityDTO entityDto)
        {
            // mapper
            var entity = _mapper.Map<TEntity>(entityDto);

            _dbSet.Add(entity);

            await _context.SaveChangesAsync();

            var entityDtoResult = _mapper.Map<TEntityDTO>(entity);

            return entityDtoResult;
        }

        public async Task<TEntityDTO> UpdateAsync(TEntityDTO entityDto)
        {
            // mapper
            var entity = _mapper.Map<TEntity>(entityDto);

            _dbSet.Update(entity);

            await _context.SaveChangesAsync();

            var entityDtoResult = _mapper.Map<TEntityDTO>(entity);

            return entityDtoResult;
        }

        public async Task<TEntityDTO> DeleteAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                throw new NotFoundException("Entity not found");
            }

            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();

            // mapper result
            var entityDtoResult = _mapper.Map<TEntityDTO>(entity);

            return entityDtoResult;
        }

        public async Task<bool> IsEntityExistAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);

            return entity != null;
        }
    }
}
