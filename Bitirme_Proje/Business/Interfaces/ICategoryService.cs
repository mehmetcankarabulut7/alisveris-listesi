
using Bitirme_Proje.EntityFramework.Entities;
using System.Collections.Generic;

namespace Bitirme_Proje.Business.Interfaces
{
    public interface ICategoryService
    {
        public List<Category> GetAll();
        public Category GetById(int id);
        public void Update(Category category);
        public void Delete(int id);
        public void Add(Category category);
        public Category GetByName(string name);
    }
}
