using Catalog.Data.Interfaces;
using Catalog.Domain.DTOs;
using Catalog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly ILogger<ItemController> _logger;


        public ItemController(IItemRepository itemRepository, ILogger<ItemController> logger)
        {
            _itemRepository = itemRepository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetList()
        {
            try
            {
                var items = await _itemRepository.GetList();

                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError("Message: ", ex);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ItemDto>> Get(Guid id)
        {
            try
            {
                var item = await _itemRepository.Get(id);

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError("Message: ", ex);
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateItemDto createItemDto)
        {
            try
            {
                await _itemRepository.Create(createItemDto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Message: ", ex);
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateItemDto updateItemDto)
        {
            try
            {
                await _itemRepository.Update(updateItemDto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Message: ", ex);
                return BadRequest();
            }
        }
    }
}
