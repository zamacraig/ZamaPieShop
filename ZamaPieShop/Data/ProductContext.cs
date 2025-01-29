using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ZamaPieShop.Data
{
	public class ProductContext : DbContext
	{
        public ProductContext(DbContextOptions<ProductContext> options)
			: base(options)
		{
			
        }

		public DbSet<ZamaPieShop.Models.Product> Product { get; set; }
		public DbSet<ZamaPieShop.Models.Review> Review { get; set; }
		//public DbSet<ZamaPieShop.Models.ShoppingCart> ShoppingCart { get; set; }
		//public DbSet<ZamaPieShop.Models.CartItem> CartItem { get; set; }
	}
}