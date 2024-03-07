
namespace App.Services.RefundServices
{
    public interface IDataRefundServices<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetByPage (int page);
    }
}
