using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
    class Program
    {

        static List<Employee> GetEmployees()
        {
            //Returns a List of strings
            List<Employee> employees = new List<Employee>();

            while (true)
            {

                Console.WriteLine("Enter first name (leave empty to exit): ");

                string firstName = Console.ReadLine() ?? "";

                if (firstName == "")
                {
                    break;
                }
                Console.WriteLine("Enter last name: ");
                string lastName = Console.ReadLine() ?? "";
                Console.WriteLine("Enter ID: ");
                int id = Int32.Parse(Console.ReadLine() ?? "");
                Console.WriteLine("Enter Photo Url: ");
                string photoUrl = Console.ReadLine() ?? "";
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }
            return employees;
        }
        async static Task Main(string[] args)
        {
            List<Employee> employees = GetEmployees();
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);

        }
    }
}
