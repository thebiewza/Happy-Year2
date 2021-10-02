using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Hangman
{
    enum Menu
    {
        PlayGame = 1,
        Exit
    }
    class Program
    {
        static void Main(string[] args)
        {
            PrintMenuScreen();
            Console.ReadLine();
        }

        static void PrintMenuScreen() //เปิดหน้าเมนูหลัก
        {
            PrintMenuHeader();
            PrintListMenu();
            InputMenuFromKeyboard();
        }

        static void PrintMenuHeader() //โชว์คำพูด ทักทายเข้าเกม
        {
            Console.WriteLine("Welcome to Hangman Game \n ----------------------------------------");
        }

        static void PrintListMenu() //หน้าตัวเลือกเมนู
        {
            Console.WriteLine("1. Play game.");
            Console.WriteLine("2. Exit.");
        }

        static void InputMenuFromKeyboard() //หน้าดารเลือกเมนู 1.เล่นเกม หรือ 2.ออก
        {
            Console.Write("Please Select Menu : ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            ActivateMenu(menu);
        }

        static void ActivateMenu(Menu menu) //โปรแกรมส่งไปยังหน้าต่างๆ
        {
            if (menu == Menu.PlayGame)
            {
                ShowPlayGameScreen();
            }
            else if (menu == Menu.Exit)
            {
                Console.ReadLine();
            }
            else
            {
                ShowInputMenuAgain();
            }
        }
        
        static void ShowInputMenuAgain() //หน้าแสดงข้อมูลการกรอกข้อมูลผิด นอกเหนือจากที่กำหนดให้
        {
            Console.WriteLine("Menu is incorrect, Please try again.");
            Console.ReadLine();
            Console.Clear();

            InputMenuFromKeyboard();
        }

        static void ShowPlayGameScreen() //หน้าเริ่มเกม
        {
            PrintPlayGameHeader();
            RandomWord();
        }

        static void PrintPlayGameHeader() //พาดหัว แสดงสถานะหน้าเล่นเกม
        {
            Console.Clear();
            Console.WriteLine("Play Game Hangman \n----------------------------------------");
        }


        static void RandomWord() //โปรแกรมสุ่มคำถาม และแปลงเป็นเส้นประ
        {
            string[] words = new string[3];
            words[0] = "tennis";
            words[1] = "football";
            words[2] = "badminton";

            Random random = new Random();
            int ResultRandom = random.Next(0,words.Length);
            string mysteryWords = words[ResultRandom];

            char[] guessWords = new char[mysteryWords.Length];

            for (int i = 0; i < mysteryWords.Length; i++)
            {
                guessWords[i] = '-';
            }

            StartGame(mysteryWords, guessWords);
        }

        static void StartGame(string mysteryWords, char[] guessWords) //Interface การเล่นเกม
        {
            int count = 0;
            int Trueletters = 0;

            bool IsWon = false;
            
            do
            {
                PrintPlayGameHeader();

                Console.WriteLine("Incorrect Score : {0}", count);
                Console.WriteLine(guessWords); 
                Console.Write("Input letter alphabet : ");
                
                char playerGuess = char.Parse(Console.ReadLine());

                if (mysteryWords.Contains(playerGuess))
                {
                    for (int j = 0; j < mysteryWords.Length; j++)
                    {
                        if (playerGuess == mysteryWords[j])
                        {
                            guessWords[j] = playerGuess;
                            Trueletters++;
                        }
                    }

                    if (Trueletters == mysteryWords.Length)
                    {
                        IsWon = true;
                    }
                }
                else
                {
                    count += 1;
                }
            } while (count <= 7 && !IsWon);

            if (IsWon = true)
            {
                Console.WriteLine(guessWords);
                WinScreen();
            }
            else
            {
                GameOverScreen();
            }
            Console.ReadLine();
        }
        
        static void WinScreen() //การแสดงสถานะ "ชนะ"
        {
            Console.WriteLine("Congratulations. You win!!");
        }

        static void GameOverScreen() //การแสดงสถานะ "แพ้"
        {
            Console.WriteLine("Game over.");
        }
    }
}
