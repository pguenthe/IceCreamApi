using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IceCreamAPI.Models;
using IceCreamAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IceCreamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IDAL dal;

        public ProductController(IDAL dalObject)
        {
            dal = dalObject;
        }

        [HttpGet("{id}")]
        public Product GetSingleProduct(int id)
        {
            Product Prod = dal.GetProductById(id);
            return Prod; //serialize the parameter into JSON and return an Ok (20x)
        }

        [HttpGet]
        public IEnumerable<Product> Get(string category = null)
        {
            if (category == null)
            {
                IEnumerable<Product> Products = dal.GetProductsAll();
                return Products; //serialize the parameter into JSON and return an Ok (20x)
            }
            else
            {
                IEnumerable<Product> Products = dal.GetProductsByCategory(category);
                return Products;
            }
        }

        [HttpGet("categories")]
        public string[] GetCategories()
        {
            return dal.GetProductCategories();
        }
        


    }
}