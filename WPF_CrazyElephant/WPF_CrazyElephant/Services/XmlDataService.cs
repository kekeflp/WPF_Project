using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using WPF_CrazyElephant.Models;

namespace WPF_CrazyElephant.Services
{
    public class XmlDataService : IDataService
    {
        public List<Dish> GetAllDishes()
        {
            List<Dish> dishList = new List<Dish>();
            var xmlFileName = Path.Combine(Environment.CurrentDirectory, "Data/Data.xml");
            // 访问xml文件，优先推荐使用XDocument，    （XmlDocument已过时）
            XDocument doc = XDocument.Load(xmlFileName);
            // 调用父类的Descendants(XName? name)的方法, 来获取xml文档中的后代集合Enumerable<XElement>
            var dishes = doc.Descendants("Dish");
            foreach (var item in dishes)
            {
                Dish dish = new Dish
                {
                    // 从XElement中的取元素名对应的值
                    Name = item.Element("Name").Value,
                    Category = item.Element("Category").Value,
                    Comment = item.Element("Comment").Value,
                    Score = decimal.Parse(item.Element("Score").Value)
                };
                dishList.Add(dish);
            }
            return dishList;
        }
    }
}
