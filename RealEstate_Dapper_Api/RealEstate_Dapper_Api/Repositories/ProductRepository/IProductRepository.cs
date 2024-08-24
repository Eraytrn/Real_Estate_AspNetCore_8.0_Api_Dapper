using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEstateAgentDto>> GetProductAdvertListByEstateAgentAsyncByTrue(int id);
        Task<List<ResultProductAdvertListWithCategoryByEstateAgentDto>> GetProductAdvertListByEstateAgentAsyncByFalse(int id);
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task ProductDealOfTheDayStatusChangeToTrue(int id);
        Task ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync();
        Task CreateProduct(CreateProductDto createProductDto);
        Task<GetProductByProductIdDto> GetProductByProductId(int id);
        Task<GetProductDetailByIdDto> GetProductDetailByProductId(int id);
        Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city);
        Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategoryAsync();
        Task<List<ResultLast3ProductWithCategoryDto>> GetLast3ProductAsync();
        Task DeleteProduct(int id);
        Task<List<ResultProductWithCategoryDto>>ResultProductCategoryByVilla();
        Task<List<ResultProductWithCategoryDto>> ResultProductCategoryByDaire();
        Task<List<ResultProductWithCategoryDto>> ResultProductCategoryByYazlik();
        
    }
}
