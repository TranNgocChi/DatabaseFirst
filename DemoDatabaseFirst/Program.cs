using DemoDatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        MyStoreContext myStore = new MyStoreContext();
        var products = from p in myStore.Products select new {p.ProductName, p.CategoryId}; 
        foreach (var product in products)
        {
            Console.WriteLine($"ProductName: {product.ProductName}, CategoryID:{product.CategoryId}");
        }
        Console.WriteLine("-----------------------------------");
        IQueryable<Category> cats = myStore.Categories.Include(c => c.Products);
        foreach(Category category in cats)
        {
            Console.WriteLine($"CategoryID: {category.CategoryId}, CategoryID:{category.CategoryName}");
        }
    }
}