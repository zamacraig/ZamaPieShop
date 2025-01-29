using Microsoft.AspNetCore.Mvc;
using ZamaPieShop.Data;
using ZamaPieShop.Models;
using ZamaPieShop.Services;

namespace ZamaPieShop.Controllers
{
	[Route("ShoppingCart")]
	public class ShoppingCartController : Controller
    {
		private readonly ShoppingCartService _shoppingCartService;
		private readonly ProductContext _productContext;

		public ShoppingCartController(ShoppingCartService shoppingCartService, ProductContext productContext)
		{
			_shoppingCartService = shoppingCartService;
			_productContext = productContext;
		}

		public IActionResult ShowCart()
		{
			var cartItems = _shoppingCartService.GetCartItems();
			var totalPrice = _shoppingCartService.GetTotalPrice();

			var viewModel = new ShoppingCart
			{
				CartItems = cartItems,
				TotalPrice = totalPrice
			};

			return View(viewModel);
		}

		[HttpGet("AddToCart/{id}")]
		public IActionResult AddToCart(int id)
		{
			Product product = _productContext.Product.FirstOrDefault(i => i.Id == id);

			if (product == null) 
			{
				return NotFound();
			}

			_shoppingCartService.AddToCart(product, 1);

			return RedirectToAction("Index");
		}

		[HttpPost("RemoveFromCart/{id}")]
		public IActionResult RemoveFromCart(int id)
		{
			_shoppingCartService.RemoveFromCart(id);

			return RedirectToAction("Index");
		}

		[HttpPost("CheckOut")]
		public IActionResult CheckOut()
		{
			return RedirectToAction("Index");
		}

		[HttpPost("ClearCart")]
		public IActionResult ClearCart()
		{
			_shoppingCartService.ClearCart();
			return RedirectToAction("Index");
		}
	}
}
