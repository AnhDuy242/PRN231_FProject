﻿namespace API.ViewVM
{
    public class CategoryUpdate
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
