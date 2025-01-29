namespace ZamaPieShop.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using ZamaPieShop.Models;

	public class ShoppingCartService
	{
		private readonly List<CartItem> _cartItems;

		public ShoppingCartService()
		{
			_cartItems = new List<CartItem>();
		}

		public void AddToCart(Product product, int quantity)
		{
			var cartItem = _cartItems.SingleOrDefault(item => item.ProductId == product.Id);

			if (cartItem == null)
			{
				cartItem = new CartItem
				{
					ProductId = product.Id,
					ProductName = product.Name,
					Price = product.Price,
					Quantity = quantity
				};
				_cartItems.Add(cartItem);
			}
			else
			{
				cartItem.Quantity += quantity;
			}
		}

		public void RemoveFromCart(int productId)
		{
			var cartItem = _cartItems.FirstOrDefault(i => i.ProductId == productId);

			if (cartItem != null)
			{
				_cartItems.Remove(cartItem);
			}
		}

		public List<CartItem> GetCartItems()
		{
			return _cartItems;
		}

		public void ClearCart()
		{
			_cartItems.Clear();
		}

		public decimal GetTotalPrice()
		{
			return _cartItems.Sum(item => item.Price * item.Quantity);
		}
	}

}
