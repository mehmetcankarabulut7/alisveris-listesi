using Bitirme_Proje.DataAccess.Interfaces;
using Bitirme_Proje.EntityFramework;
using Bitirme_Proje.EntityFramework.Entities;
using System.Linq;

namespace Bitirme_Proje.DataAccess.Classes
{
    public class EfUserDal : IUserDal
    {
        private BitirmeDbContext context;

        public EfUserDal(BitirmeDbContext context)
        {
            this.context = context;
        }
        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User GetByMail(string mail)
        {
            return context.Users.FirstOrDefault(u => u.Mail == mail);
        }

        public User GetByMailAndPassword(string mail, string password)
        {
            return context.Users.FirstOrDefault(u => u.Mail == mail && u.Password == password);
        }
    }
}
