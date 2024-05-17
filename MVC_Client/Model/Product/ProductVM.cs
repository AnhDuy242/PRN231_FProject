namespace MVC_Client.Model.Product
{
    public class ProductVM
    {
        public ProductVM()
        {
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }


        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? SupplierId { get; set; }

        public string SupplierName { get; set; }


        public int TotalUnitSale { get; set; }


    }
}
