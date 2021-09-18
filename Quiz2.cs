using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input Total Rose : ");
            int NumRose = int.Parse(Console.ReadLine());

            Console.Write("Input Total Sun Flower : ");
            int NumSunflower = int.Parse(Console.ReadLine());

            //----------------------------------------------//


            for (int i = 0; i < NumRose; i++)
            {
                InputRose();
                Console.WriteLine();
            }

            for (int j = 0; j < NumSunflower; j++)
            {
                InputSunflower();
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        static void InputRose()
        {
            Console.WriteLine("Input Rose\n----------\n");

            Console.Write("ID: ");
            int IDrose = int.Parse(Console.ReadLine());

            Console.Write("Plant Name: ");
            string PlantName = Console.ReadLine();

            Console.Write("Plant Description: ");
            string PlantDescription = Console.ReadLine();

            Console.Write("Amount: ");
            int Amount = int.Parse(Console.ReadLine());

            Console.Write("Height: ");
            string Height = Console.ReadLine();

            Console.Write("Circumference: ");
            string Circumference = Console.ReadLine();

            ListRose listRose = new ListRose(IDrose, PlantName, PlantDescription, Amount, Height, Circumference);
        }
        static void InputSunflower()
        {
            Console.WriteLine("Input Sun Flower\n----------\n");

            Console.Write("ID: ");
            int IDSunF = int.Parse(Console.ReadLine());

            Console.Write("Plant Name: ");
            string PlantName = Console.ReadLine();

            Console.Write("Plant Description: ");
            string PlantDescription = Console.ReadLine();

            Console.Write("Amount: ");
            int Amount = int.Parse(Console.ReadLine());

            Console.Write("Height: ");
            string Height = Console.ReadLine();

            Console.Write("Circumference: ");
            string Circumference = Console.ReadLine();

            ListSunFLower listSunFLower = new ListSunFLower(IDSunF, PlantName, PlantDescription, Amount, Height, Circumference);
        }
    }

    class ListFlower
    {
        public int IDFlower;
        public string NameFlower;
        public string Description;
        public int Amount;
        public string Height;
        public string Circumference;

        public ListFlower(int idFlower, string nameFlower, string description, int amount, string height, string circumference)
        {
            this.IDFlower = idFlower;
            this.NameFlower = nameFlower;
            this.Description = description;
            this.Amount = amount;
            this.Height = height;
            this.Circumference = circumference;
        }

    }

    class ListRose : ListFlower
    {
        public ListRose(int idFlower, string nameFlower, string description, int amount, string height, string circumference) : base(idFlower, nameFlower, description, amount, height, circumference)
        {
        }
        public string RoseInfo()
        {
            Console.WriteLine(this.NameFlower);
            return this.NameFlower;
        }
    }

    class ListSunFLower : ListFlower
    {
        public ListSunFLower(int idFlower, string nameFlower, string description, int amount, string height, string circumference) : base(idFlower, nameFlower, description, amount, height, circumference)
        {
        }
        public string SunFlowerInfo()
        {
            Console.WriteLine(this.NameFlower);
            return this.NameFlower;
        }
    }
}
