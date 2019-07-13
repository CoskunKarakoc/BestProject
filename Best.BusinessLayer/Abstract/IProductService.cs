using Best.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.BusinessLayer.Abstract
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetById(int id);
        Product AddProduct(Product product);
        void DeleteProduct(Product product);
        Product UpdateProduct(Product product);
        void TransactionalOperation(Product product1,Product product2);
    }
}
