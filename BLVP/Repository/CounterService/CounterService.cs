using BLVP.Database;
using BLVP.Entities;
using BLVP.Models;
using BLVP.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace BLVP.Repository.CounterService
{
    public class CounterService : ICounterService
    {
        private readonly MySQLContext dbContext;
        private static SemaphoreSlim _mutex = new SemaphoreSlim(1);
        public CounterService(MySQLContext mySQLContext)
        {
            dbContext = mySQLContext;
        }
        public async Task<CounterDTO> GetCounterByKey(string key)
        {
            var result = new CounterDTO();
            result.Key = key;
            var data = await dbContext.Counters.FirstOrDefaultAsync(x => x.Key == key);
            if (data != null)
            {
                result.CurrentCounter = data.Count;
                result.DisplayData = string.Format(data.Format, data.Count.ToString(data.NumberFormat));
            }

            return result;
        }

        public async Task IncreaseCounterAsync(CreateCounterModel model)
        {
            await _mutex.WaitAsync();
            dbContext.Database.EnsureCreated();
            var counter = await dbContext.Counters.FirstOrDefaultAsync(x => x.Key.Equals("PC_COUNTER_24"));
            if (counter != null)
            {
                counter.Count += 1;

            }
            //else
            //{
            //    dbContext.Add(new Counter
            //    {
            //        Key = model.Key,
            //        Count = 1,
            //        Format = model.Format,
            //        NumberFormat = model.NumberFormat
            //    });
            //}

            await dbContext.SaveChangesAsync();
            _mutex.Release();
        }

    }
}
