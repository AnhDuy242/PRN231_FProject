namespace API.ViewVM
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {
            Products = new HashSet<ProductVM>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        //public byte[]? Picture { get; set; }

        public virtual ICollection<ProductVM> Products { get; set; }
    }
}
