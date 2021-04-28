using WPF_CoronavirusChart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WPF_CoronavirusChart.Services
{
    public interface ICoronavirusService
    {
        // 获取一组国家数据，并且获取TopN的数据
        // 1、需要一个集合，2、需要国家对象，3、需要传入参数N
        Task<IEnumerable<CoronavirusCountry>> GetCoronavirusCountriesAsync(int n);
    }
}
