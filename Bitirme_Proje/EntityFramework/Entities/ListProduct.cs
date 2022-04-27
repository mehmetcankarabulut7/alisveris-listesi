
namespace Bitirme_Proje.EntityFramework.Entities
{
    public class ListProduct
    {
        public int ProductId { get; set; }
        public int ShoppingListId { get; set; }
        public string Description { get; set; }

        public Product Product { get; set; }
        public ShoppingList ShoppingList { get; set; }
    }
}
