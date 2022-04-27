
using System.Collections.Generic;

namespace Bitirme_Proje.EntityFramework.Entities
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool OnShopping { get; set; }

        public ShoppingList()
        {
            ListProducts = new List<ListProduct>();
        }

        public User User { get; set; }
        public ICollection<ListProduct> ListProducts { get; set; }
    }
}
