using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class EstateAgentPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
