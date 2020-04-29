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
    public class Customer
    {
        public string CustomerID { get; set; }
        public string Name { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.None),Key,XmlIgnore]
        public int OrderID { get; set; }
        [XmlIgnore]
        public Order Order { get; set; }

        public Customer() { }

        public Customer(string ID, string name)
        {
            CustomerID = ID;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            return customer != null &&
                   CustomerID == customer.CustomerID &&
                   Name == customer.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 1479869798;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
