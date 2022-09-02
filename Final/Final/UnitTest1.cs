using System.Configuration;
using Allure.Commons;
using Final.AdditionalMethods;
using Final.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using static Final.AdditionalMethods.BrowserFactory;

namespace Final
{
    [AllureNUnit]
    [TestFixture]

    public class Tests 
    {
        
        [OneTimeSetUp]
        public void Setup()
        {
            BrowserFactory.BrowserSetup(ConfigurationManager.AppSettings["env"]);
        }

        private User _user = new User()
        {
            FirstNamePersonal = Utils.RandomString(),
            LastNamePersonal = Utils.RandomString(),
            Password = Utils.RandomString(),
            DayDOB = "5",
            MonthDOB = DateOfBirthMonth.February,
            YearDOB = "1994",
            FirstNameAddress = Utils.RandomString(),
            LastNameAddress = Utils.RandomString(),
            Address1 = Utils.RandomString(20),
            City = "Minsk",
            State = "Ohio",
            ZipCode = "21522",
            Country = "United States",
            MobilePhone = "55555555",
            AddressAlias = Utils.RandomString(),
        };

        [AllureSubSuite("NewUser")]
        [AllureSeverity((SeverityLevel)1)]
        [AllureDescription("Register new user")]
        [AllureOwner("Igor Bobrov")]
        [Test]
        public void CreateUserAndLogin()
        {
            _user.Email = $"{Utils.RandomString()}@{Utils.RandomString(16)}.com";

            var homePage = new HomePage(_driver);
            homePage.CreateNewAccount(_user.Email);

            var registerNewMember = new AddAccPage(_driver);
            Assert.IsTrue(registerNewMember.IsLoaded());
            registerNewMember.AddNewMember(_user);

            var myAccount = new MyAccPage(_driver);
            Assert.AreEqual($"{_user.FirstNamePersonal} {_user.LastNamePersonal}", myAccount.userInfo.Text);
            myAccount.logoutButton.Click();

            homePage.LogIn(_user.Email.ToString(), _user.Password.ToString());
            Assert.AreEqual($"{_user.FirstNamePersonal} {_user.LastNamePersonal}", myAccount.userInfo.Text);
            homePage.LogOut();
        }

        [AllureSubSuite("Wishlist")]
        [AllureSeverity((SeverityLevel)1)]
        [AllureDescription("Ability to add in auto created wishlist")]
        [AllureOwner("Igor Bobrov")]
        [Test]
        public void AddToAutoCreatedWishlist()
        {
            _user.Email = $"{Utils.RandomString()}@{Utils.RandomString(16)}.com";

            var homePage = new HomePage(_driver);
            homePage.CreateNewAccount(_user.Email);

            var registerNewMember = new AddAccPage(_driver);
            Assert.IsTrue(registerNewMember.IsLoaded());
            registerNewMember.AddNewMember(_user);

            var myAccount = new MyAccPage(_driver);
            myAccount.NavigateToWishlistPage();
            var wishlist = new WishlistPage(_driver);
            Assert.False(wishlist.IsLoaded());

            var categoryPage = new CategoryPage(_driver);
            categoryPage.AddRandomProductToWishlist(Categories.Dresses);

            wishlist.NavigateToWishlist();
            Assert.True(wishlist.IsLoaded());
            homePage.LogOut();

        }

        [AllureSubSuite("Wishlist")]
        [AllureSeverity((SeverityLevel)1)]
        [AllureDescription("Ability to add in existing wishlist")]
        [AllureOwner("Igor Bobrov")]
        [Test]

        public void AddToExistingWishlist()
        {
            _user.Email = $"{Utils.RandomString()}@{Utils.RandomString(16)}.com";

            var homePage = new HomePage(_driver);
            homePage.CreateNewAccount(_user.Email);

            var registerNewMember = new AddAccPage(_driver);
            Assert.IsTrue(registerNewMember.IsLoaded());
            registerNewMember.AddNewMember(_user);

            var myAccount = new MyAccPage(_driver);
            myAccount.NavigateToWishlistPage();

            var wishlist = new WishlistPage(_driver);
            wishlist.AddNewWishlist(Utils.RandomString());

            var categoryPage = new CategoryPage(_driver);
            var productName = categoryPage.AddRandomProductToWishlist(Categories.Women);

            wishlist.NavigateToWishlist();
            wishlist.IsLoaded();
            Assert.IsTrue(wishlist.VerifyProductInWishlist(productName));

            homePage.LogOut();
        }

        [AllureSubSuite("Cart")]
        [AllureSeverity((SeverityLevel)1)]
        [AllureDescription("Ability to add in cart")]
        [AllureOwner("Igor Bobrov")]
        [Test]

        public void AddToCart()
        {
            _user.Email = $"{Utils.RandomString()}@{Utils.RandomString(16)}.com";

            var products = new List<string>();
            
            var homePage = new HomePage(_driver);
            homePage.CreateNewAccount(_user.Email);

            var registerNewMember = new AddAccPage(_driver);
            registerNewMember.IsLoaded();
            registerNewMember.AddNewMember(_user);

            var categoryPage = new CategoryPage(_driver);
            products.Add(categoryPage.AddRandomProductToCart(Categories.Women));
            products.Add(categoryPage.AddRandomProductToCart(Categories.Dresses));
            products.Add(categoryPage.AddRandomProductToCart(Categories.Women));

            var cart = new CartPage(_driver);
            homePage.cartButton.Click();
            var actualProducts = cart.GetAllProductNames();
            Assert.AreEqual(3, actualProducts.Count);
            Assert.AreEqual(products, actualProducts);

            homePage.LogOut();

        }


        [OneTimeTearDown]
        public void TearDown()
        {
            BrowserFactory.BrowserExit();
        }

        [TearDown]
        public void FailedTestAttach()
        {
            BaseTest.ScreenshotFail();

        }
    }
}