using System;
using System.Collections;

namespace EmployeeLibrary
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public Human(string name, int age, Gender gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Gender: {Gender}";
        }
    }

    public class Employee : Human, IComparable<Employee>
    {
        private static int idCounter = 1;
        public int ID { get; private set; }
        public double Salary { get; set; }

        public Employee(string name, double salary, int age, Gender gender)
            : base(name, age, gender)
        {
            ID = idCounter++;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"ID: {ID}, {base.ToString()}, Salary: {Salary:C}";
        }

        public void DisplayData()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine("----------------------------");
        }

        // Default Sorting by Name
        public int CompareTo(Employee other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }

    // Sorting by Salary (Descending Order)
    public class SortBySalary : IComparer
    {
        public int Compare(object x, object y)
        {
            Employee e1 = x as Employee;
            Employee e2 = y as Employee;

            if (e1 == null || e2 == null) return 0;

            return e2.Salary.CompareTo(e1.Salary); 
        }
    }

    public static class EmployeeExtensions
    {
        public static void PrintEmployees(this Employee[] employees, int employeeCount)
        {
            Console.Clear();
            if (employeeCount == 0)
            {
                Console.WriteLine("No employee data available.");
                return;
            }

            Console.WriteLine("Employee Details:");
            Console.WriteLine("----------------------------");
            for (int i = 0; i < employeeCount; i++)
            {
                employees[i].DisplayData();
            }
        }
    }
}
