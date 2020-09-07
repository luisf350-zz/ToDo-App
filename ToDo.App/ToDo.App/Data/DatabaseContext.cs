using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ToDo.App.Models;

namespace ToDo.App.Data
{
    public class DatabaseContext
    {
        public SQLiteAsyncConnection Connection { get; set; }

        public DatabaseContext(string path)
        {
            Connection = new SQLiteAsyncConnection(path);
            Connection.CreateTableAsync<TodoItem>().Wait();
        }

        public async Task<int> InsertItemAsycn(TodoItem item)
        {
            return await Connection.InsertAsync(item);
        }

        public async Task<List<TodoItem>> GetItemsAsync()
        {
            return await Connection.Table<TodoItem>().ToListAsync();
        }

        public async Task<int> DeleteItemAsync(TodoItem item)
        {
            return await Connection.DeleteAsync(item);
        }
    }
}
