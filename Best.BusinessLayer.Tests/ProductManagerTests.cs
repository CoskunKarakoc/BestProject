using Best.BusinessLayer.Concrete.Managers;
using Best.DataAccess.Abstract;
using Best.Entities.Entities;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Best.BusinessLayer.Tests
{
    //Moq dll'ini Nugget'ten yükledim
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]//Hata beklediğimiz için burada validationException bekliyoruz
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);/*Burada prdMngr bizden bir ProductDal ister ama biz bunu IProducDal instance ile çözdük.
                                                                            Yoksa diğer türlü ProductDal da versek yani katmanlar 
                                                                            arası inject yapsak bu sefer entegrasyon testi yapmış oluruz
                                                                            benim burdaki amacım sadece validation aspectini test etmek*/
            productManager.AddProduct(new Product());

        }
    }
}
