using System;
namespace Catalog.Domain.Entities
{
	public class Item
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

		public DateTime CreatedDate { get; set; }

	}
}

