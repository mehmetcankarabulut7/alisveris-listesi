
using Bitirme_Proje.EntityFramework.Entities;

namespace Bitirme_Proje.DataAccess.Interfaces
{
    public interface IListProductDal
    {
        public ListProduct Get(int listId, int productId);
        public void Update(ListProduct listProduct);
        public void Delete(int listId, int productId);
        public void Add(ListProduct listProduct);
    }
}
