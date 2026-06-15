
List<string> Cartitems = new List<string>();//User Shopping Cart

Dictionary<string, double> ItemPrices = new Dictionary<string, double>()  //The stock
{
    {"Camera",1500},
    {"laptop",1500.4},
    {"TV",8567},
    {"Car",200},
    {"Mouse",124},
    {"Keyboard",789}
};
Stack <string> actions = new Stack<string>();
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


void RemoveItem()
{
    ViewCart();
    if (Cartitems.Any())
    {
        Console.Write("Please Select Item To Remove: ");
        string ItemToRemove = Console.ReadLine();
        if (Cartitems.Contains(ItemToRemove))
        {
            Cartitems.Remove(ItemToRemove);
            actions.Push($"Item {ItemToRemove} Remove From Card");
            Console.WriteLine($"Item: {ItemToRemove} Removed");
        }
        else
        {
            Console.WriteLine("Item dosnt Exist in Sopping Cart .");
        }
    }
    else
    {
        Console.WriteLine("The Cart Item is Empty.");
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
        actions.Push($"Item {CartItem} Add From Card");
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
        var Cartitems = GetCartPrice();
        foreach (var item in Cartitems)
        {
            Console.WriteLine($"items ==> Name: {item.Item1}  Price:{item.Item2} ");
        }
    }
    else
    {
        Console.WriteLine("Cart is Empty");
    }
}
IEnumerable<Tuple<string,double>> GetCartPrice()
{
    var CartPrices = new List<Tuple<string, double>>();
    foreach (var item in Cartitems)
    {
        double price = 0;
        bool foundItem = ItemPrices.TryGetValue(item, out price);
        if (foundItem)
        {
            Tuple<string, double> itemPrice = new Tuple<string, double>(item, price);
            CartPrices.Add(itemPrice);
        }
    }
    return CartPrices;
}
void CheckOut()
{
    if (Cartitems.Any())
    {
        double TotalPrice = 0;
        Console.WriteLine("Your cart Item Are.");
        IEnumerable<Tuple<string, double>> ItemsCart = GetCartPrice();
        foreach (var item in ItemsCart)
        {
            Console.WriteLine($"Item ==> Name:{item.Item1}   Price:{item.Item2}");
            TotalPrice += item.Item2;
        }
        Console.WriteLine($" TotalPrice to pay: {TotalPrice}");
        Console.WriteLine("Please Proceed to payment , Thank you for Shopping with us ");
    }
    else
    {
        Console.WriteLine("Your Cart is Empty.");
    }
    Cartitems.Clear();
    actions.Push("Checkout");
}
void Undo()
{
    if (actions.Count > 0)
    {
        string lastAction = actions.Pop();

        Console.WriteLine($"Your last action is {lastAction}");

        var actionArray = lastAction.Split();

        if (lastAction.Contains("added"))
        {
            Cartitems.Remove(actionArray[1]);
        }
        else if (lastAction.Contains("removed"))
        {
            Cartitems.Add(actionArray[1]);
        }
        else
        {
            Console.WriteLine("Check out cannot be undo, please ask for refund");
        }
    }
}