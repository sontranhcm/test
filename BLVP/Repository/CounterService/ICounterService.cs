using BLVP.Models;
using BLVP.Models.Request;

namespace BLVP.Repository.CounterService
{
    public interface ICounterService
    {
        public Task IncreaseCounterAsync(CreateCounterModel model);
        public Task<CounterDTO> GetCounterByKey(string key);
    }
}
