using Catalog.Data.Interfaces;
using Catalog.Domain;
using Catalog.Domain.DTOs;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Data.Repository
{
    public class ItemRepository : IItemRepository
    {
		private readonly IDataContext _context;
		private readonly CancellationToken cancellationToken;

		public ItemRepository(IDataContext context)
		{
			_context = context;
        }

		public async Task<IEnumerable<ItemDto>> GetList()
		{
			var items = _context.Items.Select(item => item.AsDto())
				.ToListAsync();

			return await items;
		}

		public async Task<ItemDto?> Get(Guid id)
		{
			var item = await _context.Items.FirstOrDefaultAsync(item => item.Id == id);

			if (item is null)
			{
				throw new ArgumentNullException();
			}

			return item.AsDto();
		}

		public async Task Create(CreateItemDto createItemDto)
		{
            var item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = createItemDto.Name,
                Price = createItemDto.Price,
                CreatedDate = DateTime.Now
            };

            _context.Items.Add(item);

			await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(UpdateItemDto updateItemDto)
        {
			var item = await _context.Items.FindAsync(updateItemDto.Id);

			if(item is null)
			{
				throw new ArgumentNullException();
			}

			item.Name = updateItemDto.Name;
			item.Price = updateItemDto.Price;

            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}

