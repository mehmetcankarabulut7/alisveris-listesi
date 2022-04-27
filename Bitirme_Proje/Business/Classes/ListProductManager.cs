using Bitirme_Proje.Business.Interfaces;
using Bitirme_Proje.DataAccess.Interfaces;
using Bitirme_Proje.EntityFramework.Entities;
using System;

namespace Bitirme_Proje.Business.Classes
{
    public class ListProductManager : IListProductService
    {
        private IListProductDal _listProductDal;

        public ListProductManager(IListProductDal listProductDal)
        {
            _listProductDal = listProductDal;
        }

        public void Add(ListProduct listProduct)
        {
            _listProductDal.Add(listProduct);
        }

        public void Delete(int listId, int productId)
        {
            _listProductDal.Delete(listId, productId);
        }

        public ListProduct Get(int listId, int productId)
        {
            return _listProductDal.Get(listId, productId);
        }

        public void Update(ListProduct listProduct)
        {
            _listProductDal.Update(listProduct);
        }
    }
}
