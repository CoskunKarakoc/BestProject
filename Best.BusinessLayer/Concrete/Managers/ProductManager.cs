using Best.BusinessLayer.Abstract;
using Best.BusinessLayer.ValidationRules.FluentValidation;
using Best.Core.Aspects.Postsharp;
using Best.Core.Aspects.Postsharp.CacheAspects;
using Best.Core.Aspects.Postsharp.LogAspects;
using Best.Core.Aspects.Postsharp.PerformanceAspects;
using Best.Core.Aspects.Postsharp.TransactionAspects;
using Best.Core.Aspects.Postsharp.ValidationAspects;
using Best.Core.CrossCuttingConcerns.Caching.Microsoft;
using Best.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Best.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Best.DataAccess.Abstract;
using Best.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Best.BusinessLayer.Concrete.Managers
{
    //Class seviyesinde loglama işini AssemblyInfo'da yaptık 
    //Postsharp dll'ini de buraya yükledik.
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]//Listeye yeni ürün eklendiğinde otomatik cache temizle ve içini yeni verilerle doldur
        public Product AddProduct(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public void DeleteProduct(Product product)
        {

            _productDal.Delete(product);
        }
        [CacheAspect(typeof(MemoryCacheManager))]//[CacheAspect(typeof(MemoryCacheManager),120)] dakika vererekte kullanabiliriz.
        [PerformanceCounterAspect(2)]
        public List<Product> GetAllProducts()
        {
            Thread.Sleep(3000);
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        [TransactionScopeAspect]//Transaction işlemlerinin Aspectlerle Çözümü 
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            //....
            _productDal.Update(product2);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product UpdateProduct(Product product)
        {

            return _productDal.Update(product);
        }
    }
}
