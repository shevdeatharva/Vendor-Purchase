namespace VendorPurchaseProject.Models
{
    public class MaterialModel
    {
        public int Material_Id { get; set; }
        public string ?Code { get; set; }
        public string ShortTxt { get; set; }
        public string ReOrderLevel { get; set; }
        public string LongTxt { get; set; }
        public string MinOrderQuantity { get; set; }
        public string Unit { get; set; }
        public bool isActive { get; set; }
    }
}
