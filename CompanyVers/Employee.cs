using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyVers
{
    public class Employee : EmployeeBase
    {
        public Employee(string name, DateTime employmentDate, EmployeeWithSubordinates chief)
            : base(name, employmentDate, chief) { }
        protected override double GetAdditionalPercentRatePerYearsExperience()
        {
            return 3;
        }

        protected override double GetMaxAdditionalPercentRatePerYearsExperience()
        {
            return 30;
        }

    }
}
