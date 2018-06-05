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

        public List<EmployeeBase> Subordinates { get { return subordinates; } /*set { subordinates = value; }*/ }

        protected double AdditionalPercentRatePerSubordinate
            { get { return GetAdditionalPercentRatePerSubordinate(); } }

        protected double SalaryRelatedSubordinatesSalarySum
            { get { return GetSalaryRelatedSubordinatesSalarySum(); } }

        protected double DirectSubordinatesSalarySum
            { get { return GetDirectSubordinatesSalarySum(); } }

        protected double AllLevelSubordinatesSalarySum
            { get { return GetAllLevelSubordinatesSalarySum(); } }

        public EmployeeWithSubordinates(string name, DateTime employmentDate, EmployeeWithSubordinates chief)
            : base(name, employmentDate, chief)
        {
            subordinates = new List<EmployeeBase>();
        }

        protected double GetDirectSubordinatesSalarySum()
        {
            double wholeSalary = 0.0;

            foreach (EmployeeBase empl in subordinates)
            {
                wholeSalary += empl.Salary;
            }

            return wholeSalary;
        }

        protected double GetAllLevelSubordinatesSalarySum()
        {
            double wholeSalary = 0.0;

            foreach (EmployeeBase empl in subordinates)
            {
                if (empl is EmployeeWithSubordinates)
                {
                    ((EmployeeWithSubordinates)empl).GetAllLevelSubordinatesSalarySum();
                }
                else
                {
                    wholeSalary += empl.Salary;
                }
            }

            return wholeSalary;
        }

        protected abstract double GetSalaryRelatedSubordinatesSalarySum();

        protected abstract double GetAdditionalPercentRatePerSubordinate();

        protected override double GetSalary()
        {
            return base.GetSalary() + AdditionalPercentRatePerSubordinate * SalaryRelatedSubordinatesSalarySum;
        }
    }
}
