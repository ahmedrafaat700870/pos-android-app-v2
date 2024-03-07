namespace App.Services.SavedOrderSvercies
{
    public class SavedOrder : ISavedOrder
    {
        private const string FileName = "orders.txt";
        private List<InventoryOrder> orders;
        private ReadAndWriteFile readAndWriteFile;

        private async Task<List<InventoryOrder>> GetOrders()
        {
            if (orders is null)
            {
                var stringOrders = await GetReadWriteFile().ReadTextFileAsync(FileName);
                if (string.IsNullOrEmpty(stringOrders))
                {
                    orders = new List<InventoryOrder>();
                }
                else
                {
                    orders = JsonConvert.DeserializeObject<List<InventoryOrder>>(stringOrders);
                }
            }
            return orders ?? new List<InventoryOrder>();
        }

        private ReadAndWriteFile GetReadWriteFile()
        {
            if (readAndWriteFile is null)
                readAndWriteFile = new ReadAndWriteFile();
            return this.readAndWriteFile;
        }

        public async Task<InventoryOrder> Get(int id)
        {
            var order = (await GetOrders()).FirstOrDefault(x => x.Id == id) ?? null;
            return order;
        }

        public async Task<List<InventoryOrder>> GetAll()
        {
            return await GetOrders();
        }

        public async Task< bool> UpdateOrder(InventoryOrder order)
        {
            int count = (await GetOrders()).Count;
            for (int i = 0; i < count; i++)
            {
                if (orders[i].Id == order.Id)
                {
                    orders[i] = order;
                    return true; ;
                }
            }
            return false;
        }

        public async Task<bool> Remove(int id)
        {
            var reomvedItem = await Get(id);
            var count = (await GetOrders()).Remove(reomvedItem);
            return count;
        }

        public async Task Save()
        {
            var stringContent = JsonConvert.SerializeObject(GetOrders());
            await GetReadWriteFile().WirteTextToFileAsync(stringContent, FileName);
        }

        public async Task<bool> Add(InventoryOrder order)
        {
            var orders = await GetOrders();
            if(order.Id == 0)
            {
                // add 
                this.orders.Add(order);
                return true;
            } else
            {
                // update
                await UpdateOrder(order);
                return true;
            }
        }

        public bool IsSavedOrdersEmpty()
        {
            return this.orders.Count == 0;
        }
    }
}
