using VendorPurchaseProject.Models.ModelDTO;

namespace VendorPurchaseProject.Models
{
    public class PurchaseModel
    {
        public int OrderNo { get; set; }
        public string PCode { get; set; }
        public string MCode { get; set; }
        public string Vendor { get; set; }
        public string ShortTxt { get; set; }
        public string Expected_Date { get; set; }
        public string OrderDate { get; set; }
        public string  OrderValue { get; set; }
        public string Notes { get; set; }   
        public string Quantity { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
        public string Unit { get; set; }
        public List<PurchaseItem> PurchaseItems { get; set; }
    }
    
}
