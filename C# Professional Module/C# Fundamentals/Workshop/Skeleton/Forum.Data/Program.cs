using Forum.Models;
using System;
using System.Collections.Generic;

namespace Forum.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Category category = new Category(1, "Category", new List<int> { 1, 2, 3 });
            List<Category> list = new List<Category>();
            list.Add(category);
            DataMapper.SaveCategories(list);
        }
    }
}
