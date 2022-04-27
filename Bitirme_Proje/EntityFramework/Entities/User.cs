
using System.Collections.Generic;

namespace Bitirme_Proje.EntityFramework.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }

        public User()
        {
            ShoppingLists = new List<ShoppingList>();
        }

        public ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
