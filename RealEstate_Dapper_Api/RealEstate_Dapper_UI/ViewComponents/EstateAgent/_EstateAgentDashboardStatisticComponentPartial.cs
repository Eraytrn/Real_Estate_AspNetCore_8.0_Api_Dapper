using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;

            #region Statistic1 - ToplamİlanSayısı
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44353/api/EstateAgentDashboardStatistic/AllProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion

            #region Statistic2 - EmlakçınınToplamİlanSayısı
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44353/api/EstateAgentDashboardStatistic/ProductCountByEstateAgentId?id="+id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.estateAgentByProductCount = jsonData2;
            #endregion

            #region Statistic3 - AktifİlanSayısı
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44353/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id="+id);
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.productCountByEstateAgentByStatusTrue = jsonData3;
            #endregion

            #region Statistic4 - PasifİlanSayısı
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44353/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id="+id);
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.productCountByEstateAgentByStatusFalse = jsonData4;
            #endregion


            return View();
        }
    }
}
