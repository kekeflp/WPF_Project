using System.Collections.Generic;
using WPF_CrazyElephant.Models;

namespace WPF_CrazyElephant.Services
{
    public interface IDataService
    {
        List<Dish> GetAllDishes();
    }
}
