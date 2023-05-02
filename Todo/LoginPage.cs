using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class LoginPage
{
    private readonly IWebDriver _driver;

    private readonly string _url = "https://todo-list-login.firebaseapp.com/";

    private readonly string username = "tzechi26@gmail.com";
    private readonly string password = "Tc363733";

    
    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void Navigate()
    {
        _driver.Navigate().GoToUrl(_url);
    }

    public void LoginWithGitHub()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        var githubLoginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='btn btn-social btn-github']")));
        
        githubLoginButton.Click();

        string originalWindowHandle = _driver.CurrentWindowHandle;

        wait.Until(drv => drv.WindowHandles.Count > 1);
        _driver.SwitchTo().Window(_driver.WindowHandles[1]);

        var usernameField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='login_field']")));
        usernameField.SendKeys(username);

        var passwordField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='password']")));
        passwordField.SendKeys(password);

        var signinButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='Sign in']")));
        signinButton.Click();
        
        _driver.SwitchTo().Window(originalWindowHandle);
    }

    public void Login2ndTime()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        var githubLoginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='btn btn-social btn-github']")));
        
        githubLoginButton.Click();
    }
}