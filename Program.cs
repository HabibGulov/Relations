// using (var db = new DatabaseContext())
// {
//     db.Database.EnsureCreated();

//     Category electronics = new Category { Name = "Electronics" };
//     Category groceries = new Category { Name = "Groceries" };

//     db.Categories.AddRange(electronics, groceries);
//     db.SaveChanges(); 

//     Product smartphone = new Product { Name = "Smartphone", Price = 699.99m, CategoryId = electronics.Id };
//     Product laptop = new Product { Name = "Laptop", Price = 999.99m, CategoryId = electronics.Id };
//     Product apple = new Product { Name = "Apple", Price = 0.99m, CategoryId = groceries.Id };
//     Product bread = new Product { Name = "Bread", Price = 1.49m, CategoryId = groceries.Id };

//     db.Products.AddRange(smartphone, laptop, apple, bread);
//     db.SaveChanges(); 
// }

using Microsoft.EntityFrameworkCore;

using (var db = new DatabaseContext())
{
    var coll = db.Products.Include(u=>u.Category).ToList();
    foreach(var i in coll)
    {
        System.Console.WriteLine(i.Id+ i.Category.Name);
    }
}