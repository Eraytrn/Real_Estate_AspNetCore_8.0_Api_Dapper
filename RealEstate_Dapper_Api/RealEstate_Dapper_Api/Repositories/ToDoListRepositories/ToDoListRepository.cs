using Dapper;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateToDoList(CreateToDoListDto toDoListDto)
        {
            string query = "insert into ToDoList(Description, ToDoListStatus) values (@description, @toDoListStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@description", toDoListDto.Description);
            parameters.Add("@toDoListStatus", toDoListDto.ToDoListStatus);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteToDoList(int id)
        {
            string query = "Delete From ToDoList Where ToDoListID = @toDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@toDoListID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoList()
        {
            string query = "Select * from ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDToDoListDto> GetToDoList(int id)
        {
            string query = "Select * From ToDoList Where ToDoListID = @toDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@toDoListID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDToDoListDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateToDoList(UpdateToDoListDto toDoListDto)
        {
            string query = "Update ToDoList Set Description=@description," +
            "ToDoListStatus = @toDoListStatus " +
            "where ToDoListID=@toDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@description", toDoListDto.Description);
            parameters.Add("@toDoListStatus", toDoListDto.ToDoListStatus);
            parameters.Add("@toDoListID", toDoListDto.ToDoListID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
