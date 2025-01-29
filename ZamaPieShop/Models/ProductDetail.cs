namespace ZamaPieShop.Models
{
	public class ProductDetail
	{
		public Product product { get; set; }
		public List<Review>? reviews { get; set; }
	}
}
