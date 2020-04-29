using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderApp
{
    public class Goods
    {
        public string GoodID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None), Key, Column(Order = 1),XmlIgnore] //取消自增
        public int OrderItemID { get; set; }
        [XmlIgnore]
        public OrderItem OrderItem { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None), Key, Column(Order = 0),XmlIgnore]
        public int OrderID { get; set; }
        [XmlIgnore]
        public Order Order { get; set; }

        public Goods() { }

        public Goods(string iD, string name, double price)
        {
            GoodID = iD;
            Name = name;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null &&
                   GoodID == goods.GoodID &&
                   Name == goods.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 1479869798;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
