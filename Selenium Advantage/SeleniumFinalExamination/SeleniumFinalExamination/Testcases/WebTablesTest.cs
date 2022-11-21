using NUnit.Framework;
using NUnit.Framework.Internal;
using SeleniumFinalExamination.PageObject;
using SeleniumFinalExamination.TestSetUp;
using SeleniumFinalExamination.DAO;



namespace SeleniumFinalExamination.Testcases
{
    [TestFixture]
    public class WebTablesTest : NunitWebTestSetUp
    {
        Employee employeeId1 = new Employee("Cierra", "Vega", "39", "cierra@example.com", "10000", "Insurance");
        Employee employeeId2 = new Employee("Alden", "Cantrell", "45", "alden@example.com", "12000", "Compliance");
        Employee employeeId3 = new Employee("Kierra", "Gentry", "29", "kierra@example.com", "2000", "Legal");

        [Test]
        public void VerifyDefaultInfoIsDisplayed()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.GoToElementsPage();
            ElementsPage elementsPage = new ElementsPage(_driver);
            Assert.True(elementsPage.IsElementsPageDisplayed(), "Go to Elements page failed");
            MenuBar menuBar = new MenuBar(_driver);
            menuBar.GoToWebTablesPage();
            WebTablesPage webTablesPage = new WebTablesPage(_driver);
            Assert.True(webTablesPage.IsWebTablesPageDisplayed(), "Go to Web Tables page failed");
            Assert.True(webTablesPage.IsEmployeeInfoCorrect(employeeId1, 3, 6), employeeId1.FirstName + "'s information is wrong");
            Assert.True(webTablesPage.IsEmployeeInfoCorrect(employeeId2, 3, 6), employeeId2.FirstName + "'s information is wrong");
            Assert.True(webTablesPage.IsEmployeeInfoCorrect(employeeId3, 3, 6), employeeId3.FirstName + "'s information is wrong");
        }

        [Test]
        public void CreatNewEmployee()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.GoToElementsPage();
            ElementsPage elementsPage = new ElementsPage(_driver);
            Assert.True(elementsPage.IsElementsPageDisplayed(), "Go to Elements page failed");
            MenuBar menuBar = new MenuBar(_driver);
            menuBar.GoToWebTablesPage();
            WebTablesPage webTablesPage = new WebTablesPage(_driver);
            Assert.True(webTablesPage.IsWebTablesPageDisplayed(), "Go to Web Tables page failed");
            webTablesPage.AddNewEmployee();
            Employee validEmployee = new Employee("Van Anh", "Nguyen", "23", "anhntv99.vn@gmail.com", "3000", "Automation");
            webTablesPage.InputNewEmployeeInfo(validEmployee);
            webTablesPage.Submit();
            Assert.True(webTablesPage.IsEmployeeInfoCorrect(validEmployee, 4, 6), validEmployee.FirstName + "'s information is wrong");

        }

        [Test]
        public void UpdateAndDeleteEmployee()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.GoToElementsPage();
            ElementsPage elementsPage = new ElementsPage(_driver);
            Assert.True(elementsPage.IsElementsPageDisplayed(), "Go to Elements page failed");
            MenuBar menuBar = new MenuBar(_driver);
            menuBar.GoToWebTablesPage();
            WebTablesPage webTablesPage = new WebTablesPage(_driver);
            Assert.True(webTablesPage.IsWebTablesPageDisplayed(), "Go to Web Tables page failed");
            webTablesPage.EditEmployee("Kierra");
            Employee validEmployee = new Employee("Van Anh", "Nguyen", "23", "anhntv99.vn@gmail.com", "3000", "Automation");
            webTablesPage.InputNewEmployeeInfo(validEmployee);
            webTablesPage.Submit();
            Assert.True(webTablesPage.IsEmployeeInfoCorrect(validEmployee, 3, 6), validEmployee.FirstName + "'s information is wrong");
            webTablesPage.DeleteEmployee(validEmployee.FirstName);
            Assert.IsFalse(webTablesPage.IsEmployeeExist(validEmployee));
        }

    }

}
