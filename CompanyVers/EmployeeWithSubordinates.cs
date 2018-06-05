using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyVers
{
    public abstract class EmployeeWithSubordinates : EmployeeBase
    {
        private List<EmployeeBase> subordinates;

        public List<EmployeeBase> Subordinates { get { return subordinates; } }

        protected double AdditionalPercentRatePerSubordinate
            { get { return GetAdditionalPercentRatePerSubordinate(); } }

        public EmployeeWithSubordinates(string name, DateTime employmentDate, EmployeeWithSubordinates chief)
            : base(name, employmentDate, chief)
        {
            subordinates = new List<EmployeeBase>();
        }

        protected abstract double GetSalaryRelatedSubordinatesSalarySum(DateTime observingDate);

        protected abstract double GetAdditionalPercentRatePerSubordinate();

        protected double GetDirectSubordinatesSalarySum(DateTime observingDate)
        {
            double wholeSalary = 0.0;

            foreach (EmployeeBase empl in subordinates)
            {
                if (empl.EmploymentDate <= observingDate)
                {
                    wholeSalary += empl.GetSalary(observingDate);
                }
            }

            return wholeSalary;
        }

        protected double GetAllLevelSubordinatesSalarySum(DateTime observingDate)
        {
            double wholeSalary = 0.0;

            foreach (EmployeeBase empl in subordinates)
            {
                if (empl.EmploymentDate <= observingDate)
                {
                    wholeSalary += empl.GetSalary(observingDate);

                    if (empl is EmployeeWithSubordinates)
                    {
                        wholeSalary += ((EmployeeWithSubordinates)empl).GetAllLevelSubordinatesSalarySum(observingDate);
                    }
                }
            }

            return wholeSalary;
        }

        public override double GetSalary(DateTime observingDate)
        {
            return base.GetSalary(observingDate) + 
                (AdditionalPercentRatePerSubordinate * GetSalaryRelatedSubordinatesSalarySum(observingDate)) / 100;
        }
    }
}