namespace ZamaPieShop.Models
{
	public class ShoppingCart
	{
		public List<CartItem> CartItems { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
