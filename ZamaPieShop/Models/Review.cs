﻿namespace ZamaPieShop.Models
{
	public class Review
	{
		public int ReviewId { get; set; }
		public int ProductId { get; set; }
		public string Comment {  get; set; }
		public int Rate { get; set; }

	}
}
