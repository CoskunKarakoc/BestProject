using Best.BusinessLayer.Abstract;
using Best.BusinessLayer.Concrete.Managers;
using Best.Core.DataAccess;
using Best.Core.DataAccess.EntityFramework;
using Best.Core.DataAccess.NHibarnete;
using Best.DataAccess.Abstract;
using Best.DataAccess.Concrete.EntityFramework;
using Best.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.BusinessLayer.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            /*********İhtiyaca Göre Injection Rules*********/
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind<IProductService>().To<ProductManager>().InSingletonScope();

            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();



            /*********Standart Injection Rules*************/
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
