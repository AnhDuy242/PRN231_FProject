﻿namespace MVC_Client.Model.Category
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        //public byte[]? Picture { get; set; }
    }
}
