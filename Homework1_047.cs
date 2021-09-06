using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1__Remaster
{
    class Tshirt
    {
        public string size;
        public string color;
        public float price;
        public string image;

        public Tshirt(string valueSize, string valueColor, float valuePrice, string valueImage)
        {
            size = valueSize;
            color = valueColor;
            price = valuePrice;
            image = valueImage;
        }
        public void ShowTshirt()
        {
            Console.WriteLine("size : {0}", this.size);
            Console.WriteLine("color : {0}", this.color);
            Console.WriteLine("image : {0}", this.image);
            Console.WriteLine("price : {0}", this.price);
            Console.WriteLine("-----------------------------------");

        }
    }
    class User
    {
        public string name;
        public string Email;
        public ShoppingCart shopingCart;

        public User(string valueName, string valueEmail, ShoppingCart valueShoppingCart)
        {
            name = valueName;
            Email = valueEmail;
            shopingCart = valueShoppingCart;

        }
        public void UserOutput()
        {
            Console.WriteLine("name : {0}", this.name);
            Console.WriteLine("email : {0}", this.Email);
        }
    }
    class address
    {
        public string street;
        public string city;
        public string zipCode;
        public address(string valueStreet, string valueCity, string valueZipcode)
        {
            street = valueStreet;
            city = valueCity;
            zipCode = valueZipcode;
        }

        public void AddressOutput()
        {
            Console.WriteLine("131 / 75. {0}, {1}, {2}", this.street, this.city, this.zipCode);
        }
    }
    class ShoppingCart
    {
        public List<Tshirt> OrderTshirt;
        public address UserAddress;

        public float TotalPrice = 0f;

        public ShoppingCart(address valueUserAddress)
        {
            OrderTshirt = new List<Tshirt>();
            UserAddress = valueUserAddress;
        }
        public void AddTshirt(Tshirt tshirt)
        {
            OrderTshirt.Add(tshirt);
        }
        public void TotalPriceOutput()
        {
            foreach (Tshirt tshirt in OrderTshirt)
            {
                TotalPrice += tshirt.price;
            }
            Console.WriteLine("Total Price : {0} THB.", TotalPrice);
        }
            
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tshirt orderA = new Tshirt("L", "Red", 500f, "Red is so cute");
            Tshirt orderB = new Tshirt("M", "Black", 750f, "Black is the BEST!! ");
            Tshirt orderC = new Tshirt("S", "Green", 625f, "Natural Green");
            
            address JameAddress = new address("Phutthamonthon Road", "Nakhon Pathom", "10180");
            
            ShoppingCart AllItem = new ShoppingCart(JameAddress);
            
            User Jame = new User("Jame Watson", "jame@gmail.com", AllItem);

           
            Jame.shopingCart.AddTshirt(orderA);
            Jame.shopingCart.AddTshirt(orderB);
            Jame.shopingCart.AddTshirt(orderC);

            orderA.ShowTshirt();
            orderB.ShowTshirt();
            orderC.ShowTshirt();

            Jame.UserOutput();
            JameAddress.AddressOutput();

            Jame.shopingCart.TotalPriceOutput();

            Console.ReadLine();
        }
    }
}
