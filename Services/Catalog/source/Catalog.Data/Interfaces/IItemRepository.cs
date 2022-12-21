using Catalog.Domain.DTOs;
using Catalog.Domain.Entities;

namespace Catalog.Data.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemDto>> GetList();

        Task<ItemDto?> Get(Guid id);

        Task Create(CreateItemDto createItemDto);

        Task Update(UpdateItemDto updateItemDto);
    }
}

