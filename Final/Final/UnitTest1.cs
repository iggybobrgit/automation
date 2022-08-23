using Allure.Commons;
using Final.AdditionalMethods;
using Final.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;



namespace Final
{
    [AllureNUnit]
    [TestFixture]

    public class Tests : BrowserContext
    {


        [SetUp]
        public void Setup()
        {
            BrowserContext.BrowserSetup(Environments.LocalFireFox);
        }

        [AllureSubSuite("NewUser")]
        [AllureSeverity((SeverityLevel)1)]
        [AllureDescription("Register new user")]
        [AllureOwner("Igor Bobrov")]
        [Test]
        public void CreateUserAndLogin()
        {
            var user = new User();
            var homePage = new HomePage(_driver);
            homePage.CreateNewAccount(user.Email);

            var registerNewMember = new AddAccPage(_driver);
            Assert.IsTrue(registerNewMember.IsLoaded());
            registerNewMember.AddNewMember(user);

            var myAccount = new MyAccPage(_driver);
            Assert.AreEqual($"{user.FirstNamePersonal} {user.LastNamePersonal}", myAccount.userInfo.Text);
            myAccount.logoutButton.Click();

            homePage.LogIn(user.Email.ToString(), user.Password.ToString());
            Assert.AreEqual($"{user.FirstNamePersonal} {user.LastNamePersonal}", myAccount.userInfo.Text);
        }

        [AllureSubSuite("Wishlist")]
        [AllureSeverity((SeverityLevel)1)]
        [AllureDescription("Ability to add in auto created wishlist")]
        [AllureOwner("Igor Bobrov")]
        [Test]
        public void AddToAutoCreatedWishlist()
        {
            var user = new User();

            var homePage = new HomePage(_driver);
            homePage.CreateNewAccount(user.Email);

            var registerNewMember = new AddAccPage(_driver);
            Assert.IsTrue(registerNewMember.IsLoaded());
            registerNewMember.AddNewMember(user);

            var myAccount = new MyAccPage(_driver);
            myAccount.NavigateToWishlistPage();
            var wishlist = new WishlistPage(_driver);
            Assert.False(wishlist.IsLoaded());

            var categoryPage = new CategoryPage(_driver);
            categoryPage.AddRandomProductToWishlist(Categories.Dresses);

            wishlist.NavigateToWishlist();
            Assert.True(wishlist.IsLoaded());

        }

        [AllureSubSuite("Wishlist")]
        [AllureSeverity((SeverityLevel)1)]
        [AllureDescription("Ability to add in existing wishlist")]
        [AllureOwner("Igor Bobrov")]
        [Test]

        public void AddToExistingWishlist()
        {
            var user = new User() { };

            var homePage = new HomePage(_driver);
            homePage.CreateNewAccount(user.Email);

            var registerNewMember = new AddAccPage(_driver);
            Assert.IsTrue(registerNewMember.IsLoaded());
            registerNewMember.AddNewMember(user);

            var myAccount = new MyAccPage(_driver);
            myAccount.NavigateToWishlistPage();

            var wishlist = new WishlistPage(_driver);
            wishlist.AddNewWishlist(Utils.RandomString());

            var categoryPage = new CategoryPage(_driver);
            var productName = categoryPage.AddRandomProductToWishlist(Categories.Women);

            wishlist.NavigateToWishlist();
            wishlist.IsLoaded();
            Assert.IsTrue(wishlist.VerifyProductInWishlist(productName));
        }

        [AllureSubSuite("Cart")]
        [AllureSeverity((SeverityLevel)1)]
        [AllureDescription("Ability to add in cart")]
        [AllureOwner("Igor Bobrov")]
        [Test]

        public void AddToCart()
        {
            var products = new List<string>();
            var user = new User() { };

            var homePage = new HomePage(_driver);
            homePage.CreateNewAccount(user.Email);

            var registerNewMember = new AddAccPage(_driver);
            registerNewMember.IsLoaded();
            registerNewMember.AddNewMember(user);

            var categoryPage = new CategoryPage(_driver);
            products.Add(categoryPage.AddRandomProductToCart(Categories.Women));
            products.Add(categoryPage.AddRandomProductToCart(Categories.Dresses));
            products.Add(categoryPage.AddRandomProductToCart(Categories.Women));

            var cart = new CartPage(_driver);
            homePage.cartButton.Click();
            var actualProducts = cart.GetAllProductNames();
            Assert.AreEqual(3, actualProducts.Count);
            Assert.AreEqual(products, actualProducts);


        }


        [TearDown]
        public void TearDown()
        {

            if (TestContext.CurrentContext.Result.Outcome.Status.ToString() == "Failed")
            {
                AllureLifecycle.Instance.AddAttachment(TestContext.CurrentContext.Test.MethodName + " screenshot" + DateTime.Now + ".png", "image/png", Screenshots.Take(_driver));
            }
            BrowserContext.BrowserExit();
        }
    }
}