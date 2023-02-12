using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Would you like to randomly generate users? (please type YES or NO).");
            string userInput = Console.ReadLine() ?? "";
            var yesInput = new string[] { "YES", "Yes", "yes" };
            var noInput = new string[] { "NO", "No", "no" };
            if (yesInput.Contains(userInput))
            {
                List<Employee> employees = await PeopleFetcher.GetFromApi();
                Util.PrintEmployees(employees);
                Util.MakeCSV(employees);
                await Util.MakeBadges(employees);
            }
            else if (noInput.Contains(userInput))
            {
                List<Employee> employees = PeopleFetcher.GetEmployees();
                Util.PrintEmployees(employees);
                Util.MakeCSV(employees);
                await Util.MakeBadges(employees);
            }
            else
            {
                return;
            }
        }
    }
}
