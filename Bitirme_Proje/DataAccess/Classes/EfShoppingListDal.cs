
using Bitirme_Proje.DataAccess.Interfaces;
using Bitirme_Proje.EntityFramework;
using Bitirme_Proje.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bitirme_Proje.DataAccess.Classes
{
    public class EfShoppingListDal : IShoppingListDal
    {
        private BitirmeDbContext context;

        public EfShoppingListDal(BitirmeDbContext context)
        {
            this.context = context;
        }

        public void Add(ShoppingList shoppingList)
        {
            context.ShoppingLists.Add(shoppingList);
            context.SaveChanges();
        }

        public void Clear(ShoppingList list)
        {
            int listId = list.Id;
            while (true)
            {
                var listProduct = context.ListProducts.FirstOrDefault(lp => lp.ShoppingListId == listId);
                if (listProduct == null)
                {
                    break;                  
                }
                context.ListProducts.Remove(listProduct);
                context.SaveChanges();
            }               
        }

        public void Delete(ShoppingList list)
        {
            context.ShoppingLists.Remove(list);
            context.SaveChanges();
        }

        public List<ShoppingList> GetAllById(int id)
        {
            return context.ShoppingLists.Where(sl => sl.UserId == id).ToList();
        }

        public ShoppingList GetById(int id)
        {
            return context.ShoppingLists.FirstOrDefault(sl => sl.Id == id);
        }

        public ShoppingList GetListWithProductsById(int id)
        {
            return context.ShoppingLists
                .Include(sl => sl.ListProducts)
                .ThenInclude(lp => lp.Product)
                .FirstOrDefault(sl => sl.Id == id);
        }

        public void Update(ShoppingList shoppingList)
        {
            context.ShoppingLists.Update(shoppingList);
            context.SaveChanges();
        }
    }
}
