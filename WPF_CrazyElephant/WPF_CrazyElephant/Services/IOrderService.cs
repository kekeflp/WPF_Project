using System.Collections.Generic;
using WPF_CrazyElephant.Models;

namespace WPF_CrazyElephant.Services
{
    /// <summary>
    /// 虚拟的下订单接口
    /// </summary>
    public interface IOrderService
    {
        void PlaceOrder(List<string> dishes);
        void PlaceOrderDish(List<Dish> dishes);
    }
}
