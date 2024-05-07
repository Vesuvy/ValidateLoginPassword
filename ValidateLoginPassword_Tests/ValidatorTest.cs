using ValidatorLibrary;

namespace ValidateLoginPassword_Tests
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        [DataRow("validLogin", true)]
        [DataRow("short", false)]
        [DataRow("loginlogin", true)]
        [DataRow("loginWithNumber1", false)]
        public void TestLoginValidator_DataRowTest(string login, bool expected)
        {
            IValidator validator = new LoginValidator();
            bool result = validator.Validate(login);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("ValidP@ssw0rd", true)]
        [DataRow("short", false)]
        [DataRow("longpassword", false)]
        [DataRow("PasswordNoNumber!", false)]
        [DataRow("Passw0rdNoSpecial", false)]
        [DataRow(null, false)]
        public void TestPasswordValidator_DataRowTest(string password, bool expected)
        {
            IValidator validator = new PasswordValidator();
            bool result = validator.Validate(password);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetDynamicData), DynamicDataSourceType.Method)]
        public void TestLoginValidator_DynamicDataTest(string login, bool expected)
        {
            IValidator validator = new LoginValidator();
            bool result = validator.Validate(login);
            Assert.AreEqual(expected, result);
        }
        public static IEnumerable<object[]> GetDynamicData()
        {
            yield return new object[] { "NormLogin", true };
            yield return new object[] { "short", false };
            yield return new object[] { "", false };
        }
    }
}