namespace HrmUi.IService
{
    public interface IApiService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(string endpoint);
        Task<T> GetAsync<T>(string endpoint);
        Task<T> PostAsync<T>(string endpoint, T TRequest);
        Task<T> PutAsync<T>(string endpoint, T TRequest);
        Task<bool> DeleteAsync<T>(string endpoint);

    }
}
