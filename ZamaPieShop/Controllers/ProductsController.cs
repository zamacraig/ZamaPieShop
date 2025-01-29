using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZamaPieShop.Data;
using ZamaPieShop.Models;

namespace ZamaPieShop.Controllers
{
	[Route("Products")]
	public class ProductsController : Controller
    {
        private readonly ProductContext _productContext;
        public ProductsController(ProductContext productContext)
        {
            _productContext = productContext;
        }

		// Route: /Products
		[HttpGet]
		public async Task<IActionResult> Index()
        {
			var products = _productContext.Product.ToList();
			if (products == null)
			{
				return NotFound();
			}

			return View("Index", products);
		}

		// Route: /Products/1
		[HttpGet("{id?}")]
		public async Task<IActionResult> Details(int? id)
		{
			if (!id.HasValue)
			{
				return BadRequest("Product ID is required");
			}

			var _product = _productContext.Product
				.FirstOrDefault(i => i.Id == id);

			var _reviews = _productContext.Review.ToList().FindAll(i => i.ProductId == id);

			ProductDetail productDetail = new ProductDetail() { product = _product, reviews = _reviews};

			if (productDetail == null)
			{
				return NotFound();
			}

			return View("Details", productDetail);
		}
    }
}
