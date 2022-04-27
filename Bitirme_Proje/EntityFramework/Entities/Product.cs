
using System.Collections.Generic;

namespace Bitirme_Proje.EntityFramework.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public Product()
        {
            ListProducts = new List<ListProduct>();
        }

        public Category Category { get; set; }
        public ICollection<ListProduct> ListProducts { get; set; }
    }
}
