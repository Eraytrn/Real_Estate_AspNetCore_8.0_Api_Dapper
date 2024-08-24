using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = @"insert into Product(Title,Price,City,District,CoverImage,Address,Description,Type,DealOfTheDay,AdvertisementDate,ProductStatus,ProductCategory,AppUserId) 
                           values (@Title,@Price,@City,@District,@CoverImage,@Address,@Description,@Type,@DealOfTheDay,@AdvertisementDate,@ProductStatus,@ProductCategory,@AppUserID)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createProductDto.Title);
            parameters.Add("@Price", createProductDto.Price);
            parameters.Add("@City", createProductDto.City);
            parameters.Add("@District", createProductDto.District);
            parameters.Add("@CoverImage", createProductDto.CoverImage);
            parameters.Add("@Address", createProductDto.Address);
            parameters.Add("@Description", createProductDto.Description);
            parameters.Add("@Type", createProductDto.Type);
            parameters.Add("@DealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("@AdvertisementDate", createProductDto.AdvertisementDate);
            parameters.Add("@ProductStatus", createProductDto.ProductStatus);
            parameters.Add("@ProductCategory", createProductDto.ProductCategory);
            parameters.Add("@AppUserID", createProductDto.AppUserId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay,SlugUrl From Product inner join Category on " +
                "Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast3ProductWithCategoryDto>> GetLast3ProductAsync()
        {
            string query = @"Select Top(3) ProductID,Title,SlugUrl,Description,Price,City,District,ProductCategory,CategoryName,CoverImage, AdvertisementDate from Product 
                           inner join Category On Product.ProductCategory = Category.CategoryID Order by ProductID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate from Product inner join Category On Product.ProductCategory = Category.CategoryID Where Type='Kiralık' Order by ProductID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEstateAgentDto>> GetProductAdvertListByEstateAgentAsyncByFalse(int id)
        {
            string query = "Select AppUserId,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay From Product inner join Category on " +
                "Product.ProductCategory=Category.CategoryID where AppUserID=@appUserID and ProductStatus=0;";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEstateAgentDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEstateAgentDto>> GetProductAdvertListByEstateAgentAsyncByTrue(int id)
        {
            string query = "Select ProductID,AppUserId,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay From Product inner join Category on " +
                "Product.ProductCategory=Category.CategoryID where AppUserID=@appUserID and ProductStatus=1;";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEstateAgentDto>(query,parameters);
                return values.ToList();
            }
        }

        public async  Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategoryAsync()
        {
            string query = @"Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay,SlugUrl From Product inner join Category on 
                Product.ProductCategory=Category.CategoryID Where DealOfTheDay = 1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetProductByProductIdDto> GetProductByProductId(int id)
        {
            string query = @"Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,Description,DealOfTheDay, 
                             AdvertisementDate, SlugUrl From Product inner join Category on 
                             Product.ProductCategory=Category.CategoryID where ProductID=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductByProductIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
           
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailByProductId(int id)
        {
            string query = @"Select * From ProductDetails Where ProductID =@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductDetailByIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product set DealOfTheDay=0 where ProductID=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product set DealOfTheDay=1 where ProductID=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
            
        }

        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            string query = @"Select * From Product Where Title like '%" + searchKeyValue + "%' And ProductCategory=@propertyCategoryId and City=@city";
            var parameters = new DynamicParameters();
            //parameters.Add("@searchKeyValue", searchKeyValue);
            parameters.Add("@propertyCategoryId", propertyCategoryId);
            parameters.Add("@city", city);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task DeleteProduct(int id)
        {
            string query = "Delete From Product Where ProductId = @productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> ResultProductCategoryByVilla()
        {
            string query = "Select * From Product where ProductCategory=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> ResultProductCategoryByDaire()
        {
            string query = "Select * From Product where ProductCategory=3";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> ResultProductCategoryByYazlik()
        {
            string query = "Select * From Product where ProductCategory=6";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}
