namespace pascal_interpreter_csharp.tests
{
    public class InterpreterSubtractTests
    {
        [Theory]
        [InlineData("2-1", 1)]
        [InlineData("6-3", 3)]
        [InlineData("2-2", 0)]
        public void Subtract_TwoNumbers_SingleDigitInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12-2", 10)]
        [InlineData("2-14", -12)]
        [InlineData("22-21", 1)]
        [InlineData("100-2", 98)]
        [InlineData("2-100", -98)]
        [InlineData("14-200", -186)]
        [InlineData("200-14", 186)]
        [InlineData("250-250", 0)]
        public void Subtract_TwoNumbers_MultipleDigitInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12 -2", 10)]
        [InlineData("2- 14", -12)]
        [InlineData(" 22-21 ", 1)]
        [InlineData("1 - 1", 0)]
        [InlineData(" 1 - 2", -1)]
        [InlineData("1 - 2 ", -1)]
        [InlineData("  1 - 2 ", -1)]
        [InlineData("  2 - 1  ", 1)]
        [InlineData("  2 -  1  ", 1)]
        public void Subtract_TwoNumbers_SkipWhitespaces(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
