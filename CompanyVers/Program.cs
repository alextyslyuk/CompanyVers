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
            Manager manager1 = new Manager("Kvitoslav", DateTime.Parse("2013-09-01"), null);
            EmployeeBase empl1 = new Employee("Oleksandr", DateTime.Parse("2015-05-05"), manager1);
            EmployeeBase empl2 = new Employee("Volodymyr", DateTime.Parse("2012-11-05"), manager1);
            EmployeeBase empl3 = new Employee("Roman", DateTime.Parse("2015-01-23"), manager1);
            EmployeeBase empl4 = new Employee("Andriy", DateTime.Parse("2010-09-27"), manager1);
            EmployeeBase empl5 = new Employee("Svyatoslav", DateTime.Parse("2017-07-25"), manager1);
            Sale sale = new Sale("Petro", DateTime.Parse("2017-01-12"), null);

            Console.WriteLine("Manager1 experience: " + manager1.AdditionalPercentRatePerYearsExperience);
            Console.WriteLine("Empl2 " + ":" + empl2.ExperienceInYears + " salary " + empl2.Salary);

            Console.Read();


        }


    }
}
