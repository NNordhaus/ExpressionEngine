using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ExpressionEvaluator;

namespace ExpressionEvaluatorTests
{
    [TestClass]
    public class Evaluate_Should
    {
        [TestMethod]
        public void Return_False_When_No_Input_Given()
        {
            // Arrange
            var sut = new BooleanEvaluator();

            // Act
            var result = sut.Evaluate("");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Treat_Whitespace_as_empty()
        {
            // Arrange
            var sut = new BooleanEvaluator();

            // Act
            var result = sut.Evaluate(" ");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Return_True_When_Matching_Tag_Exists()
        {
            // Arrange
            var sut = new BooleanEvaluator();
            sut.Tags.Add("Horse");

            // Act
            var result = sut.Evaluate("Horse");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Return_False_When_Matching_Tag_Does_Not_Exist()
        {
            // Arrange
            var sut = new BooleanEvaluator();
            sut.Tags.Add("Cow");

            // Act
            var result = sut.Evaluate("Horse");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Return_False_When_Left_Side_of_AND_operator_Does_Not_Exist()
        {
            // Arrange
            var sut = new BooleanEvaluator();
            sut.Tags.Add("Cow");

            // Act
            var result = sut.Evaluate("Horse && Cow");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Return_False_When_Right_Side_of_AND_operator_Does_Not_Exist()
        {
            // Arrange
            var sut = new BooleanEvaluator();
            sut.Tags.Add("Horse");

            // Act
            var result = sut.Evaluate("Horse && Cow");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Return_True_When_Both_Sides_of_AND_operator_Exist()
        {
            // Arrange
            var sut = new BooleanEvaluator();
            sut.Tags.Add("Cow");
            sut.Tags.Add("Horse");

            // Act
            var result = sut.Evaluate("Horse && Cow");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Return_False_When_Neither_Side_of_OR_operator_Exist()
        {
            // Arrange
            var sut = new BooleanEvaluator();

            // Act
            var result = sut.Evaluate("Horse || Cow");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Return_True_When_Left_Side_of_OR_operator_Exists()
        {
            // Arrange
            var sut = new BooleanEvaluator();
            sut.Tags.Add("Horse");

            // Act
            var result = sut.Evaluate("Horse || Cow");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Return_True_When_TWO_AND_operators_exist_in_series()
        {
            // Arrange
            var sut = new BooleanEvaluator();
            sut.Tags.Add("Horse");
            sut.Tags.Add("Cow");
            sut.Tags.Add("Goat");

            // Act
            var result = sut.Evaluate("Horse && Cow && Goat");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Return_False_When_third_val_in_series_of_AND_is_only_false()
        {
            // Arrange
            var sut = new BooleanEvaluator();
            sut.Tags.Add("Horse");
            sut.Tags.Add("Cow");

            // Act
            var result = sut.Evaluate("Horse && Cow && Goat");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Return_True_When_Third_val_in_series_of_OR_is_the_only_true()
        {
            // Arrange
            var sut = new BooleanEvaluator();
            sut.Tags.Add("Goat");

            // Act
            var result = sut.Evaluate("Horse || Cow || Goat");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Return_true_when_5_tags_used()
        {
            // Arrange
            var sut = new BooleanEvaluator();
            //sut.Tags.Add("For-Sale");
            sut.Tags.Add("Florida");
            sut.Tags.Add("Motorcycle");

            // Act
            var result = sut.Evaluate("For-Sale && Florida && Car || Motorcycle || Truck");

            // Assert
            Assert.AreEqual(result, false);
        }
    }
}