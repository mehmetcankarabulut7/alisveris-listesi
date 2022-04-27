
using System.Collections.Generic;

namespace Bitirme_Proje.EntityFramework.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }

        public ICollection<Product> Products { get; set; }
    }
}
