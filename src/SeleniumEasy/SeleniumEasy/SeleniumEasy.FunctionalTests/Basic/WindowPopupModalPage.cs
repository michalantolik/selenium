using OpenQA.Selenium;
using SeleniumEasy.FunctionalTests.BaseClasses;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class WindowPopupModalPage : Page
    {
        protected override string pageUrl => "https://www.seleniumeasy.com/test/window-popup-modal-demo.html";
        protected override string pageTitle => "Selenium Easy - Window Popup Modal Demo";

        public WindowPopupModalPage(IWebDriver driver) : base(driver) { }


        #region Elements

        private IWebElement followOnTwitterButton => this.driver.FindElement(By.LinkText("Follow On Twitter"));
        private IWebElement likeUsOnFacebookButton => this.driver.FindElement(By.LinkText("Like us On Facebook"));

        #endregion Elements


        #region Interaction

        public void ClickFollowOnTwitterButton()
        {
            this.followOnTwitterButton.Click();
        }

        public void ClickLikeUsOnFacebookButton()
        {
            this.likeUsOnFacebookButton.Click();
        }

        #endregion Interaction
    }
}
