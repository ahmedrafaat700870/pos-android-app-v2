namespace App.LocalDB
{
    public class Sql_Lite_LocalDB
    {
        private SQLiteAsyncConnection Database = null!;

        private async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<SettingsModel>();
            await Database.CreateTableAsync<InventoryOrder>();
            await Database.EnableWriteAheadLoggingAsync();
        }

        public async Task<int> SaveOrderAsync(InventoryOrder order)
        {
            await Init();
            if (order.Id == 0)
                return await Database.InsertAsync(order);
            else
                return await Database.UpdateAsync(order);
        }
        public async Task<List<InventoryOrder>> GetAllOrders ()  
        {
            await Init();
            var data = await Database.Table<InventoryOrder>().ToListAsync();
            return data;
        }

        public async Task<InventoryOrder> GetOrder(int id)
        {
            await Init();
            var data = await Database.Table<InventoryOrder>().FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<int> UpdateOrder(InventoryOrder order)
        {
            await Init();
            return await Database.UpdateAsync(order);
        }
        public async Task<int> RemoveOrder(InventoryOrder order)
        {
            await Init();
            return await Database.DeleteAsync(order);
        }




        public async Task<List<SettingsModel>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<SettingsModel>().ToListAsync();
        }

        public async Task UpdateItem(SettingsModel item)
        {
            await Init();
            await Database.UpdateAsync(item);
        }

        public async Task<SettingsModel> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<SettingsModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(SettingsModel item)
        {
            await Init();
            if (item.Id != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(SettingsModel item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }



    }


}
