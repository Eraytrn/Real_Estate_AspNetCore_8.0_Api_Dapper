using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUsersController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        [HttpGet("GetAppUserByProductId")]
        public async Task<IActionResult> GetAppUserByProductId(int id)
        {
            var value = await _appUserRepository.GetAppUserByProductId(id);
            return Ok(value);
        }

        [HttpGet("GetAppUserByUserRole")]
        public async Task<IActionResult> GetAppUserByUserRole(int userRole)
        {
            var value = await _appUserRepository.GetAppUserByUserRole(userRole);
            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> AppUserList()
        {
            var values = await _appUserRepository.GetAllAppUser();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateAppUserDto createAppUserDto)
        {
            await _appUserRepository.CreateAppUser(createAppUserDto);
            return Ok("Kategori başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            await _appUserRepository.DeleteAppUser(id);
            return Ok("Kategori başarılı bir şekilde silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUser(UpdateAppUserDto updateAppUserDto)
        {
            await _appUserRepository.UpdateAppUser(updateAppUserDto);
            return Ok("Kategori başarılı bir şekilde güncellendi.");
        }

        
    }
}