using System;
using System.Collections.Generic;

namespace CompanyVers
{
    public abstract class EmployeeBase
    {
        private string name;
        private DateTime employmentDate;
        private EmployeeWithSubordinates chief;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime EmploymentDate
        {
            get { return employmentDate; }
            set { employmentDate = value; }
        }

        public EmployeeWithSubordinates Chief
        {
            get { return chief; }
            set { chief = value; }
        }

        public EmployeeBase(string name, DateTime employmentDate, EmployeeWithSubordinates chief)
        {
            Name = name;
            EmploymentDate = employmentDate;
            Chief = chief;

            if (chief != null)
            {
                Chief.Subordinates.Add(this);
            }
        }

        public double AdditionalPercentRatePerYearsExperience { get { return GetAdditionalPercentRatePerYearsExperience(); } }

        public double MaxAdditionalPercentRatePerYearsExperience { get { return GetMaxAdditionalPercentRatePerYearsExperience(); } }

        public int ExperienceInYears { get { return GetExperienceInYears(); } }

        public double Salary { get { return GetSalary(); } }

        protected abstract double GetAdditionalPercentRatePerYearsExperience();

        protected abstract double GetMaxAdditionalPercentRatePerYearsExperience();

        protected virtual double GetBaseRate() { return 100; }

        private int GetExperienceInYears()
        {
            Console.WriteLine("difference " + (DateTime.Now - employmentDate).ToString());
            Console.WriteLine("difference in years " + (DateTime.Now - employmentDate).TotalDays.ToString());
            Console.WriteLine(Convert.ToInt32(Math.Floor((DateTime.Now - employmentDate).TotalDays / 365)));
            return Convert.ToInt32(Math.Floor((DateTime.Now - employmentDate).TotalDays / 365));
        }

        protected virtual double GetSalary()
        {
            return
                GetBaseRate() * (1 + Math.Min(
                    AdditionalPercentRatePerYearsExperience * ExperienceInYears / 100, MaxAdditionalPercentRatePerYearsExperience / 100));
        }
    }
}
