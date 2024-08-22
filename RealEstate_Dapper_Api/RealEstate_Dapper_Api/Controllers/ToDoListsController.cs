using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListsController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllToDoList()
        {
            var values = await _toDoListRepository.GetAllToDoList();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDoList(CreateToDoListDto toDoListDto)
        {
            await _toDoListRepository.CreateToDoList(toDoListDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            await _toDoListRepository.DeleteToDoList(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoList(int id)
        {
            var values = await _toDoListRepository.GetToDoList(id);
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToDoList(UpdateToDoListDto toDoListDto)
        {
            await _toDoListRepository.UpdateToDoList(toDoListDto);
            return Ok();
        }

    }
}
