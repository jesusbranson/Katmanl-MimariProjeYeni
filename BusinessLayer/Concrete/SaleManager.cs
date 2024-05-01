using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SaleManager : ISaleService
    {
        ISaleDal _saleDal;

        public SaleManager(ISaleDal saleDal)
        {
            _saleDal = saleDal;
        }

        public List<Sale> GetSalesListWithProductCustomer()
        {
            return _saleDal.GetSaleListWithProductCustomer();
        }

        public void TDelete(Sale t)
        {

            _saleDal.Delete(t);
        }

        public Sale TGetByID(int id)
        {
            return _saleDal.GetById(id);
        }

        public List<Sale> TGetList()
        {
            return _saleDal.GetList();
        }

        public void TInsert(Sale t)
        {
            _saleDal.Insert(t);
        }

        public void TUpdate(Sale t)
        {
            _saleDal.Update(t);
        }
    }
}
