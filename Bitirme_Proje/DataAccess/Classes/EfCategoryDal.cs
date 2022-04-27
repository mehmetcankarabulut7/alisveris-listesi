
using Bitirme_Proje.DataAccess.Interfaces;
using Bitirme_Proje.EntityFramework;
using Bitirme_Proje.EntityFramework.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Bitirme_Proje.DataAccess.Classes
{
    public class EfCategoryDal : ICategoryDal
    {
        private BitirmeDbContext context;

        public EfCategoryDal(BitirmeDbContext context)
        {
            this.context = context;
        }

        public void Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Categories.Remove(context.Categories.FirstOrDefault(c => c.Id == id));
            context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public Category GetByName(string name)
        {
            return context.Categories.FirstOrDefault(p => p.Name == name);
        }

        public void Update(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
        }
    }
}
