using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalNo8
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowInputSkill();
        }

        static void ShowInputSkill()    //9.1
        {
            Console.WriteLine("Input Skill Name: ");
            string InputSkill = Console.ReadLine();
            if (InputSkill == "?")
            {
                //ไป 9.6
            }
            else
            {
                //9.2
                AddDependency(InputSkill);
            }
        }

        static void AddDependency(string skill) //9.2
        {
            Console.WriteLine("Add dependency for {0}? (Y/N): ", skill);
            char Ans = char.Parse(Console.ReadLine());

            if (Ans == 'Y')
            {
                //9.3
            }
            else if (Ans == 'N')
            {
                //9.1
                ShowInputSkill();
            }
        }
    }
}
