using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Sale
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

    }
}
