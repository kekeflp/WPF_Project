using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models.API;

namespace WPF_SimpleTrader.Domain.Services
{
    public interface IMajorindexService
    {
        Task<Majorindex> GetMajorindices(MajorindexType indexType);
    }
}
