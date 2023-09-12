using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities;

namespace BussinessLayer.Concrete
{
    public class UserService : IUserService
    {
        private IRepositories<TBLUser> users;
        public UserService(IRepositories<TBLUser> users)
        {
            this.users = users;
        }
        public string Ekle(TBLUser data)
        {
            if (users.Insert(data))
            {
                return "İşlem Başarılı";
            }
            else
            {
                return "İşlem Başarısız";
            }
        }

        public IList<TBLUser> GetAll(bool Siralama)
        {
            if (Siralama) // True şse A'dan Z'ye
            {
                return users.GetAll().OrderBy(x => x.Email).ToList();
            }
            else
            {
                return users.GetAll();
            }
        }

        public TBLUser GetById(int id)
        {
            return users.GetById(x=> x.id == id);
        }

        public string Guncelle(TBLUser data)
        {
            if (users.Update(data))
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
            if (users.Delete(x=> x.id == id))
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
