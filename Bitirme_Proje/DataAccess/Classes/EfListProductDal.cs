using Bitirme_Proje.DataAccess.Interfaces;
using Bitirme_Proje.EntityFramework;
using Bitirme_Proje.EntityFramework.Entities;
using System.Linq;

namespace Bitirme_Proje.DataAccess.Classes
{
    public class EfListProductDal : IListProductDal
    {
        private BitirmeDbContext context;
        private ListProduct listProduct;

        public EfListProductDal(BitirmeDbContext context, ListProduct listProduct)
        {
            this.context = context;
            this.listProduct = listProduct;
        }

        public void Add(ListProduct listProduct)
        {
            context.ListProducts.Add(listProduct);
            context.SaveChanges();
        }

        public void Delete(int listId, int productId)
        {
            listProduct.ShoppingListId = listId;
            listProduct.ProductId = productId;
            context.ListProducts.Remove(listProduct);
            context.SaveChanges();
        }

        public ListProduct Get(int listId, int productId)
        {
            return context.ListProducts.FirstOrDefault(
                lp => lp.ShoppingListId == listId && lp.ProductId == productId);
        }

        public void Update(ListProduct listProduct)
        {
            context.ListProducts.Update(listProduct);
            context.SaveChanges();
        }
    }
}
