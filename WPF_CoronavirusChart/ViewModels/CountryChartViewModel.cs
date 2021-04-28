using WPF_CoronavirusChart.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WPF_CoronavirusChart.ViewModels
{
    public class CountryChartViewModel
    {
        const int TopN = 10;
        // 国家名称
        public string[] CountryNames { get; set; }
        // 病例数
        //public ChartValues<long> CountryCaseCounts { get; set; }
        private ICoronavirusService _coronavirusService { get; set; }

        private CountryChartViewModel(ICoronavirusService coronavirusService)
        {
            _coronavirusService = coronavirusService;
            //Load();
        }

        // 谁能解释下这个函数的思路
        //public static CountryChartViewModel LoadViewModel(ICoronavirusService coronavirusService, Action<Task> action = null)
        //{
        //    CountryChartViewModel ccvm = new CountryChartViewModel(coronavirusService);
        //    //ccvm.Load().ContinueWith(t => action?.Invoke(t));
        //    ccvm.Load().ContinueWith(c => action?.Invoke(c));
        //    return ccvm;
        //}

        //private async Task Load()
        //{
        //    //var countries = await _coronavirusService.GetCoronavirusCountriesAsync(TopN);
        //    //CountryNames = countries.Select(c => c.Country).ToArray();
        //    //CountryCaseCounts = new ChartValues<long>(countries.Select(c => c.Cases));
        //    //测试数据
        //    CountryNames = new string[] { "中国", "美国", "日本", "俄罗斯", "法国", "英国", "德国", "葡萄牙", "西班牙", "巴西" };
        //    //CountryCaseCounts = new ChartValues<long>() { 8000, 6656460, 586712, 666997, 322540, 300770, 4788897, 4644460, 222547, 3000004 };
        //}

    }
}
