using Best.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.Core.DataAccess.NHibarnete
{
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        NHibernateHelper _hibernateHelper;
        IQueryable<T> _entities;
        public NhQueryableRepository(NHibernateHelper hibernateHelper)
        {
            _hibernateHelper = hibernateHelper;
        }


        public IQueryable<T> Table => this.Entities;

        public virtual IQueryable<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _hibernateHelper.OpenSession().Query<T>();
                }
                return _entities;
            }
        }
    }
}
