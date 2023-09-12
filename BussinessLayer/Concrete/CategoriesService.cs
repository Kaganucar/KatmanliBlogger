using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities;

namespace BussinessLayer.Concrete
{
    public class CategoriesService : ICategoriesService
    {
        private IRepositories<TBLCategories> repo;
        public CategoriesService(IRepositories<TBLCategories> repo)
        {
            this.repo = repo;
        }
        public string Ekle(TBLCategories data)
        {
            if (repo.Insert(data))
            {
                return "İşlem Başarılı";
            }
            else
            {
                return "İşlem Başarısız";
            }
        }

        public IList<TBLCategories> GetAll()
        {
            return repo.GetAll();
        }

        public TBLCategories GetById(int id)
        {
            return repo.GetById(x => x.id == id);
        }

        public string Guncelle(TBLCategories data)
        {
            if (repo.Update(data))
            {
                return "İşlem Başarılı";
            }
            else
            {
                return "İşlem Başarısız";
            }
        }

        public string Sil(int id)
        {
            if (repo.Delete(x => x.id == id))
            {
                return "İşlem Başarılı";
            }
            else
            {
                return "İşlem Başarısız";
            }
        }
    }
}
