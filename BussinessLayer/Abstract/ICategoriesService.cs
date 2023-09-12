using Entities;

namespace BussinessLayer.Abstract
{
    public interface ICategoriesService
    {
        public IList<TBLCategories> GetAll();
        public TBLCategories GetById(int id);
        public string Ekle(TBLCategories data);
        public string Guncelle(TBLCategories data);
        public string Sil(int id);
    }
}
