using API.Data;
using API.Dtos;
using API.Entities;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly StoreContext _store;

        public ProductsController(StoreContext store)
        {
            _store = store;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts(){
            var products = _store.Products.ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id){
            return _store.Products.Find(id);
        }
    }
}