using System;
using Best.DataAccess.Concrete.NHibernate;
using Best.DataAccess.Concrete.NHibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Best.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTest
    {

        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList();
            Assert.AreEqual(77, result.Count);

        }
        [TestMethod]
        public void Get_all_parameter_returns_filtered_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList(p => p.ProductName.Contains("ab"));
            Assert.AreEqual(4, result.Count);

        }
    }
}
