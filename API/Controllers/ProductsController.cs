using API.Data;
using API.Dtos;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var products = await _store.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            var product = await _store.Products.FindAsync(id);
            
            if(product is null) return NotFound();

            return product;
        }
    }
}