using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        } 

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44353/api/Products/ProductListWithCategory");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, string city, int propertyCategoryId)
        {
            searchKeyValue = TempData["searchKeyValue"].ToString();
            city = TempData["city"].ToString();
            propertyCategoryId = int.Parse(TempData["propertyCategoryId"].ToString()); 
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44353/api/Products/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDtos>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            id = 1;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44353/api/Products/GetProductByProductId?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductDtos>(jsonData);

            var responseMessage2 = await client.GetAsync("https://localhost:44353/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDtos>(jsonData2);

            ViewBag.productID = values.productID;
            ViewBag.title1 = values.title.ToString();
            ViewBag.price = values.price;
            ViewBag.city = values.city;
            ViewBag.district = values.district;
            ViewBag.address = values.address;
            ViewBag.type = values.type;
            ViewBag.description = values.description;
            ViewBag.advertisementDate = values.AdvertisementDate;

            ViewBag.builtYear = values2.buildYear;
            ViewBag.bedroomCount = values2.bedRoomCount;
            ViewBag.bathCount = values2.bathCount;
            ViewBag.productSize = values2.productSize;
            ViewBag.roomCount = values2.roomCount;
            ViewBag.garageSize = values2.garageSize;
            ViewBag.location = values2.location;
            ViewBag.videoUrl = values2.videoUrl;

            

            DateTime date1 = DateTime.Now;
            DateTime date2 = values.AdvertisementDate;

            TimeSpan timespan = date1 - date2;
            int month = timespan.Days;
            ViewBag.dateDiff = month / 30;

            return View(values);

        }
    }
}
