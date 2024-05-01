using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatmanlıMimariProje.Models
{
    public class SaleProductCustomerViewModel
    {
        public Sale Sale { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public DateTime SaleDate { get; set; }
        

    }
}
