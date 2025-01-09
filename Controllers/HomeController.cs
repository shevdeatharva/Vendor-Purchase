using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VendorPurchaseProject.DBHandler;
using VendorPurchaseProject.Models;

namespace VendorPurchaseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDBService _dbService;

        public HomeController(ILogger<HomeController> logger, IDBService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }
       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult VendorDetailList()
        {
            return View();
        }
        public IActionResult MaterialEntryList()
        {
            return View();
        }
        public IActionResult POEntryList()
        {
            return View();
        }
        public async Task<List<VendorModel>> GetVendorData()
        {
            var vendorData = await _dbService.GetAll<VendorModel>("sp_get_vp_Vendor_Master", new { });
            return vendorData;
        }
        public async Task<List<MaterialModel>> GetMaterialData()
        {
            var materialData = await _dbService.GetAll<MaterialModel>("sp_get_vp_Material_Master", new { });
            return materialData;
        }
        public async Task<List<PurchaseModel>> GetPurchaseData()
        {
            var purchaseData = await _dbService.GetAll<PurchaseModel>("sp_get_vp_Purchase_Master", new { });
            return purchaseData;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}