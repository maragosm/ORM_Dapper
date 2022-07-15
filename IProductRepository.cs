using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    internal interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(string Name, double Price, int CategoryID);
        public void UpdateProduct(int productID, string UpdatedName);
        public void DeleteProduct(int productID);
    }
}
