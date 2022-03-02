using System.Text.Json;
using API.Data;
using API.Dtos;
using API.Entities;
using API.Extensions;
using API.RequestHelpers;
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
        public async Task<ActionResult<PagedList<Product>>> GetProducts([FromQuery]ProductParams productParams){
            var query = _store.Products
                                .Sort(productParams.OrderBy)
                                .Search(productParams.SearchTerm)
                                .Filter(productParams.Brands, productParams.Types)
                                .AsQueryable();

            var products = await PagedList<Product>.ToPagedList(query, productParams.PageNumber, productParams.PageSize);

            Response.AddPaginationHeader(products.MetaData);

            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            var product = await _store.Products.FindAsync(id);
            
            if(product is null) return NotFound();

            return product;
        }

        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
        {
            var brands = await _store.Products.Select(p => p.Brand).Distinct().ToListAsync();
            var types = await _store.Products.Select(p => p.Type).Distinct().ToListAsync();

            return Ok(new { brands, types });
        }
    }
}