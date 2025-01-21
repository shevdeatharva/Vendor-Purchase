namespace VendorPurchaseProject.Models.ModelDTO
{
    public class PurchaseDTO
    {
        
        public string Vendor { get; set; }
        public string ShortTxt { get; set; }
        public string OrderDate { get; set; }
        public string OrderValue { get; set; }
        public string Notes { get; set; }
        public string Unit { get; set; }

        public List<PurchaseItem> PurchaseItems { get; set; }
    }
    public class PurchaseItem
    {
        public string MCode { get; set; }
        public string Quantity { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
        public string Expected_Date { get; set; }
    }
}
