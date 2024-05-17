using API.Models;
using API.ViewVM;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

  
    public class ProductController : ControllerBase
    {
        private readonly aloooContext _context;
        private readonly IMapper _mapper;

        public ProductController(aloooContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       

        [HttpGet("GetAll")]
        public IActionResult GetAllProduct()
        {
            List<Product> products = _context.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier).Include(x => x.OrderDetails)
                .ToList();

            var p = _mapper.Map<List<ProductVM>>(products);
            return Ok(p);
        }

        [HttpGet("{id}")]

        public IActionResult GetProduct(int id)
        {
            List<Product> products = _context.Products.Where(x => x.CategoryId == id).ToList();

            var p = _mapper.Map<List<ProductVM>>(products);
            return Ok(p);
        }

       

    
        [HttpPost("Add")]

        public IActionResult AddProduct(ProductAdd product)
        {

            Product p = _mapper.Map<Product>(product);

            _context.Products.Add(p);
            _context.SaveChanges();

            return Ok(p);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(ProductVM product)
        {
            try
            {

                Product p = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (p == null) return NotFound();
                p.ProductName = product.ProductName;
                p.UnitPrice = product.UnitPrice;
                _context.SaveChanges();
            } catch (Exception ex)
            {
                return Ok(ex);
            }
            return Ok();
         
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            DeleteProductVM data = new DeleteProductVM();
            try
            {
                //tim list orderdetail
                List<OrderDetail> orderdetail = _context.OrderDetails.Where(x => x.ProductId == id).ToList();
                
                _context.OrderDetails.RemoveRange(orderdetail);
                int OrderDetailsDeletedCount = _context.SaveChanges();
                Product products = _context.Products.FirstOrDefault(x => x.ProductId == id);
                if (products == null)
                {
                    return BadRequest("Product not exist in db");
                }
              
                _context.Products.Remove(products);
             
              
                
                int ProductDetailDeteledCount = _context.SaveChanges();
                //data.OrderDeletedCount = OrderDeletedCount;
                data.ProductDetailsDeleteCount = ProductDetailDeteledCount;
                data.OrderDetailsDeleteCount = OrderDetailsDeletedCount;

            }catch (Exception ex)
            {
                return Ok(ex);
            }

            return Ok(data);
            
        }

        [HttpGet("SearchById/{id}")]
        public IActionResult GetProductById(int id)
        {
            List<Product> products = _context.Products.Where(x => x.ProductId == id).ToList();

            var p = _mapper.Map<List<ProductVM>>(products);
            return Ok(p);
        }

        [HttpGet("ProductDetail/{id}")]

        public IActionResult GetProductDetail(int id)
        {
            List<Product> products = _context.Products
                .Where(x => x.ProductId == id)
                .ToList();

            var p = _mapper.Map<List<ProductDetail>>(products);
            return Ok(p);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductDetail(ProductDetail product)
        {
            try
            {

                Product p = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (p == null) return NotFound();
                p.ProductName = product.ProductName;
                p.UnitPrice = product.UnitPrice;
                p.SupplierId = product.SupplierId;
                p.CategoryId = product.CategoryId;  
                p.QuantityPerUnit = product.QuantityPerUnit;    
                p.UnitPrice = product.UnitPrice;
                p.UnitsInStock = product.UnitsInStock;
                p.UnitsOnOrder = product.UnitsOnOrder;
                p.ReorderLevel = product.ReorderLevel;
                p.Discontinued = product.Discontinued;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
            return Ok();

        }

   
    }
}
