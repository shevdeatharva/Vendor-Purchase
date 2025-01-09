using Dapper;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Data;
using VendorPurchaseProject.DBHandler;
using VendorPurchaseProject.Models;
using VendorPurchaseProject.Models.ModelDTO;

namespace VendorPurchaseProject.Controllers
{
    public class Form_MasterController : Controller
    {
        private readonly IDBService _dbService;

        public Form_MasterController(IDBService dbService)
        {
            _dbService = dbService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VendorMaster()
        {
            return View();
        }
        public IActionResult PurchaseMaster()
        {
            return View();
        }
        public IActionResult MaterialMaster()
        {
            return View();
        }
        [HttpPost]
        public async Task<List<VendorModel>> GetVendorDataByVendorCode([FromBody] VendorModel vendorDetail)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Code", vendorDetail.Code);
            var vendorData = await _dbService.GetAll<VendorModel>("sp_get_vp_Vendor__Master_Detail_ByCode", parameters);
            return vendorData;
        }
        [HttpPost]
        public async Task<JsonResult> SaveVendorDetail([FromBody] VendorDTO vendorDetail)
        {
            if (ModelState.IsValid)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", vendorDetail.Name);
                parameters.Add("@Email", vendorDetail.Email);
                parameters.Add("@AddressLine1", vendorDetail.AddressLine1);
                parameters.Add("@ValidTill", vendorDetail.ValidTill);
                parameters.Add("@Contact", vendorDetail.Contact);
                parameters.Add("@AddressLine2", vendorDetail.AddressLine2);
                parameters.Add("@isChecked", vendorDetail.isChecked);
                parameters.Add("@NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _dbService.EditData("sp_ins_vp_Vendor_Master", parameters);
                var res = parameters.Get<int>("@NewId");
                var result = new { success = true, message = res };
                return Json(result);
            }
            else
            {
                var result = new { success = false, message = "Invalid data." };
                return Json(result);
            }
        }
        [HttpPost]
        public async Task<JsonResult> DeleteVendorDetail([FromBody] VendorModel vendorDetail)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Code", vendorDetail.Code);
                parameters.Add("@NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _dbService.EditData("sp_del_vp_Vendor_Master", parameters);
                var res = parameters.Get<int>("@NewId");
                var result = new { success = true, message = res };
                return Json(result);
            }
            catch (Exception ex)
            {
                var result = new { success = false, message = ex.Message };
                return Json(result);
            }
        }
        [HttpPost]
        public async Task<JsonResult> UpdateVendorDetail([FromBody] VendorModel vendorDetail)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Code", vendorDetail.Code);
                parameters.Add("@Name", vendorDetail.Name);
                parameters.Add("@Email", vendorDetail.Email);
                parameters.Add("@AddressLine1", vendorDetail.AddressLine1);
                parameters.Add("@ValidTill", vendorDetail.ValidTill);
                parameters.Add("@Contact", vendorDetail.Contact);
                parameters.Add("@AddressLine2", vendorDetail.AddressLine2);
                parameters.Add("@isChecked", vendorDetail.isChecked);
                parameters.Add("@NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _dbService.EditData("sp_upd_vp_Vendor_Master", parameters);
                var res = parameters.Get<int>("@NewId");
                var result = new { success = true, message = res };
                return Json(result);
            }
            catch (Exception ex)
            {
                var result = new { success = false, message = ex.Message };
                return Json(result);
            }
        }
        [HttpPost]
        public async Task<List<MaterialModel>> GetMaterialDataByVendorCode([FromBody] MaterialModel vendorDetail)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Code", vendorDetail.Code);
            var vendorData = await _dbService.GetAll<MaterialModel>("sp_get_vp_Material__Master_Detail_ByCode", parameters);
            return vendorData;
        }
        [HttpPost]
        public async Task<JsonResult> SaveMaterialDetail([FromBody] MaterialDTO materialDetail)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ShortTxt", materialDetail.ShortTxt);
                parameters.Add("@LongTxt", materialDetail.LongTxt);
                parameters.Add("@ReorderLevel", materialDetail.ReOrderLevel);
                parameters.Add("@MinOrderQuantity", materialDetail.MinOrderQuantity);
                parameters.Add("@Unit", materialDetail.Unit);
                parameters.Add("@isActive", materialDetail.isActive);
                parameters.Add("@NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _dbService.EditData("sp_ins_vp_Material_Master", parameters);
                var res = parameters.Get<int>("@NewId");
                var result = new { success = true, message = res };
                return Json(result);
            }
            catch (Exception ex)
            {
                var result = new { success = false, message = ex.Message };
                return Json(result);
            }
        }
        [HttpPost]
        public async Task<JsonResult> DeleteMaterialDetail([FromBody] MaterialModel materialDetail)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Code", materialDetail.Code);
                parameters.Add("@NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _dbService.EditData("sp_del_vp_Material_Master", parameters);
                var res = parameters.Get<int>("@NewId");
                var result = new { success = true, message = res };
                return Json(result);
            }
            catch (Exception ex)
            {
                var result = new { success = false, message = ex.Message };
                return Json(result);
            }
        }
        [HttpPost]
        public async Task<JsonResult> UpdateMaterialDetail([FromBody] MaterialModel materialDetail)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Code", materialDetail.Code);
                parameters.Add("@ShortTxt", materialDetail.ShortTxt);
                parameters.Add("@LongTxt", materialDetail.LongTxt);
                parameters.Add("@ReorderLevel", materialDetail.ReOrderLevel);
                parameters.Add("@MinOrderQuantity", materialDetail.MinOrderQuantity);
                parameters.Add("@Unit", materialDetail.Unit);
                parameters.Add("@isActive", materialDetail.isActive);
                parameters.Add("@NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _dbService.EditData("sp_upd_vp_Material_Master", parameters);
                var res = parameters.Get<int>("@NewId");
                var result = new { success = true, message = res };
                return Json(result);
            }
            catch (Exception ex)
            {
                var result = new { success = false, message = ex.Message };
                return Json(result);
            }
        }
        [HttpPost]
        public async Task<List<PurchaseModel>> GetPurchaseDataByVendorCode([FromBody] PurchaseModel vendorDetail)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrderNo", vendorDetail.OrderNo);
            var vendorData = await _dbService.GetAll<PurchaseModel>("sp_get_vp_Purchase_Master_Detail_ByCode", parameters);
            return vendorData;
        }
        [HttpPost]
        public async Task<JsonResult> SavePurchaseDetail([FromBody] PurchaseDTO purchaseDetail)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ShortTxt", purchaseDetail.ShortTxt);
                parameters.Add("@OrderDate", purchaseDetail.OrderDate);
                parameters.Add("@OrderValue", purchaseDetail.OrderValue);
                parameters.Add("@Quantity", purchaseDetail.Quantity);
                parameters.Add("@Amount", purchaseDetail.Amount);
                parameters.Add("@Rate", purchaseDetail.Rate);
                parameters.Add("@Name", purchaseDetail.Name);
                parameters.Add("@ValidTill", purchaseDetail.ValidTill);
                parameters.Add("@Notes", purchaseDetail.Notes);
                parameters.Add("@Unit", purchaseDetail.Unit);
                parameters.Add("@Code", purchaseDetail.Code);
                parameters.Add("@NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _dbService.EditData("sp_ins_vp_Purchase_Master", parameters);
                var res = parameters.Get<int>("@NewId");
                var result = new { success = true, message = res };
                return Json(result);
            }
            catch (Exception ex)
            {
                var result = new { success = false, message = ex.Message };
                return Json(result);
            }
        }

        [HttpPost]
        public async Task<JsonResult> DeletePurchaseDetail([FromBody] PurchaseModel purchaseDetail)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderNo", purchaseDetail.OrderNo);
                parameters.Add("@NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _dbService.EditData("sp_del_vp_Purchase_Master", parameters);
                var res = parameters.Get<int>("@NewId");
                var result = new { success = true, message = res };
                return Json(result);
            }
            catch (Exception ex)
            {
                var result = new { success = false, message = ex.Message };
                return Json(result);
            }
        }
        [HttpPost]
        public async Task<JsonResult> UpdatePurchaseDetail([FromBody] PurchaseModel purchaseDetail)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderNo", purchaseDetail.OrderNo);
                parameters.Add("@Code", purchaseDetail.Code);
                parameters.Add("@ShortTxt", purchaseDetail.ShortTxt);
                parameters.Add("@OrderDate", purchaseDetail.OrderDate);
                parameters.Add("@OrderValue", purchaseDetail.OrderValue);
                parameters.Add("@Quantity", purchaseDetail.Quantity);
                parameters.Add("@Amount", purchaseDetail.Amount);
                parameters.Add("@Rate", purchaseDetail.Rate);
                parameters.Add("@Name", purchaseDetail.Name);
                parameters.Add("@ValidTill", purchaseDetail.ValidTill);
                parameters.Add("@Notes", purchaseDetail.Notes);
                parameters.Add("@Unit", purchaseDetail.Unit);
                parameters.Add("@NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _dbService.EditData("sp_upd_vp_Purchase_Master", parameters);
                var res = parameters.Get<int>("@NewId");
                var result = new { success = true, message = res };
                return Json(result);
            }
            catch (Exception ex)
            {
                var result = new { success = false, message = ex.Message };
                return Json(result);
            }
        }
    }
}
