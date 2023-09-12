using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    // TEntity Yerine Struct,Record gibi yapılar gönderilemez, sadece Class yapıları gönderilebilir.
    public interface IRepositories<TEntity> where TEntity : class
    {
        public bool Insert(TEntity data);
        public bool Update(TEntity data);
        public bool Delete(Expression<Func<TEntity, bool>> where);
        // Şartlı veya Şartsız listeleme olsun. A'dan Z'ye yada Fiyata göre Artan gibi.
        public IList<TEntity> GetAll(Expression<Func<TEntity,bool>> where = null);
        public TEntity GetById(Expression<Func<TEntity, bool>> where);
    }
}
