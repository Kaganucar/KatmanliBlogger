using Entities;

namespace BussinessLayer.Abstract
{
    public interface IUserService
    {
        public IList<TBLUser> GetAll(bool Siralama);
        public TBLUser GetById(int id);
        public string Ekle(TBLUser data);
        public string Guncelle(TBLUser data);
        public string Sil(int id);
    }
}
