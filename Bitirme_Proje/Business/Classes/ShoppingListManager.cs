using Bitirme_Proje.Business.Interfaces;
using Bitirme_Proje.DataAccess.Interfaces;
using Bitirme_Proje.EntityFramework.Entities;
using System.Collections.Generic;

namespace Bitirme_Proje.Business.Classes
{
    public class ShoppingListManager : IShoppingListService
    {
        private IShoppingListDal _shoppingListDal;

        public ShoppingListManager(IShoppingListDal shoppingListDal)
        {
            _shoppingListDal = shoppingListDal;
        }

        public void Add(ShoppingList shoppingList)
        {
            _shoppingListDal.Add(shoppingList);
        }

        public void Clear(ShoppingList list)
        {
            _shoppingListDal.Clear(list);
        }

        public void Delete(ShoppingList list)
        {
            _shoppingListDal.Delete(list);
        }

        public List<ShoppingList> GetAllById(int id)
        {
            return _shoppingListDal.GetAllById(id);
        }

        public ShoppingList GetById(int id)
        {
            return _shoppingListDal.GetById(id);
        }

        public ShoppingList GetListWithProductsById(int id)
        {
            return _shoppingListDal.GetListWithProductsById(id);
        }

        public void Update(ShoppingList shoppingList)
        {
            _shoppingListDal.Update(shoppingList);
        }
    }
}
