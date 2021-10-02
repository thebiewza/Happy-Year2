using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Menu
{
    Login = 1,
    Register,
}

namespace Midterm__Library
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMainMenuScreen();
        }

        static void PrintMainMenuScreen() //หน้าแรก App ห้องสมุด
        {
            Console.Clear();
            Console.WriteLine("Welcome to Digital Library. \n--------------------------");
            PrintListMainMenu();
            InputMenuFromKeyboard();
        }

        static void PrintListMainMenu() //เมนูที่เลือกได้
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
        }

        static PersonList personList;

        static void PreparePersonListWhenProgramIsLoad()
        {
            Program.personList = new PersonList();
        }

        static void InputMenuFromKeyboard() //รับค่าจากคีย์บอร์ด
        {
            Console.Write("Select Menu : ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }
        static void PresentMenu(Menu menu) //รันโปรแกรมเมื่อรับค่าจากคีย์บอร์ด
        {
            if (menu == Menu.Register)
            {
                ShowInputRegisterNewPersonScreen();
            }
            else if (menu == Menu.Login)
            {
                ShowInputLoginNewPersonScreen();
            }
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }
        }

        static void ShowInputRegisterNewPersonScreen() //หน้าโปรแกรม register account
        {
            Console.Clear();
            PrintHeaderRegisterPerson();
            ShowCreateNewPerson();
        }

        static void PrintHeaderRegisterPerson() //header หน้า register
        {
            Console.WriteLine("Register new Person.");
            Console.WriteLine("-------------------");
        }

        static void ShowCreateNewPerson() //ถามประเภพอาชีพผู้ใช้ ว่า 1. หรือ 2.
        {
            Console.Write("Input User Type (1 = Student, 2 = Employee) : ");
            int Type = int.Parse(Console.ReadLine());

            if (Type == 1)
            {
                CreateNewStudent();
            }
            else if (Type == 2)
            {
                CreateNewEmployee();
            }   
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }

        }


        static Student CreateNewStudent()  //สร้าง account นักศึกษา และเก็บข้อมูล
        {
            return new Student(InputName(), InputPassword(), StudentID());
        }

        static Employee CreateNewEmployee() //สร้าง account พนักงาน และเก็บข้อมูล
        {
            return new Employee(InputName(), InputPassword(), EmployeeID());
        }
        static string InputName() //รับค่า ชื่อ
        {
            Console.Write("Input Name : ");
            return Console.ReadLine();
        }
        static string InputPassword() //รัขค่า รหัสผ่าน
        {
            Console.Write("Input Password : ");
            return Console.ReadLine();
        }
        static string StudentID() //รัขค่า ID นักศึกษา
        {
            Console.Write("Student ID : ");
            return Console.ReadLine();
        }
        static string EmployeeID() //รัขค่า ID พนักงาน
        {
            Console.Write("Employee ID : ");
            return Console.ReadLine();
        }



        static void ShowInputLoginNewPersonScreen() //หน้าแรกของ login
        {
            PrintHeaderLogin();
            ShowLoginScreen();
        }
        static void PrintHeaderLogin() //header ของหน้า login
        {
            Console.Clear();
            Console.WriteLine("Register new Person.\n-------------------");
        }
        static void ShowLoginScreen() //แสดงหน้า login
        {
            InputName();
            InputPassword();
            IsNameAndPassWordTrue();
        }

        static void StudemtScreen() //จอแสดงผล สำหรับนักเรียน
        {
            Console.WriteLine("Borrow Book");

        }
        static void BookListScreen() //หน้าแสดงผล รายชื่อหนังสือ
        {
            Book book1 = new Book("Now I Understand", "1");
            Book book2 = new Book("Revoluntary Health", "2");
            Book book3 = new Book("Six Degrees", "3");
            Book book4 = new Book("Les Vacances", "4");

            CombineBook();
        }
        static void CombineBook() //หน้าการยืมหนังสือ
        {
            Console.WriteLine("Input book ID : ");

        }

        static void EmployeeScreen() //จอแสดงผล สำหรับ พนักงาน
        {
            Console.WriteLine("Get List Books");
            BookListScreen();
        }

        static void IsNameAndPassWordTrue() //เช็คชื่อและรหัสว่าถูกต้องหรือไม่
        {
            Program.personList.CheckNameAndPassword();
        }

        static void ShowMessageInputMenuIsInCorrect() //หน้าแสดงผล เมื่อ input ค่าผิด, นอกเหนือจากที่เขียนไว้
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

        public string GetAndSetName
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        public string GetAndSetPassword
        {
            get { return this.Password; }
            set { this.Password = value; }
        }
        
    }

    class Student: Person
    {
        private string StudentID;

        public Student(string name, string password, string studentID): base(name, password)
        {
            this.StudentID = studentID;
        }
    }
    
    class Employee: Person
    {
        private string EmployeeID;

        public Employee(string name, string password, string employeeID) : base(name, password)
        {
            this.EmployeeID = employeeID;
        }
    }

    class PersonList
    {
        private List<Student> studentList;
        private List<Employee> employeeList;

        public PersonList()
        {
            this.studentList = new List<Student>();
            this.employeeList = new List<Employee>();
        }

        public void AddNewPerson(Student student, Employee employee)
        {
            this.studentList.Add(student);
            this.employeeList.Add(employee);
        }

        public void CheckNameAndPassword()
        {
            foreach (Person person in this.studentList)
            {
                if (person is Student)
                {
                    Console.WriteLine("Student Management");
                    Console.WriteLine("-------------------");

                    Console.WriteLine("Name : {0} \nStudent ID : {1}", person.GetAndSetName, person.GetAndSetPassword);
                    Console.WriteLine("-------------------");

                }
            }
            foreach (Person person1 in this.employeeList)
            {
                if (person1 is Employee)
                {
                    Console.WriteLine("Employee Management");
                    Console.WriteLine("-------------------");

                    Console.WriteLine("Name : {0} \nEmployee ID : {1}", person1.GetAndSetName, person1.GetAndSetPassword);
                    Console.WriteLine("-------------------");
                }
            }
        }
    }

    class Book
    {
        private string BookName;
        private string BookID;
        private List<Book> BookList;

        public Book(string bookName, string bookID)
        {
            this.BookName = bookID;
            this.BookID = bookID;
            this.BookList = new List<Book>();   
        }

        public void FetchBookDetail()
        {
            Console.WriteLine("Book ID : {0}",this.BookID);
            Console.WriteLine("Book Name : {0}", this.BookName);
        }
    }

}
