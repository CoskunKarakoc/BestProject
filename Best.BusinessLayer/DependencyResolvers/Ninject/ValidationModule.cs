using Best.BusinessLayer.ValidationRules.FluentValidation;
using Best.Entities.Entities;
using FluentValidation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.BusinessLayer.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        /*Client side validation yaptığımda validasyon kurallarımı client module göre instance'nı oluşturmak için yaptım*/
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}
