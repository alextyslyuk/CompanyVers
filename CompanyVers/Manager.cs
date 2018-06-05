using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyVers
{
    public class Manager : EmployeeWithSubordinates
    {
        public Manager(string name, DateTime employmentDate, EmployeeWithSubordinates chief)
            : base(name, employmentDate, chief) { }
        protected override double GetAdditionalPercentRatePerYearsExperience()
        {
            return 5;
        }

        protected override double GetMaxAdditionalPercentRatePerYearsExperience()
        {
            return 40;
        }

        protected override double GetAdditionalPercentRatePerSubordinate()
        {
            return 0.5;
        }

        protected override double GetSalaryRelatedSubordinatesSalarySum()
        {
            return DirectSubordinatesSalarySum;
        }
    }
}