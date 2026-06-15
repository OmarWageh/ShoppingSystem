
List<string> Cartitems = new List<string>();//User Shopping Cart

Dictionary<string, double> ItemPrices = new Dictionary<string, double>()  //The stock
{
    {"Camera",1500},
    {"laptop",1500.4},
    {"TV",8567},
    {"Car",200}
};
Console.WriteLine("Welcome to the Shopping System ");
Console.WriteLine("==============================");
while (true)
{
    Console.WriteLine("======================================");
    Console.WriteLine("Please Choice what you want to do ?");
    Console.WriteLine("======================================");
    Console.WriteLine("1- Add Item To Cart");
    Console.WriteLine("2- View Cart");
    Console.WriteLine("3- Remove Item From Cart");
    Console.WriteLine("4- CheckOut");
    Console.WriteLine("5- Undo Last Action");
    Console.WriteLine("6- Exit");
    Console.WriteLine("======================================");
    Console.Write("please Enter Your Choice Number: ");
    int Number = int.Parse(Console.ReadLine());
    switch (Number)
    {
        case 1:
            AddItem();
            break;
        case 2:
            ViewCart();
            break;
        case 3:
            RemoveItem();
            break;
        case 4:
            CheckOut();
            break;
        case 5:
            Undo();
            break;
        case 6:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid Code Entered, please try again ");
            break;
    }

}

void Undo()
{

}

void CheckOut()
{

}

void RemoveItem()
{
    Console.Write("Please Enter Item Name:");
    string ItemName = Console.ReadLine();
    if (Cartitems.Contains(ItemName))
    {
        Cartitems.Remove(ItemName);
    }
}

void AddItem()
{
    Console.WriteLine("Avaiable Items");
    foreach (var item in ItemPrices)
    {
        Console.WriteLine($"Item: {item.Key} Price: {item.Value}");
    }
    Console.Write("Please Enter The Product Name: ");
    string CartItem = Console.ReadLine();
    if (ItemPrices.ContainsKey(CartItem))
    {
        Cartitems.Add(CartItem);
        Console.WriteLine($"Item {CartItem} is added to your card");
    }
    else
    {
        Console.WriteLine("Item is out of stock or not avaible");
    }

}
void ViewCart()
{
    if (Cartitems.Any())
    {
        foreach (var item in Cartitems)
        {
            Console.WriteLine($"items: {item}");
        }
    }
    else
    {
        Console.WriteLine("Cart is Empty");
    }
}
void GetCartPrices()
{
    var CartPrices = new List<Tuple<string, double>>();
    foreach (var item in Cartitems)
    {
        double price = 0;
        bool foundItem = ItemPrices.TryGetValue(item, out price);
        if (foundItem)
        {

        }
    }
}