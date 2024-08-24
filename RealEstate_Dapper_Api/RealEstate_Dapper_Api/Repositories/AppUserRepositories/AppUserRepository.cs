using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateAppUser(CreateAppUserDto createAppUserDto)
        {
            string query = @"insert into AppUser(UserName, Password, Name, Email, UserRole, UserImageUrl, PhoneNumber) values 
                           (@userName, @password, @name, @email, @userRole, @userImageUrl, @phoneNumber)";
            var parameters = new DynamicParameters();
            parameters.Add("@userName", createAppUserDto.UserName);
            parameters.Add("@password", createAppUserDto.Password);
            parameters.Add("@name", createAppUserDto.Name);
            parameters.Add("@email", createAppUserDto.Email);
            parameters.Add("@userRole", createAppUserDto.UserRole);
            parameters.Add("@userImageUrl", createAppUserDto.UserImageUrl);
            parameters.Add("@phoneNumber", createAppUserDto.PhoneNumber);
            
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteAppUser(int id)
        {
            string query = "Delete From AppUser Where UserId = @userID";
            var parameters = new DynamicParameters();
            parameters.Add("@userID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultAppUserDto>> GetAllAppUser()
        {
            string query = "Select * from AppUser";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAppUserDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetAppUserByProductIdDto> GetAppUserByProductId(int id)
        {
            string query = "Select * From AppUser Where UserId= @userID";
            var parameters = new DynamicParameters();
            parameters.Add("@userID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIdDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<GetAppUserByUserRoleDto>> GetAppUserByUserRole(int userRole)
        {
            string query = "Select UserId,UserName,UserRole,RoleName From AppUser inner join AppRole on AppUser.UserRole=AppRole.RoleId Where UserRole= @userRole";
            var parameters = new DynamicParameters();
            parameters.Add("@userRole", userRole);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetAppUserByUserRoleDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task UpdateAppUser(UpdateAppUserDto updateAppUserDto)
        {
            string query = @"Update AppUser set UserName=@userName, Password=@password, Name=@name, Mail=@mail, 
            UserRole=@userRole,UserImageUrl=@userImageUrl PhoneNumber=@phoneNumber where UserId=@userId";
            var parameters = new DynamicParameters();
            parameters.Add("@userName", updateAppUserDto.UserName);
            parameters.Add("@password", updateAppUserDto.Password);
            parameters.Add("@name", updateAppUserDto.Name);
            parameters.Add("@mail", updateAppUserDto.Email);
            parameters.Add("@userRole", updateAppUserDto.UserRole);
            parameters.Add("@userImageUrl", updateAppUserDto.UserImageUrl);
            parameters.Add("@phoneNumber", updateAppUserDto.PhoneNumber);
            parameters.Add("@userId", updateAppUserDto.UserId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
