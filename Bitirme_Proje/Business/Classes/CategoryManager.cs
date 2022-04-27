using Bitirme_Proje.Business.Interfaces;
using Bitirme_Proje.DataAccess.Interfaces;
using Bitirme_Proje.EntityFramework.Entities;
using System.Collections.Generic;

namespace Bitirme_Proje.Business.Classes
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(int id)
        {
            _categoryDal.Delete(id);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public Category GetByName(string name)
        {
            return _categoryDal.GetByName(name);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
