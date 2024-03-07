namespace App.Services.SavedOrderSvercies
{
    public interface ISavedOrder : IEmpty
    {
        Task<List<InventoryOrder>> GetAll();
        Task<InventoryOrder> Get(int id);
        Task<bool> Remove(int id);
        Task<bool> UpdateOrder(InventoryOrder order);
        Task <bool> Add(InventoryOrder order);
        Task Save();
    }
}
