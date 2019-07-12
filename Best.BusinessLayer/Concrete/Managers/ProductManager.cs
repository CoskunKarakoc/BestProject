using Best.BusinessLayer.Abstract;
using Best.BusinessLayer.ValidationRules.FluentValidation;
using Best.Core.Aspects.Postsharp;
using Best.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Best.DataAccess.Abstract;
using Best.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.BusinessLayer.Concrete.Managers
{
    //Postsharp dll'ini de buraya yükledik.
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product AddProduct(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public void DeleteProduct(Product product)
        {

            _productDal.Delete(product);
        }

        public List<Product> GetAllProducts()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product UpdateProduct(Product product)
        {

            return _productDal.Update(product);
        }
    }
}
