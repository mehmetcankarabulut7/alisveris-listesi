using Bitirme_Proje.Business.Interfaces;
using Bitirme_Proje.DataAccess.Interfaces;
using Bitirme_Proje.EntityFramework.Entities;
using System;
using System.Collections.Generic;

namespace Bitirme_Proje.Business.Classes
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int id)
        {
            _productDal.Delete(id);
        }

        public List<Product> FilterByCategoryName(int listId, string categoryName)
        {
            return _productDal.FilterByCategoryName(listId, categoryName);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public Product GetByName(string name)
        {
            return _productDal.GetByName(name);
        }

        public List<Product> GetProductsWithCategory()
        {
            return _productDal.GetProductsWithCategory();
        }

        public List<Product> GetProductsWithCategoryNotInList(int listId)
        {
            return _productDal.GetProductsWithCategoryNotInList(listId);
        }

        public List<Product> SearchByName(int listId, string searchText)
        {
            if (searchText == null) searchText = "";
            return _productDal.SearchByName(listId, searchText);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
