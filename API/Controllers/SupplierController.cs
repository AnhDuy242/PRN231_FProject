using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.ViewVM;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly aloooContext _context;
        private readonly IMapper _mapper;


        public SupplierController(aloooContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetAllSupplier()
        {
            List<Supplier> supplier = _context.Suppliers.ToList();

            var s = _mapper.Map<List<Supplier>>(supplier);

            return Ok(s);
        }

        [HttpGet("{id}")]
        public IActionResult GetSupplierById(int id)
        {
            List<Supplier> supplier = _context.Suppliers
                .Where(x => x.SupplierId == id)
                .ToList();

            var s = _mapper.Map<List<Supplier>>(supplier);

            return Ok(s);
        }


        [HttpPost("Add")]
        public IActionResult AddSupplier(SupplierAdd supplier)
        {
            Supplier s = _mapper.Map<Supplier>(supplier);

            _context.Suppliers.Add(s);
            _context.SaveChanges();

            return Ok(s);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSupplier(SupplierVM supplier)
        {
            Supplier c = _context.Suppliers.FirstOrDefault(x => x.SupplierId == supplier.SupplierId);
            if (c == null) return NotFound();
            c.CompanyName = supplier.CompanyName;
            c.ContactName = supplier.ContactName;
            c.Phone = supplier.Phone;
            c.Fax = supplier.Fax;
            c.Region = supplier.Region;
            c.Country = supplier.Country;
            c.ContactTitle = supplier.ContactTitle;
            c.Address = supplier.Address;
            c.City = supplier.City;
            c.PostalCode = supplier.PostalCode;
            c.Country = supplier.Country;
            c.HomePage = supplier.HomePage;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            List<Product> products = _context.Products.Where(x => x.SupplierId == id).ToList();
            foreach (Product product in products)
            {
                List<OrderDetail> orderdetail = _context.OrderDetails.Where(x => x.ProductId == product.ProductId).ToList();

                _context.OrderDetails.RemoveRange(orderdetail);
            }
            _context.RemoveRange(products);

            Supplier supplier = _context.Suppliers.FirstOrDefault(x => x.SupplierId == id);

            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
            return Ok();
        }
    }
}
