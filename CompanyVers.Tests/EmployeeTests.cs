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

        [TestMethod]
        public void GetSalaryManagerWithSubThreeEmployee()
        {
            Manager managerDep1 = new Manager("ManagerDep1", DateTime.Parse("2016-01-01"), null);
                Sale saleDep1 = new Sale("saleDep1", DateTime.Parse("2010-01-01"), managerDep1);
                Manager managerDep1Sub1 = new Manager("ManagerDep1Sub1", DateTime.Parse("2011-01-01"), managerDep1);
                    Employee empl1Dep1Sub1 = new Employee("empl1Dep1Sub1", DateTime.Parse("2012-01-01"), managerDep1Sub1);
                    Employee empl2Dep1Sub1 = new Employee("empl2Dep1Sub1", DateTime.Parse("2014-01-01"), managerDep1Sub1);
                    Employee empl3Dep1Sub1 = new Employee("empl3Dep1Sub1", DateTime.Parse("2015-01-01"), managerDep1Sub1);

            double expected = 100 + 7 * 5 + 339 * 0.005; //136,695

            DateTime observingDate = DateTime.Now;
            double actual = managerDep1Sub1.GetSalary(observingDate);

            Assert.AreEqual(Math.Round(actual, 3), Math.Round(expected, 3));
        }

        [TestMethod]
        public void GetSalaryForSale()
        {
            Manager managerDep1 = new Manager("managerDep1", DateTime.Parse("2012-01-12"), null);
                Sale saleDep1 = new Sale("saleDep1", DateTime.Parse("2012-09-14"), managerDep1);
                    Manager managerDep1Sub1 = new Manager("managerDep1Sub1", DateTime.Parse("2015-05-01"), saleDep1);
                        Employee empl1Dep1Sub1 = new Employee("empl1Dep1Sub1", DateTime.Parse("2015-09-01"), managerDep1Sub1);
                        Employee empl2Dep1Sub1 = new Employee("empl2Dep1Sub1", DateTime.Parse("2016-05-01"), managerDep1Sub1);
                    Manager managerDep1Sub2 = new Manager("managerDep1Sub2", DateTime.Parse("2008-05-01"), saleDep1);
                        Manager managerDep1Sub1Team1 = new Manager("managerDep1Sub1Team1", DateTime.Parse("2015-05-01"), managerDep1Sub2);
                            Employee empl1Dep1Sub1Team1 = new Employee("empl1Dep1Sub1Team1", DateTime.Parse("2014-08-20"), managerDep1Sub1Team1);
                            Manager managerDep1Sub1Team1SubTeam1 = new Manager("managerDep1Sub1Team1SubTeam1", DateTime.Parse("2015-05-01"), managerDep1Sub1Team1);
                                Manager managerDep1Sub1Team1SubTeam1AreaOne = new Manager("managerDep1Sub1Team1SubTeam1AreaOne", DateTime.Parse("2015-05-01"), managerDep1Sub1Team1SubTeam1);
                                    Employee empl1AreaOne = new Employee("empl1AreaOne", DateTime.Parse("2010-05-25"), managerDep1Sub1Team1SubTeam1AreaOne);
                                    Employee empl2AreaOne = new Employee("empl2AreaOne", DateTime.Parse("2013-01-25"), managerDep1Sub1Team1SubTeam1AreaOne);
                                    Employee empl3AreaOne = new Employee("empl3AreaOne", DateTime.Parse("2015-03-25"), managerDep1Sub1Team1SubTeam1AreaOne);

            //empl1AreaOne = 100 + 8*3 = 124
            //empl2AreaOne = 100 + 5*3 = 115
            //empl3AreaOne = 100 + 3*3 = 109
            //managerDep1Sub1Team1SubTeam1AreaOne 100 + 3*5 + (124+115+109)*0.005 = 116.74
            //managerDep1Sub1Team1SubTeam1 = 100 + 3*5 + 116.74*0.005 = 115.5837
            //empl1Dep1Sub1Team1 = 100 + 3*3 = 109
            //managerDep1Sub1Team1 = 100 + 3*5 + (109+115.5837)*0.005 = 116.1229
            //managerDep1Sub2 = 100 + min(10*5, 40) + 116.1229*0.005 = 140.58
            //empl1Dep1Sub1 = 100 + 2*3 = 106
            //empl2Dep1Sub1 = 100 + 2*3 = 106
            //managerDep1Sub1 = 100 + 3*5 + (106+106)*0.005 = 116.06
            //saleDep1 = 100 + 5 + (116.06+106+106+150.58+116.1229+109+115.5837+116.74+124+115+109)*0.003 = 105 + 1274.0866*0.003 = 108.822
            //managerDep1 = 100 + 6*5 + 108.822*0.005 = 130.544

            double expected = 100 + 5 + (116.06 + 106 + 106 + 140.58 + 116.1229 + 109 + 115.5837 + 116.74 + 124 + 115 + 109) * 0.003; //108.822

            DateTime observingDate = DateTime.Now;
            double actual = saleDep1.GetSalary(observingDate);

            Assert.AreEqual(Math.Round(actual, 3), Math.Round(expected, 3));
        }

        public void GetSalaryManagerWithSubManagerAndEmployee()
        {
            Manager managerDep1Sub1Team1 = new Manager("managerDep1Sub1Team1", DateTime.Parse("2015-05-01"), null);
                Employee empl1Dep1Sub1Team1 = new Employee("empl1Dep1Sub1Team1", DateTime.Parse("2014-08-20"), managerDep1Sub1Team1);
                Manager managerDep1Sub1Team1SubTeam1 = new Manager("managerDep1Sub1Team1SubTeam1", DateTime.Parse("2015-05-01"), managerDep1Sub1Team1);
                    Manager managerDep1Sub1Team1SubTeam1AreaOne = new Manager("managerDep1Sub1Team1SubTeam1AreaOne", DateTime.Parse("2015-05-01"), managerDep1Sub1Team1SubTeam1);
                        Employee empl1AreaOne = new Employee("empl1AreaOne", DateTime.Parse("2010-05-25"), managerDep1Sub1Team1SubTeam1AreaOne);
                        Employee empl2AreaOne = new Employee("empl2AreaOne", DateTime.Parse("2013-01-25"), managerDep1Sub1Team1SubTeam1AreaOne);
                        Employee empl3AreaOne = new Employee("empl3AreaOne", DateTime.Parse("2015-03-25"), managerDep1Sub1Team1SubTeam1AreaOne);

            double expected = 100 + 3 * 5 + (109 + 115.5837) * 0.005; //= 116.1229

            DateTime observingDate = DateTime.Now;
            double actual = managerDep1Sub1Team1.GetSalary(observingDate);

            Assert.AreEqual(Math.Round(actual, 3), Math.Round(expected, 3));
        }

        [TestMethod]
        public void TestMaxAddtionalPercentRatePerExperienceForEmployee()
        {
            Employee empl = new Employee("empl", DateTime.Parse("2005-05-01"), null);

            // observing date = 2030-01-05
            double expected = 100 + 30; // 130 min(29*3, 30)

            DateTime observingDate = DateTime.Parse("2030-01-05");
            double actual = empl.GetSalary(observingDate);

            Assert.AreEqual(Math.Round(actual, 3), Math.Round(expected, 3));
        }

        [TestMethod]
        public void TestMaxAddtionalPercentRatePerExperienceForManager()
        {
            Manager manager = new Manager("manager", DateTime.Parse("2001-03-17"), null);

            double expected = 100 + 40; // 140 min(17*5, 40);

            DateTime observingDate = DateTime.Now;
            double actual = manager.GetSalary(observingDate);

            Assert.AreEqual(Math.Round(actual, 3), Math.Round(expected, 3));
        }

    }
}
