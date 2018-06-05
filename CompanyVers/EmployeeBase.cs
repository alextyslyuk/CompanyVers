using System;

namespace CompanyVers
{
    public abstract class EmployeeBase
    {
        private string name;
        private DateTime employmentDate;
        private int chiefId;

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

        public int ChiefId
        {
            get { return chiefId; }
            set { chiefId = value; }

        }

        public EmployeeBase(string name, DateTime employmentDate, EmployeeWithSubordinates chief)
        {
            Name = name;
            EmploymentDate = employmentDate;

            if (chief != null)
            {
                chief.Subordinates = new System.Collections.Generic.List<EmployeeBase>();
                chief.Subordinates.Add(this);
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
            Console.WriteLine(Convert.ToInt32((DateTime.Now - employmentDate).TotalDays / 365));
            return Convert.ToInt32((DateTime.Now - employmentDate).TotalDays / 365);
        }

        protected virtual double GetSalary()
        {
            var salary =
                GetBaseRate() * (1 + Math.Min(
                    AdditionalPercentRatePerYearsExperience * ExperienceInYears / 100, MaxAdditionalPercentRatePerYearsExperience / 100));

            var i = AdditionalPercentRatePerYearsExperience * GetExperienceInYears();

            Console.WriteLine(salary);

            return salary;
        }
    }
}
