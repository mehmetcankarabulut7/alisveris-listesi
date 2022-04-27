
using Bitirme_Proje.DataAccess.Interfaces;
using Bitirme_Proje.EntityFramework;
using Bitirme_Proje.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bitirme_Proje.DataAccess.Classes
{
    public class EfProductDal : IProductDal
    {
        private BitirmeDbContext context;

        public EfProductDal(BitirmeDbContext context)
        {
            this.context = context;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Products.Remove(context.Products.FirstOrDefault(p => p.Id == id));
            context.SaveChanges();
        }

        public Product GetById(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProductsWithCategory()
        {
            return context.Products.Include("Category").ToList();
        }

        public List<Product> GetProductsWithCategoryNotInList(int listId)
        {
            List<int> productIdsInList = context.ListProducts
                        .Where(lp => lp.ShoppingListId == listId)
                        .Select(lp => lp.ProductId)
                        .ToList();

            return context.Products
                .Include("Category")
                .Where(p => !productIdsInList.Contains(p.Id))
                .ToList(); 
        }

        public List<Product> SearchByName(int listId, string searchText)
        {    
            return GetProductsWithCategoryNotInList(listId)
                .Where(p => p.Name.Contains(searchText))
                .ToList();
        }

        public List<Product> FilterByCategoryName(int listId, string categoryName)
        {
            return GetProductsWithCategoryNotInList(listId)
                .Where(p => p.Category.Name == categoryName)
                .ToList();
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public Product GetByName(string name)
        {
            return context.Products.FirstOrDefault(p => p.Name == name);
        }
    }
}
