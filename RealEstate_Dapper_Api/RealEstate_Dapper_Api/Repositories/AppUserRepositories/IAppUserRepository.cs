using RealEstate_Dapper_Api.Dtos.AppUserDtos;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByProductIdDto> GetAppUserByProductId(int id);
        Task<List<GetAppUserByUserRoleDto>> GetAppUserByUserRole(int userRole);
        Task<List<ResultAppUserDto>> GetAllAppUser();
        Task CreateAppUser(CreateAppUserDto createAppUserDto);
        Task DeleteAppUser(int id);
        Task UpdateAppUser(UpdateAppUserDto updateAppUserDto);
    }
}
