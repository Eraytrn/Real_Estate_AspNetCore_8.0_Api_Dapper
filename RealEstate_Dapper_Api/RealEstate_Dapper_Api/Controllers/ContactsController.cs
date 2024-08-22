using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("GetLast4Contact")]
        public async Task<IActionResult> GetLast4Contact()
        {
            var values = await _contactRepository.GetLast4Contact();
            return Ok(values);
        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
             await _contactRepository.CreateContact(createContactDto);
             return Ok();
        }

        [HttpGet("DeleteContact")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactRepository.DeleteContact(id);
            return Ok();
        }

        [HttpGet("GetAllContact")]
        public async Task<IActionResult> GetAllContact()
        {
            var values = await _contactRepository.GetAllContact();
            return Ok(values);
        }

        [HttpGet("GetContact")]
        public async Task<IActionResult> GetContact(int id)
        {
            var values = await _contactRepository.GetContact(id);
            return Ok(values);
        }
    }
}
