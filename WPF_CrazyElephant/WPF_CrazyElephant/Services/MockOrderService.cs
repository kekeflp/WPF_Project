using System.Collections.Generic;
using System.IO;
using System.Text;
using WPF_CrazyElephant.Models;

namespace WPF_CrazyElephant.Services
{
    /// <summary>
    /// 虚拟下订单的方法
    /// </summary>
    public class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> dishes)
        {
            File.WriteAllLines("d:/order.txt", dishes.ToArray());
        }

        public void PlaceOrderDish(List<Dish> dishes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("菜名\t评分\r");
            foreach (var dish in dishes)
            {
                sb.AppendLine($"{dish.Name }\t{ dish.Score}");
            }
            File.WriteAllText("d:/order.txt", sb.ToString());
        }
    }
}
