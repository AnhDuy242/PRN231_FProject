using API.Models;
using API.ViewVM;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly aloooContext _context;
        private readonly IMapper _mapper;

        public CustomerController(aloooContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("/GetAllCustomer")]
        public IActionResult GetAllCustomer()
        {
           List<Customer> customers = _context.Customers.ToList();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetSupplierById(string id)
        {
            List<Customer> customers = _context.Customers.Where(x => x.CustomerId == id).ToList();

            var s = _mapper.Map<List<Customer>>(customers);

            return Ok(s);
        }

    


    [HttpDelete("{CustomerId}")]
        public IActionResult Delete(string CustomerId)
        {
            DeteledVM vm = new DeteledVM();
            try
            {
                //phai xoa tu bang orderdetail
                //khoi tao mot doi tuong co kieu customer
                Customer c = _context.Customers.FirstOrDefault(x => x.CustomerId.ToLower() == CustomerId.ToLower());
                //check neu nhu c rong thi tra ve not found
                if (c == null)
                {
                    return NotFound($"{CustomerId} not found");
                }
                // tao mot list order 
                List<Order> orders = _context.Orders.Where(x => x.CustomerId.ToLower().Equals(CustomerId.ToLower())).ToList();
                // tao mot bien dung de dem so bang co the xoa
                int countOrderDetailDeleted = 0;
                //tao vong lap de loc ra bang ghi o trong bang OrderDetail
                foreach (Order order in orders)
                { //khoi tao mot list orderdetail khi Orderid o bang order trung voi orderid o bang orderdetails
                    List<OrderDetail> orderDetails = _context.OrderDetails.Where(x => x.OrderId == order.OrderId).ToList();
                    //xoa cac bang dung RemoveRange de xoa khoang cac bang trong khoang vua tim duoc 

                    _context.OrderDetails.RemoveRange(orderDetails);
                    // sau moi mot lan xoa thi se save mot lan va tiep tuc cong vao bien count
                    countOrderDetailDeleted += _context.SaveChanges();
                }

                //xoa cac ban ghi trong Order
                _context.Orders.RemoveRange(orders);
                int countOrderDeleted = _context.SaveChanges();

                //xoa cac ban ghi customer
                _context.Customers.Remove(c);
                int countCustomer = _context.SaveChanges();

                //tao mot bien de luu tru ban ghi va tra ve 

                vm.countOrderDeleted = countOrderDeleted;
                vm.countCustomer = countCustomer;
                vm.countOrderDetailDeleted = countOrderDetailDeleted;
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

            return Ok(vm);

        }


        [HttpPost("Add")]
        public IActionResult AddCustomer(CustomerVM customer)
        {
            Customer s = _mapper.Map<Customer>(customer);

            _context.Customers.Add(s);
            _context.SaveChanges();

            return Ok(s);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(CustomerVM customer)
        {
            Customer c = _context.Customers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
            if (c == null) return NotFound();
            c.CompanyName = customer.CompanyName;
            c.Address = customer.Address;
            c.City = customer.City;
            c.Region = customer.Region;
            c.PostalCode = customer.PostalCode;
            c.Country = customer.Country;
            c.Phone = customer.Phone;
            c.Fax = customer.Fax;
            c.ContactTitle = customer.ContactTitle;
            c.Country = customer.Country;
           
            _context.SaveChanges();
            return Ok();
        }
    }
}
