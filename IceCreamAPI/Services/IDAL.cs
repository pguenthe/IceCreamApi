using IceCreamAPI.Models;
using System.Collections.Generic;

namespace IceCreamAPI.Services
{
    public interface IDAL
    {
        //int CreateProduct(Product prod);
        //int DeleteProductById(int id);
        Product GetProductById(int id);
        string[] GetProductCategories();
        IEnumerable<Product> GetProductsAll();
        //IEnumerable<Product> GetProductsInCategory(string cat);
        //int UpdateProductById(Product prod);
    }
}