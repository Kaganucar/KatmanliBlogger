using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities;

namespace BussinessLayer.Concrete
{
    public class BlogService : IBlogService
    {
        private IRepositories<TBLBlog> repo;
        public BlogService(IRepositories<TBLBlog> repo)
        {
            this.repo = repo;
        }
        public string Ekle(TBLBlog data)
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

        public IList<TBLBlog> GetAll()
        {
            return repo.GetAll();
        }

        public TBLBlog GetById(int id)
        {
            return repo.GetById(x => x.id == id);
        }

        public string Guncelle(TBLBlog data)
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
