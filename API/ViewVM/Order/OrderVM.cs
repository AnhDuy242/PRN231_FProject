namespace API.ViewVM
{
    public class OrderVM
    {
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName {  get; set; }

    
        public string CustomerId {  get; set; }
        public string CustomerName { get; set; }

        public int ShipVia { get; set; }
        public string ShipCompanyName { get; set; }

        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public string? ShipAddress { get; set; }

        public int TotalAmount { get; set; }

        public Boolean? IsLateOrder { get; set; }
    }
}
