using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

class ToDoApp
{
    private IWebDriver driver;
    private LoginPage loginPage;
    private ToDoPage toDoPage;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        loginPage = new LoginPage(driver);
        toDoPage = new ToDoPage(driver);
        loginPage.Navigate();
    }

    [Test]
    public void CreateAndDelete()
    {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            var githubLoginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='btn btn-social btn-github']")));
            Assert.IsNotNull(githubLoginButton);

            loginPage.LoginWithGitHub();
            var logoutButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@ng-click='home.signOut()']")));
            Assert.IsNotNull(logoutButton);
            
            toDoPage.CreateToDoItem( );
            for (int i = 1; i < 11; i++)
            {
                var Tasks = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@class, 'ng-binding') and contains(text(), 'Task"+i+" List')]")));
                Assert.IsNotNull(Tasks);
            }

            toDoPage.Logout();
            Assert.IsNotNull(githubLoginButton);

            loginPage.Login2ndTime();
            Assert.IsNotNull(logoutButton);

            toDoPage.Delete5To10();
            IList<IWebElement> todoItems = driver.FindElements(By.XPath("//li[@class='disney1 ng-scope']"));
            Assert.AreEqual(4, todoItems.Count);

            toDoPage.Logout();
            Assert.IsNotNull(githubLoginButton);
    }

     [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}