using System;
class Products
{
    public int Id;
    public string Name;
    public int Price;
    public int Stock;
    public int discount;

    public void Details()
    {
        Console.WriteLine("Product id  is " + Id);
        Console.WriteLine("Product Name is " + Name);
        Console.WriteLine("Product price is " + Price);
        Console.WriteLine("Available Stock " + Stock);
    }
    public virtual void Discount()
    {
        Console.WriteLine("Discount is ");

    }


}
class Electronic:Products
{
    public int Warrranty;
    public string Brand;
    public override void Discount()
    {
        discount = Price * 40 / 100;
        Price = Price - discount;
        Console.WriteLine("Price after Discount is "+Price);
    }
}
class Clothing:Products
{
    public string size;
    public string fabric;
    public override void Discount()
    {
        discount = Price * 20 / 100;
        Price = Price - discount;
        Console.WriteLine("Price after Discount is " + Price);
    }
}
/*public class Run
{
    public static void Main(string[] args)
    {
        *//*Electronic Gyser = new Electronic();
        Gyser.Name = "G1HOT";
        Gyser.Brand = "Havels";
        Gyser.Warrranty = 1;
        Gyser.Stock = 10;
        Gyser.Price = 4000;
        Gyser.Id = 101;
        Gyser.Details();
        Gyser.Discount();*//*


        
    }
}
*/

