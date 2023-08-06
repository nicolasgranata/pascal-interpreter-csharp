namespace pascal_interpreter_csharp.tests
{
    public class InterpreterDivisionTests
    {
        [Theory]
        [InlineData("2/2", 1)]
        [InlineData("6/3", 2)]
        [InlineData("4/2", 2)]
        public void Divide_TwoNumbers_SingleDigitInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12/2", 6)]
        [InlineData("14/2", 7)]
        [InlineData("22/11", 2)]
        [InlineData("100/2", 50)]
        [InlineData("200/10", 20)]
        [InlineData("250/250", 1)]
        public void Divide_TwoNumbers_MultipleDigitInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12 /2", 6)]
        [InlineData(" 22/22 ", 1)]
        [InlineData("1 / 1", 1)]
        [InlineData(" 2 / 2", 1)]
        [InlineData("2 / 1 ", 2)]
        [InlineData("  4 / 2 ", 2)]
        [InlineData("  6 / 3  ", 2)]
        [InlineData("  8 /  4  ", 2)]
        public void Divide_TwoNumbers_SkipWhitespaces(string input, int expected)
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
