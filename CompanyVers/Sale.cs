using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyVers
{
    public class Sale : EmployeeWithSubordinates
    {
        public Sale(string name, DateTime employmentDate, EmployeeWithSubordinates chief)
            : base(name, employmentDate, chief) { }

        protected override double GetAdditionalPercentRatePerYearsExperience()
        {
            return 0.3;
        }

        protected override double GetMaxAdditionalPercentRatePerYearsExperience()
        {
            return 30;
        }

        protected override double GetAdditionalPercentRatePerSubordinate()
        {
            return 1;
        }
        protected override double GetSalaryRelatedSubordinatesSalarySum(DateTime observingDate)
        {
            return GetAllLevelSubordinatesSalarySum(observingDate);
        }
    }
}
