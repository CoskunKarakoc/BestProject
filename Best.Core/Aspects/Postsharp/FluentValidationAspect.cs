using Best.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.Core.Aspects.Postsharp
{
    /*Öncelikle Postsharp 4.2.17 exe dosyasını kuruyoruz
    daha sonra ManageNugetPackages'ten Postsharp dll'ini kuruyoruz */
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private Type _validatiorType;
        public FluentValidationAspect(Type validatiorType)
        {
            _validatiorType = validatiorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator =(IValidator)Activator.CreateInstance(_validatiorType);
            var entityType = _validatiorType.BaseType.GetGenericArguments()[0];//ProductValidator'in ==>> AbstractValidator<Product>==>>Prodcut nesnesini aldık
            var entities = args.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)//Eğer metoda birden fazla nesne geliyorsa Örnek List<Product> product tipinde bütün nesnelerin validationunu kontrol ediyoruz.
            {
                ValidatorTools.FluentValidate(validator, entity);
            }

        }
    }
}
