using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyVers.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void GetSalaryForEmployeeWith5YearsExperience()
        {
            int yearsOfExperience = 5;
            int additionalPercentRatePerYearsExperience = 3;
            int baseRate = 500;
            double expected = baseRate * (1 + (double)(yearsOfExperience * additionalPercentRatePerYearsExperience) / 100);

            Employee employee = new Employee("Name", DateTime.Parse("2012-08-21"), null);
            double actual = employee.GetSalary(DateTime.Now);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetExperienceOfEmployeeCorrect()
        {
            DateTime employmentDate = DateTime.Parse("2012-09-05");
            DateTime observingDate = DateTime.Parse("2017-07-01");
            int expected = (int)((observingDate - employmentDate).TotalDays / 365);

            Employee employee = new Employee("Name", employmentDate, null);
            int actual = employee.GetExperienceInYears(observingDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetExperienceOfEmployeeIncorrect()
        {
            DateTime employmentDate = DateTime.Parse("2012-09-05");
            DateTime observingDate = DateTime.Parse("2010-07-01");
            int expected = (int)((observingDate - employmentDate).TotalDays / 365);

            Employee employee = new Employee("Name", employmentDate, null);
            int actual = employee.GetExperienceInYears(observingDate);

            Assert.AreNotEqual(expected, actual);
        }
    }
}
