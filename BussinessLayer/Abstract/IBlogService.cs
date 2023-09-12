using Entities;

namespace BussinessLayer.Abstract
{
    public interface IBlogService
    {
        public IList<TBLBlog> GetAll();
        public TBLBlog GetById(int id);
        public string Ekle(TBLBlog data);
        public string Guncelle(TBLBlog data);
        public string Sil(int id);
    }
}
