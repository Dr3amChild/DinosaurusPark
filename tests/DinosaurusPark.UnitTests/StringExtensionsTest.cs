using System;
using DinosaurusPark.Extensions;
using NUnit.Framework;

namespace DinosaurusPark.UnitTests
{
    public class StringExtensionsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FrstUpExtensionMethod_ShouldThrow_If_InputStringIsNull()
        {
            static void FirstUpAction()
            {
                ((string)null).FirstUp();
            }

            Assert.Throws<ArgumentNullException>(FirstUpAction);
        }

        [Test]
        public void FrstUpExtensionMethod_ShouldThrow_If_InputStringIsEmpty()
        {
            static void FirstUpAction()
            {
                string.Empty.FirstUp();
            }

            Assert.Throws<ArgumentException>(FirstUpAction);
        }

        [Test]
        [TestCase("name", "Name")]
        [TestCase("Name", "Name")]
        [TestCase(" name", " name")]
        [TestCase("1 name", "1 name")]
        [TestCase("NAME", "Name")]
        public void FrstUpExtensionMethod_Should_If_InputStringIsEmpty(string input, string expected)
        {
            string result = input.FirstUp();
            Assert.AreEqual(result, expected);
        }
    }
}