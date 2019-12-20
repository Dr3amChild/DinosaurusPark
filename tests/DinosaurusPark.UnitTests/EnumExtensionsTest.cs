using DinosaurusPark.Extensions;
using NUnit.Framework;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace DinosaurusPark.UnitTests
{
    public class EnumExtensionsTest
    {
        public enum TestEnum
        {
            [Description("Foo")]
            First,

            [Description("Bar")]
            Second,

            Third
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetDescriptionExtensionMethod_ShouldReturnNull_IfInputValueDoesNotHaveDescription()
        {
            string result = TestEnum.Third.GetDescription();
            Assert.IsNull(result);
        }

        [Test]
        [TestCase(TestEnum.First, "Foo")]
        [TestCase(TestEnum.Second, "Bar")]
        public void GetDescriptionExtensionMethod_ShouldReturnExpectedValue_IfInputValueHasDescription(TestEnum input, string expected)
        {
            string result = input.GetDescription();
            Assert.AreEqual(result, expected);
        }
    }
}