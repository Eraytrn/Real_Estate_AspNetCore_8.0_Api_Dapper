using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultAppUserDto>> GetAllEmployee();
        Task CreateEmployee(CreateAppUserDto createEmployeeDto);
        Task DeleteEmployee(int id);
        Task UpdateEmployee(UpdateAppUserDto updateEmployeeDto);
        Task<GetByIDEmployeeDto> GetEmployee(int id);
    }
}
