
using Bitirme_Proje.EntityFramework.Entities;
using System.Collections.Generic;

namespace Bitirme_Proje.Business.Interfaces
{
    public interface IShoppingListService
    {
        public List<ShoppingList> GetAllById(int id);
        public ShoppingList GetById(int id);
        public void Add(ShoppingList shoppingList);
        public ShoppingList GetListWithProductsById(int id);
        public void Update(ShoppingList shoppingList);
        public void Clear(ShoppingList list);
        public void Delete(ShoppingList list);
    }
}
