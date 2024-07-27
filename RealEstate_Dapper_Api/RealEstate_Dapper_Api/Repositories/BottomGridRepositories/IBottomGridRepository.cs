using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllButtomGridAsync();
        void CreateButtomGrid(CreateBottomGridDto createBottomGridDto);
        void DeleteButtomGrid(int id);  
        void UpdateButtomGrid(UpdateBottomGridDto updateBottomGridDto);
        Task<GetBottomGridDto> GetButtomGrid(int id);
    }
}
