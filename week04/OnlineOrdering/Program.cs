using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address brazilAddress = new Address("Bossa Nova", "Montes Claros", "Minas Gerais", "Brazil");
        Address chinaAddress = new Address("DouFu", "HePu", "GuangXi", "China");
        Address usaAddress = new Address("Melvintown", "Kansas", "Missouri", "USA");
        
        Customer carla = new Customer("Carla Schettini", brazilAddress);
        Customer liLong = new Customer("Li Long", chinaAddress);
        Customer faith = new Customer("Faith Black", usaAddress);

        Order carlaOrder = new Order(carla);
        carlaOrder.AddProduct(new Product("Ice Package", "D0134205i", 12.55, 5));
        carlaOrder.AddProduct(new Product("Orange Juice Gallon", "D0134225o", 4.75, 4));
        carlaOrder.AddProduct(new Product("Fine Meat Package", "D0134200f", 89.99, 12));
        carlaOrder.AddProduct(new Product("Barbecue Grill", "B0134289g", 50.20, 1));

        Order liLongOrder = new Order(liLong);
        liLongOrder.AddProduct(new Product("Fine Meat Package", "D0134200f", 89.99, 1));
        liLongOrder.AddProduct(new Product("Orange Juice Gallon", "D0134225o", 4.75, 1));

        Order faithOrder = new Order(faith);
        faithOrder.AddProduct(new Product("Orange Juice Gallon", "D0134225o", 4.75, 7));
        faithOrder.AddProduct(new Product("Ice Package", "D0134205i", 12.55, 3));

        List<Order> orders = new List<Order>() { carlaOrder, liLongOrder, faithOrder };

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine("Total Price: $" + order.GetTotalPrice());
            Console.WriteLine("---------------------------------------------");
        }
    }
}