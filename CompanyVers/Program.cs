using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyVers
{
    class Program
    {

        static void Main(string[] args)
        {
            Sale sale = new Sale("Petro", DateTime.Parse("2017-01-12"), null);
            Manager manager1 = new Manager("Kvitoslav", DateTime.Parse("2013-09-01"), sale);
            EmployeeBase empl1 = new Employee("Oleksandr", DateTime.Parse("2018-05-05"), manager1);

            Console.WriteLine("Manager1 additional pecent rate: " + manager1.AdditionalPercentRatePerYearsExperience);

            Console.WriteLine("Manager - experience: " + manager1.GetExperienceInYears(DateTime.Parse("2017-08-15")) + " salary " + manager1.GetSalary(DateTime.Parse("2017-08-15")));
            Console.WriteLine("Empl1 - experience: " + empl1.GetExperienceInYears(DateTime.Now) + " salary " + empl1.GetSalary(DateTime.Now));

            Console.WriteLine("Sale salary: " + sale.GetSalary(DateTime.Now));

            Console.ReadKey();


        }


    }
}
