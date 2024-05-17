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
    public class CategoryController : ControllerBase
    {

        private readonly aloooContext _context;
        private readonly IMapper _mapper;
        public CategoryController(aloooContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            List<Category> categories = _context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]

        public IActionResult GetCategory(int id)
        {
            List<Category> categories = _context.Categories.Where(x => x.CategoryId == id).ToList();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryVM category)
        {
            Category c = _mapper.Map<Category>(category);

            _context.Categories.Add(c);
            _context.SaveChanges();
            return Ok("success");
        }
        //public IActionResult DeleteCateagory(int id)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception e)
        //    {
        //        return Ok(e);
        //    }

        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            List<Product> p = _context.Products.Where(x => x.CategoryId == id).ToList();
            _context.Products.RemoveRange(p);
            _context.SaveChanges();

            Category c = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
       

            _context.Categories.Remove(c);
            _context.SaveChanges();
            return Ok();


        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(CategoryUpdate category)
        {
            Category c = _context.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (c == null) return NotFound();
            c.CategoryName = category.CategoryName;
            c.Description = category.Description;
            _context.SaveChanges();
            return Ok();
        }
    }
}
