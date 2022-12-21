using System;
namespace Catalog.Domain.DTOs
{
	public record ItemDto
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public DateTime CreatedDate { get; set; }
	}
}

