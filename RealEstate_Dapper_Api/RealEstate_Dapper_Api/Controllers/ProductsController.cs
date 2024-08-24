using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            await _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Günün Fırsatları Arasına Eklendi");
        }

        [HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            await _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Günün Fırsatları Arasından Çıkarıldı");
        }

        [HttpGet("GetLast5ProductAsync")]
        public async Task<IActionResult> GetLast5ProductAsync()
        {
            var values = await _productRepository.GetLast5ProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductAdvertsListByEstateAgentByTrue")]
        public async Task<IActionResult> ProductAdvertsListByEstateAgentByTrue(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEstateAgentAsyncByTrue(id);
            return Ok(values);
        }

        [HttpGet("ProductAdvertsListByEstateAgentByFalse")]
        public async Task<IActionResult> ProductAdvertsListByEstateAgentByFalse(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEstateAgentAsyncByFalse(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productRepository.CreateProduct(createProductDto);
            return Ok("İlan Başarıyla Eklendi");
        }

        [HttpGet("GetProductByProductId")]
        public async Task<IActionResult> GetProductByProductId(int id)
        {
            var values = await _productRepository.GetProductByProductId(id);
            return Ok(values);
        }

        [HttpGet("ResultProductWithSearchList")]
        public async Task<IActionResult> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            var values = await _productRepository.ResultProductWithSearchList(searchKeyValue, propertyCategoryId, city);
            return Ok(values);
        }

        [HttpGet("GetProductByDealOfTheDayTrueWithCategory")]
        public async Task<IActionResult> GetProductByDealOfTheDayTrueWithCategoryAsync()
        {
            var values = await _productRepository.GetProductByDealOfTheDayTrueWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("GetLast3Product")]
        public async Task<IActionResult> GetLast3Product()
        {
            var values = await _productRepository.GetLast3ProductAsync();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
            return Ok("İlan başarılı bir şekilde silindi.");
        }

        [HttpGet("ResultProductCategoryByVilla")]
        public async Task<IActionResult> ResultProductCategoryByVilla()
        {
            var values = await _productRepository.ResultProductCategoryByVilla();
            return Ok(values);
        }

        [HttpGet("ResultProductCategoryByDaire")]
        public async Task<IActionResult> ResultProductCategoryByDaire()
        {
            var values = await _productRepository.ResultProductCategoryByDaire();
            return Ok(values);
        }
        [HttpGet("ResultProductCategoryByYazlik")]
        public async Task<IActionResult> ResultProductCategoryByYazlik()
        {
            var values = await _productRepository.ResultProductCategoryByYazlik();
            return Ok(values);
        }
    }
}
