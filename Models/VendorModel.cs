namespace VendorPurchaseProject.Models
{
    public class VendorModel
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }

        public string ValidTill { get; set; }
        public string Contact { get; set; }
        public string AddressLine2 { get; set; }
        public bool isChecked { get; set; }
        public string OrderDate { get; set; }
    }
}
