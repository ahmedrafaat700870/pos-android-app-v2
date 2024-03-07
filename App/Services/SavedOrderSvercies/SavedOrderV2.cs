namespace App.Services.SavedOrderSvercies
{
    public class SavedOrderV2 : ISavedOrder
    {
        private List<InventoryOrder> orders;
        public SavedOrderV2()
        {
            orders = new List<InventoryOrder>();
        }
        public async Task<bool> Add(InventoryOrder order)
        {
            if (order.Id == 0)
                order.Id = this.orders.LastOrDefault() is null ? 1 : this.orders.LastOrDefault().Id + 1;
            order.SavedOrderDate = DateTime.Now;
            orders.Add(order);
            return true;
        }

        public async Task<InventoryOrder> Get(int id)
        {
            var order = orders.FirstOrDefault(x => x.Id == id) ?? null;
            return order;
        }

        public async Task<List<InventoryOrder>> GetAll()
        {
            return this.orders.OrderBy(x =>x.Id).ToList();
        }

        public bool IsSavedOrdersEmpty()
        {
            return this.orders.Count == 0;
        }

        public async Task<bool> Remove(int id)
        {
            for (int i = 0; i < this.orders.Count; i++)
                if (orders[i].Id == id)
                {
                    orders.Remove(orders[i]);
                    return true;
                }
            return false;
        }

        public async Task Save()
        {

        }

        public async Task<bool> UpdateOrder(InventoryOrder order)
        {
            for (int i = 0; i < orders.Count; i++)
                if (orders[i].Id == order.Id)
                {
                    orders[i] = order;
                    return true;
                }
            return false;
        }
    }
}
