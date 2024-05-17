using API.Models;
using API.ViewVM;
using API.ViewVM.Order;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly aloooContext _context;
        private readonly IMapper _mapper;

        public OrderController(aloooContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("OrderDE/All")]
        public IActionResult GetAllOrder()
        {
            List<Order> orders = _context.Orders
                  .Include(x => x.Employee)
                .Include(x => x.Customer)
                .Include(x => x.OrderDetails)
                .ToList();

            var o = _mapper.Map<List<OrderVM>>(orders);
            return Ok(o);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            List<Order> orders = _context.Orders
                .Include(x => x.Employee)
                .Include(x => x.Customer)
                .Include(x => x.OrderDetails)
                .Include(x => x.ShipViaNavigation)
                .Where(x => x.OrderId == id)
                .ToList();


            var c = _mapper.Map<List<OrderVM>>(orders);
            return Ok(c);



        }
        [HttpGet]
        public IActionResult GetOrder()
        {
            List<Order> orders = _context.Orders
                .Include(x => x.Employee)
                .Include(x => x.Customer)
                .Include(x => x.OrderDetails)
                .Include(x => x.ShipViaNavigation)
                .ToList();


            var c = _mapper.Map<List<OrderVM>>(orders);
            return Ok(c);



        }

        [HttpGet("ByEmployee/{id}")]

        public IActionResult GetOrderByEmployee(int id)
        {
            List<Order> orders = _context.Orders
                .Include(x => x.Employee)
                .Include(x => x.Customer)
                .Include(x => x.OrderDetails)
                .Include(x => x.ShipViaNavigation)
                .Where(x => x.EmployeeId == id)
                .ToList();
            var c = _mapper.Map<List<OrderVM>>(orders);
            return Ok(c);
        }


        [HttpGet("ByCustomer/{id}")]
        public IActionResult GetOrderByCustomer(string id)
        {
            List<Order> orders = _context.Orders
               .Include(x => x.Employee)
               .Include(x => x.Customer)
               .Include(x => x.OrderDetails)
               .Include(x => x.ShipViaNavigation)
               .Where(x => x.CustomerId == id)
               .ToList();
            var c = _mapper.Map<List<OrderVM>>(orders);
            return Ok(c);
        }

        [HttpGet("{from}/{to}")]

        public IActionResult GetOrderBydate(DateTime from, DateTime to)
        {
            List<Order> orders = _context.Orders
               .Include(x => x.Employee)
               .Include(x => x.Customer)
               .Include(x => x.OrderDetails)
               .Include(x => x.ShipViaNavigation)
               .Where(x => x.OrderDate >= from && x.OrderDate <= to)
               .ToList();

            var result = _mapper.Map<List<OrderVM>>(orders);


            return Ok(result);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            DeteledVM data = new DeteledVM();
            try
            {
                //tim list orderdetail
                List<OrderDetail> orderdetail = _context.OrderDetails.Where(x => x.OrderId == id).ToList();

                _context.OrderDetails.RemoveRange(orderdetail);
                int OrderDetailsDeletedCount = _context.SaveChanges();
                Order orders = _context.Orders.FirstOrDefault(x => x.OrderId == id);
                if (orders == null)
                {
                    return BadRequest("Product not exist in db");
                }

                _context.Orders.Remove(orders);



                int countOrdersDeleted = _context.SaveChanges();
                
                data.countOrderDetailDeleted = OrderDetailsDeletedCount;
                data.countOrdersDeleted = OrderDetailsDeletedCount;

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetailById(int id)
        {
            List<OrderDetail> orders = _context.OrderDetails
               
               .Where(z => z.OrderId == id)
                .ToList();


            var c = _mapper.Map<List<OrderDetailVm>>(orders);
            return Ok(c);



        }

        [HttpPost("Add")]

        public IActionResult AddOrder(OrderAdd order)
        {

            Order p = _mapper.Map<Order>(order);

            _context.Orders.Add(p);
            _context.SaveChanges();

            return Ok(p);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(OrderVM category)
        {
            Order c = _context.Orders.FirstOrDefault(x => x.OrderId == category.OrderId);
            if (c == null) return NotFound();
            c.CustomerId = category.CustomerId;
            c.EmployeeId = category.EmployeeId;
            c.OrderDate = category.OrderDate;
            c.RequiredDate = category.RequiredDate;
            c.ShippedDate = category.ShippedDate;
            c.ShipVia = category.ShipVia;
            c.ShipAddress = category.ShipAddress;

            
            _context.SaveChanges();
            return Ok();
        }

    }
}
