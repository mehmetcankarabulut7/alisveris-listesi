
using Bitirme_Proje.EntityFramework.Entities;
using System.Collections.Generic;

namespace Bitirme_Proje.DataAccess.Interfaces
{
    public interface IProductDal
    {
        public List<Product> GetProductsWithCategoryNotInList(int listId);
        public List<Product> GetProductsWithCategory();
        public Product GetById(int id);
        public void Update(Product product);
        public void Delete(int id);
        public void Add(Product product);
        public List<Product> SearchByName(int listId, string searchText);
        public List<Product> FilterByCategoryName(int listId, string categoryName);
        public Product GetByName(string name);
    }
}
