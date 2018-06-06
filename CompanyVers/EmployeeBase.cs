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

        public double AdditionalPercentRatePerYearsExperience { get { return GetAdditionalPercentRatePerYearsExperience(); } }

        public double MaxAdditionalPercentRatePerYearsExperience { get { return GetMaxAdditionalPercentRatePerYearsExperience(); } }

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

        protected abstract double GetAdditionalPercentRatePerYearsExperience();

        protected abstract double GetMaxAdditionalPercentRatePerYearsExperience();

        protected virtual double GetBaseRate() { return 100; }

        public int GetExperienceInYears(DateTime observingDate)
        {
            if (observingDate < employmentDate)
            {
                return 0;
            }

            return Convert.ToInt32(Math.Floor((observingDate - employmentDate).TotalDays / 365));
        }

        public virtual double GetSalary(DateTime observingDate)
        {
            if (this.EmploymentDate > observingDate) return 0;
            return
                GetBaseRate() * (1 + Math.Min(
                    AdditionalPercentRatePerYearsExperience * GetExperienceInYears(observingDate), MaxAdditionalPercentRatePerYearsExperience) / 100);
        }
    }
}
