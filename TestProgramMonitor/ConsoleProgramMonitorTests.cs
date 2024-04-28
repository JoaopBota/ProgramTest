using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace GetProcess.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        private StringWriter stringWriter;

        [SetUp]
        public void Setup()
        {
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [TearDown]
        public void TearDown()
        {
            stringWriter.Dispose();
        }

        [Test]
        public void Test_ArgumentParsing_NotEnoughArguments()
        {
            string[] args = new string[] { };
           
            Console.SetOut(stringWriter);

            // Act
            Program.Main(args);

            // Assert
            // Assert that the error message for not providing enough arguments is printed
            Assert.That(stringWriter.ToString().Contains("Error: Three arguments are required!"));
        }

        [Test]
        public void Test_ArgumentParsing_NonIntegerArguments()
        {
            // Arrange
            string[] args = new string[] { "notepad", "test", "test" };
            
            Console.SetOut(stringWriter);

            // Act
            Program.Main(args);

            // Assert that the error message for not providing enough arguments is printed
            Assert.That(stringWriter.ToString().Contains("Error: Second argument must be an integer!"));
        }

        [Test]
        public void Test_ArgumentParsing_NonIntegerThirdArgument()
        {
            // Arrange
            string[] args = new string[] { "notepad", "1", "test" };
            
            Console.SetOut(stringWriter);

            // Act
            Program.Main(args);

            // Assert that the error message for not providing enough arguments is printed
            Assert.That(stringWriter.ToString().Contains("Error: Third argument must be an integer!"));
        }

        [Test]
        public void Test_ArgumentParsing_NonIntegerSecondArgument()
        {
            // Arrange
            string[] args = new string[] { "notepad", "test", "1" };
            
            Console.SetOut(stringWriter);

            // Act
            Program.Main(args);

            // Assert that the error message for not providing enough arguments is printed
            Assert.That(stringWriter.ToString().Contains("Error: Second argument must be an integer!"));
        }

    }
}