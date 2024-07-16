
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new()
{
    new()
    {
        Name = "Sousaphone",
        Price = 350m,
        ProductTypeId = 1
    },
    new()
    {
        Name = "Trombone",
        Price = 256.75m,
        ProductTypeId = 1
    },
    new()
    {
        Name = "Euphonium",
        Price = 510.99m,
        ProductTypeId = 1
    },
    new()
    {
        Name = "Flugelhorn",
        Price = 119.19m,
        ProductTypeId = 1
    },
    new()
    {
        Name = "Jabberwocky",
        Price = 9.01m,
        ProductTypeId = 2
    },
    new()
    {
        Name = "O Captain! My Captain!",
        Price = 19.99m,
        ProductTypeId = 2
    },
    new()
    {
        Name = "And Still I Rise",
        Price = 27.65m,
        ProductTypeId = 2
    },
    new()
    {
        Name = "She Walks in Beauty",
        Price = 2.17m,
        ProductTypeId = 2
    },
    new()
    {
        Name = "Green Eggs and Ham",
        Price = 845.77m,
        ProductTypeId = 2
    }
};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new()
{
    new()
    {
        Title = "Brass",
        Id = 1
    },
    new()
    {
        Title = "Poem",
        Id = 2
    }
};

//put your greeting here
Console.Clear();
Console.WriteLine("Welcome to Brass & Poem!\nPurveyors of Mouthpieces since before you were born.\n");
//implement your loop here
string option = "menu";

while (option != "5")
{
    DisplayMenu();
    option = Console.ReadLine();

    Console.Clear();
    switch (option)
    {
        case "1":
            DisplayAllProducts(products, productTypes);
            break;
        case "2":
            DeleteProduct(products, productTypes);
            break;
        case "3":
            AddProduct(products, productTypes);
            break;
        case "4":
            UpdateProduct(products, productTypes);
            break;
        default:
            break;
    }
    Console.Clear();
}
Console.WriteLine("Come back soon!");

void DisplayMenu()
{
    Console.WriteLine("Select a menu option...\n");
    Console.WriteLine(@"1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("\nCurrent Inventory:");
    ListProducts();
    Console.WriteLine("\nPress any key to return to main menu...");
    Console.ReadKey();
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    while (true)
    {
        Console.WriteLine("\nDelete Product:");
        ListProducts();
        Console.Write("\nEnter index of product to delete (or type \"0\" to return to main menu): ");
        string deletion = Console.ReadLine();
        if (deletion == "0")
        {
            break;
        }
        else if (int.TryParse(deletion, out int deletionIndex)
            && deletionIndex >0
            && deletionIndex <= products.Count)
        {
            products.RemoveAt(deletionIndex - 1);
        }
        Console.Clear();
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    while (true)
    {
        products.Add(ProductForm(new Product()));
        ListProducts();
        Console.Write("Add another product? (y/n) ");
        string more = Console.ReadLine()?.ToLower() ?? "exit";
        if (more != "y") { break; }
        Console.Clear();
    }
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    while (true)
    {
        Console.WriteLine("Update Product");
        ListProducts();
        Console.Write("Enter index of product to update (or type \"0\" to return to main menu): ");
        string update= Console.ReadLine();
        if (update == "0")
        {
            break;
        }
        else if (int.TryParse(update, out int updateIndex)
            && updateIndex > 0
            && updateIndex <= products.Count)
        {
            Console.Clear();
            products[updateIndex - 1] = ProductForm(products[updateIndex - 1]);
        }
    }
}

void ListProducts()
{
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name} --- {products[i].Price:C} ({productTypes.First(t => t.Id == products[i].ProductTypeId).Title})");
    }
}

Product ProductForm(Product product)
{
    while (true)
    {
        Console.Write($"Enter product name{(product?.Name != null ? $" (Current: {product.Name})" : "")}: ");
        string newName = Console.ReadLine();
        if (newName != "") 
        {
            product.Name = newName;
            break;
        }
        else if (newName == "" && product.Name != null)
        {
            break;
        }
    }
    while (true)
    {
        Console.Write($"Enter price{(product?.Price > 0 ? $" (Current: {product.Price:C})" : "")}: $");
        string newPriceString = Console.ReadLine() ?? "price";
        if (decimal.TryParse(newPriceString, out decimal newPrice)
            && newPrice > 0)
        {
            product.Price = newPrice;
            break;
        }
        else if (newPriceString == "" && product.Price > 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid entry. Price must be a value greater than $0.00.");
        }
    }
    Console.WriteLine($"Select a product category{(product?.ProductTypeId > 0 ? $" (Current: {productTypes.First(t => t.Id == product.ProductTypeId).Title:C})" : "")}:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"\t{i + 1}. {productTypes[i].Title}");
    }
    while (true)
    {
        string type = Console.ReadLine() ?? "";
        if (int.TryParse(type, out int newType) && newType > 0 && newType <= productTypes.Count)
        {
            product.ProductTypeId = newType;
            break;
        }
        else if (type == "" && product.ProductTypeId > 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("Error. Please select valid category index to assign.");
        }
    }
    Console.Clear();
    return product;
}

// don't move or change this!
public partial class Program { }