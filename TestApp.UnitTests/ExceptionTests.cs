using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;
    private object _expected;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        var testString = "Hello, World!";
        var expected = "!dlroW ,olleH";

        // Act
        var result = _exceptions.ArgumentNullReverse(testString);

        // Assert
        Assert.AreEqual(expected, result);
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    { // Arrange
        string testString = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _exceptions.ArgumentNullReverse(testString));
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {

        // Arrange
        decimal totalPrice = 200;
        decimal discount = 20;
        decimal expected = 160;

        // Act
        decimal actual = _exceptions.ArgumentCalculateDiscount(totalPrice, discount);

        // Assert
        Assert.AreEqual(expected, actual, "Discounted price is not correct.");
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 200;
        decimal discount = -20;

        // Act and Assert
        Assert.Throws<ArgumentException>(() => _exceptions.ArgumentCalculateDiscount(totalPrice, discount), "Expected an ArgumentException to be thrown when discount is negative.");
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _exceptions.ArgumentCalculateDiscount(totalPrice, discount), "Expected an ArgumentException to be thrown when discount is over 100.");
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // Arrange
        int[] array = new int[] { 1, 2, 3, 4, 5 };
        int index = 2;
        int expected = array[index];

        // Act
        int actual = _exceptions.IndexOutOfRangeGetElement(array, index);

        // Assert
        Assert.AreEqual(expected, actual, "The returned element is not the expected one.");
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {// Arrange
        int[] array = new int[] { 1, 2, 3, 4, 5 };
        int index = -1;

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(array, index));
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length + 1;

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(array, index));
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arrange
        var isLoggedIn = true;

        // Act
        var result = _exceptions.InvalidOperationPerformSecureOperation(isLoggedIn);

        // Assert
        Assert.AreEqual("User logged in.", result);
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arrange
        var isLoggedIn = false;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _exceptions.InvalidOperationPerformSecureOperation(isLoggedIn));
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // Arrange
        string validInput = "123";
        int expected = 123;

        // Act
        int actual = _exceptions.FormatExceptionParseInt(validInput);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        // Arrange
        string invalidInput = "abc";

        // Act and Assert
        Assert.Throws<FormatException>(() => _exceptions.FormatExceptionParseInt(invalidInput));
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        var dictionary = new Dictionary<string, int> { { "testKey", 123 } };
        string key = "testKey";
        int expectedValue = 123;

        // Act
        var actualValue = _exceptions.KeyNotFoundFindValueByKey(dictionary,key);

        // Assert
        Assert.AreEqual(expectedValue, actualValue);
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        var dictionary = new Dictionary<string, int> { { "testKey", 123 } };
        var key = "nonExistentKey";

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => _exceptions.KeyNotFoundFindValueByKey(dictionary, key));
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // Arrange
        int a = 10;
        int b = 20;
        int expected = 30;

        // Act
        int result = _exceptions.OverflowAddNumbers(a, b);

        // Assert
        Assert.AreEqual(expected, result, "The sum of the two numbers does not match the expected value.");
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MaxValue;
        int b = 1;

        // Act and Assert
        Assert.Throws<OverflowException>(() => _exceptions.OverflowAddNumbers(a, b), "Expected an OverflowException to be thrown when adding numbers that result in an overflow.");
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MinValue;
        int b = -1;

        // Act and Assert
        Assert.Throws<OverflowException>(() => _exceptions.OverflowAddNumbers(a, b), "Expected an OverflowException to be thrown when subtracting a number from the minimum integer value.");
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int dividend = 10;
        int divisor = 2;
        int expected = 5;

        // Act
        int result = _exceptions.DivideByZeroDivideNumbers(dividend, divisor);

        // Assert
        Assert.AreEqual(expected, result, "DivideNumbers method does not return correct quotient.");
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int dividend = 10;
        int divisor = 0;

        // Act and Assert
        Assert.Throws<DivideByZeroException>(() => _exceptions.DivideByZeroDivideNumbers(dividend, divisor), "DivideNumbers method does not throw DivideByZeroException when dividing by zero.");
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] collection = new int[] { 1, 2, 3, 4, 5 };
        int index = 2; // valid index
        int expectedSum = 15; // sum of all elements in the collection

        // Act
        int actualSum = _exceptions.SumCollectionElements(collection, index);

        // Assert
        Assert.AreEqual(expectedSum, actualSum, "Sum of collection elements does not match expected value.");
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {

        // Arrange
        int[]? collection = null;
        int index = 0;

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => _exceptions.SumCollectionElements(collection, index));
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] collection = new int[] { 1, 2, 3 };
        int index = 4; // Index out of range

        // Act and Assert
        Assert.Throws<IndexOutOfRangeException>(() => _exceptions.SumCollectionElements(collection, index));
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        var dictionary = new Dictionary<string, string> { { "testKey", "123" } };
        var key = "testKey";
        var expected = 123;

        // Act
        var result = _exceptions.GetElementAsNumber(dictionary, key);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        var dictionary = new Dictionary<string, string> { { "testKey", "123" } };
        var key = "nonExistentKey";

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => _exceptions.GetElementAsNumber(dictionary, key));
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        // Arrange
        var dictionary = new Dictionary<string, string> { { "testKey", "notAnInteger" } };
        var key = "testKey";

        // Act & Assert
        Assert.Throws<FormatException>(() => _exceptions.GetElementAsNumber(dictionary, key));
    }
}
