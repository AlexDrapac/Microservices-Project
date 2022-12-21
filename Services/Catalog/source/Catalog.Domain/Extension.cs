using System;
using Catalog.Domain.DTOs;
using Catalog.Domain.Entities;

namespace Catalog.Domain
{
	public static class Extension
	{
		public static ItemDto AsDto(this Item item)
		{
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = DateTime.Now
            };
        }
	}
}

