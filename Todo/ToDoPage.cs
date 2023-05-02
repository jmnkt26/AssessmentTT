using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class ToDoPage
{
    private readonly IWebDriver _driver;

    private IWebElement AddButton => _driver.FindElement(By.XPath("//button[@data-testid='add-task']"));
    private IWebElement LogoutButton => _driver.FindElement(By.XPath("//button[@data-testid='logout']"));

    public ToDoPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void CreateToDoItem()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        var InputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@ng-model='home.list']")));
        var AddButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@ng-click='home.list && home.add()']")));

         for (int i = 1; i < 11; i++)
        {
            InputField.SendKeys("Task"+i);
            AddButton.Click();
        }
    }

    public void Logout()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        var LogoutButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@ng-click='home.signOut()']")));
        LogoutButton.Click();
    }

    public void Delete5To10()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        int itemCount = 10;
        for (int i = itemCount - 1; i >= 4; i--)
        {
            var DeleteButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[@ng-click='home.delete($index)'])[" + (i + 1) + "]")));
            DeleteButton.Click();
        }
  
    }



  
}