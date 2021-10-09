using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Menu
{
    RegisterNewStudent = 1,
    RegisterNewTeacher,
    GetUserDetails
}

namespace RegisterSystem
{
    class Program
    {
        static PersonList personList;

        static void PreparePersonListWhenProgramIsLoad()
        {
            Program.personList = new PersonList();
        }
        static void Main(string[] args)
        {
            PrintMenuScreen();
        }
        static void PrintMenuScreen()
        {
            Console.Clear();
            PrintMainHeader();
            PrintMainMenu();
            InputMenuFromKeyboard();
        }
        static void PrintMainHeader()
        {
            Console.WriteLine("Welcome to Student Activities Registration System Program.");
            Console.WriteLine("----------------------------------------------------");
        }
        static void PrintMainMenu()
        {
            Console.WriteLine("1. Register New Student Account.");
            Console.WriteLine("2. Register New Teacher Account.");
            Console.WriteLine("3. Get User Details.");
        }
        static void InputMenuFromKeyboard()
        {
            Console.Write("Please Select Menu : ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }
        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.RegisterNewStudent)
            {
                ShowInputRegisterNewStudentScreen();
            }
            else if (menu == Menu.RegisterNewTeacher)
            {
                ShowInputRegisterNewTeacherScreen();
            }
            else if (menu == Menu.GetUserDetails)
            {
                ShowGetUserDrtailsScreen();
            }
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }
        }
        static void ShowInputRegisterNewStudentScreen()
        {
            Console.Clear();
            PrintHeaderRegisterStudent();
            InputNewStudentFromKeyboard();

            Console.Clear();
            PrintMainMenu();
        }

        static void PrintHeaderRegisterStudent()
        {
            Console.WriteLine("Register new student.");
            Console.WriteLine("---------------------");
        }
        static void InputNewStudentFromKeyboard()
        {
            Student student = CreateNewStudentAccount();
        }
        static Student CreateNewStudentAccount()
        {
            return new Student(InputNaame(), InputPassword(), InputStudemtID());
        }


        static void ShowInputRegisterNewTeacherScreen()
        {
            Console.Clear();
            PrintHeaderRegisterTeacher();
            InputNewTeacherFromKeyboard();

            Console.Clear();
            PrintMainMenu();
        }
        static void PrintHeaderRegisterTeacher()
        {
            Console.WriteLine("Register new Teacher.");
            Console.WriteLine("---------------------");
        }
        static void InputNewTeacherFromKeyboard()
        {
            Teacher teacher = CreateNewTeacherAccount();
        }
        static Teacher CreateNewTeacherAccount()
        {
            return new Teacher(InputNaame(), InputPassword(), InputEmployeeID());
        }

        static string InputNaame()
        {
            Console.Write("Please Input Name :");
            return Console.ReadLine();
        }
        static string InputPassword()
        {
            Console.Write("Please Input Password : ");
            return Console.ReadLine();
        }
        static String InputStudemtID()
        {
            Console.Write("Please Input Student ID : ");
            return Console.ReadLine();
        }
        static string InputEmployeeID()
        {
            Console.WriteLine("Please Input Employee ID : ");
            return Console.ReadLine();
        }

        static void ShowGetUserDrtailsScreen()
        {
            Console.Clear();
            Program.personList.ShowUserDetail();
            InputExitFromKeyboard();
        }
        static void InputExitFromKeyboard()
        {
            string text = "";
            Console.WriteLine("Do you want to Exit? (Yes/No) : ");

            if (text == "yes" || text == "Yes")
            {
                EndScreen();
            }
            else
            {
                Console.Clear();
                PrintMenuScreen();
            }
        }
        static void EndScreen()
        {
            Console.WriteLine("\nSee you next time.");
        }

        static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu Incorrect Please try again.");
            InputMenuFromKeyboard();
        }

    }

    class Person
    {
        protected string Name;
        protected string Password;

        public Person(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public string GetName()
        {
            return this.Name;
        }
    }

    class Student: Person
    {
        private string StudentID;

        public Student(string name, string password, string studentID): base(name, password)
        {
            this.StudentID = studentID;
        }

        public string GetStudentID()
        {
            return this.StudentID;
        }
    }
    class Teacher: Person
    {
        private string EmployeeID;

        public Teacher(string name, string password, string employeeID): base(name, password)
        {
            this.EmployeeID = employeeID;
        }
        public string GetEmployeeID()
        {
            return this.EmployeeID;
        }
    }

    class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            this.personList = new List<Person>();
        }

        public void ShowUserDetail()
        {
            Console.WriteLine("User Details");
            Console.WriteLine("---------------------");

            foreach (Person person in this.personList)
            {
                if (person is Student student)
                {
                    Console.WriteLine("Name : {0} \nStatus : Student \nStudent ID : {1}", person.GetName(), student.GetStudentID());
                }
                else if (person is Teacher teacher)
                {
                    Console.WriteLine("Name : {0} \nStatus : Teacher \nStudent ID : {1}", person.GetName(), teacher.GetEmployeeID());
                }
            }
        }
    }
}
