namespace API.ViewVM
{
    public class OrderDE
    {
        public int OrderId { get; set; }
     
        public string EmployeeName { get; set; }


        
        public string CustomerName { get; set; }

        public DateTime? OrderDate { get; set; }

        public int TotalAmount { get; set; }

        public int TotalItem { get; set; }
    }
}
