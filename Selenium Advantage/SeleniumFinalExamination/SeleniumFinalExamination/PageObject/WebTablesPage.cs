using Framework.DriverCore;
using OpenQA.Selenium;
using SeleniumFinalExamination.DAO;
using SeleniumFinalExamination.TestSetUp;
using NUnit.Framework;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace SeleniumFinalExamination.PageObject
{
    public class WebTablesPage : WebDriverAction
    {
        public WebTablesPage(IWebDriver? driver) : base(driver)
        {
        }
        private String endPointUrl = "/webtables";
        private String btnAddNewEmployee = "//button[@id=\"addNewRecordButton\"]";

        public Boolean IsWebTablesPageDisplayed()
        {

            string url = GetUrl();
            url = Constant.BASE_URL + endPointUrl;
            TestContext.WriteLine("Go to Web Tables page successfully");
            return true;
        }

        public void AddNewEmployee()
        {
            ScrollToElement(btnAddNewEmployee);
            Click(btnAddNewEmployee);
        }

        private String tfFirstName = "//input[@id= 'firstName']";
        private String tfLastname = "//input[@id= 'lastName']";
        private String tfEmail = "//input[@id= 'userEmail']";
        private String tfAge = "//input[@id= 'age']";
        private String tfSalary = "//input[@id= 'salary']";
        private String tfDepartment = "//input[@id= 'department']";

        public void InputNewEmployeeInfo(Employee employee)
        {
            SendKeys_(tfFirstName, employee.FirstName);
            SendKeys_(tfLastname, employee.LastName);
            SendKeys_(tfEmail, employee.Email);
            SendKeys_(tfAge, employee.Age);
            SendKeys_(tfSalary, employee.Salary);
            SendKeys_(tfDepartment, employee.Department);
        }


        private String btnSubmit = "//button[@id= 'submit']";
        public void Submit()
        {
            ScrollToElement(btnSubmit);
            Click(btnSubmit);
        }
        
        public void EditEmployee(string name)
        {
            string editXpath = "//*[text() = '" + name + "']//following-sibling::div//span[@title = 'Edit']";
            Click(editXpath);
        }
        public void DeleteEmployee(string name)
        {
            string editXpath = "//*[text() = '" + name + "']//following-sibling::div//span[@title = 'Delete']";
            Click(editXpath);
        }


        public void GetInfoExistEmployee(Employee employee, int numberofrows, int numberofcolumns)
        {
            for (int i = 1; i <= numberofrows; i++)
            {
                IWebElement row = FindEdlementByXpath("//div[@class='rt-tr-group'][" + i + "]");
                for (int j = 1; j <= numberofcolumns; j++)
                {
                    string cells = row.FindElement(By.XPath("//div[@class='rt-tr-group'][" + i + "]//div[@class = 'rt-td'][" + j + "]")).Text;
                    if (cells == employee.FirstName)
                    {
                        TestContext.WriteLine("First name is correct: " +cells);
                    }
                    else if (cells == employee.LastName)
                    {
                        TestContext.WriteLine("Last name is correct: " + cells);
                    }
                    else if (cells == employee.Age)
                    {
                        TestContext.WriteLine("Age is correct: " + cells);
                    }
                    else if (cells == employee.Email)
                    {
                        TestContext.WriteLine("Email is correct: " + cells);
                    }
                    else if (cells == employee.Salary)
                    {
                        TestContext.WriteLine("Salary is correct: " + cells);
                    }
                    else if(cells == employee.Department)
                    {
                        TestContext.WriteLine("Department is correct: " + cells);
                    }
                    else
                    {
                        break;
                    }
                    
                }

            }

        }

        public Boolean IsEmployeeInfoCorrect(Employee employee, int numberofrows, int numberofcolumns)
        {

            GetInfoExistEmployee(employee, numberofrows, numberofcolumns);
            TestContext.WriteLine(employee.FirstName +"'s information is correct");
            return true;
        }

        public Boolean IsEmployeeExist(Employee employee)
        {
            try
            {
                FindEdlementByXpath("//*[text() = '" + employee.FirstName + "']");
                TestContext.WriteLine(employee.FirstName + "is exist");
                return true;

            }
            catch (Exception ex)
            {
                TestContext.WriteLine(employee.FirstName + "'s information is not exist");
                return false;
            }          
        }
    }
}
