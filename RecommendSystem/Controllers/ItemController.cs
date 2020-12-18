using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecommendSystem.Dtos;
using RecommendSystem.Models;
using RecommendSystem.Services;

namespace RecommendSystem.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IItemService _itemService;

        public ItemController(IMapper mapper, IItemService itemService)
        {
            _mapper = mapper;
            _itemService = itemService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var item = await _itemService.GetItem(id);
            if (item is null) return NotFound(new {ItemId = id});

            var itemReadDto = _mapper.Map<ItemReadDto>(item);
            return Ok(itemReadDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ItemWriteDto itemWriteDto)
        {
            var item = _mapper.Map<Item>(itemWriteDto);
            try
            {
                await _itemService.AddItem(item);
                var itemReadDto = _mapper.Map<ItemReadDto>(item);
                return Ok(itemReadDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}