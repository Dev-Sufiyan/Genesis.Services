using Genesis.Repositories;
using Genesis.Models.DTO;

namespace Genesis.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected readonly IRepositoriesBase<T> _repository;

        public ServiceBase(IRepositoriesBase<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetRecordsAsync(List<SearchParam> searchParams)
        {
            return await _repository.GetRecordsAsync(searchParams);
        }

        public async Task<T> GetByPKAsync(object keyValue)
        {
            return await _repository.GetByPKAsync(keyValue);
        }

        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task SaveRecordsAsync(IEnumerable<T> records)
        {
            await _repository.SaveRecordsAsync(records);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteByPKAsync(object keyValue)
        {
            await _repository.DeleteByPKAsync(keyValue);
        }

        public async Task DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<bool> IsRecordPresentAsync(T entity)
        {
            return await _repository.IsEntityExistAsync(entity);
        }
    }
}
