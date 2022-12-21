using System;
namespace Catalog.Domain.DTOs
{
	public class UpdateItemDto
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }
	}
}

