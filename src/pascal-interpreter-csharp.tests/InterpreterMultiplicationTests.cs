namespace pascal_interpreter_csharp.tests
{
    public class InterpreterMultiplicationTests
    {
        [Theory]
        [InlineData("1*2", 2)]
        [InlineData("3*6", 18)]
        [InlineData("2*2", 4)]
        public void Multiplying_TwoNumbers_SingleDigitInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12*2", 24)]
        [InlineData("2*14", 28)]
        [InlineData("22*21", 462)]
        [InlineData("100*2", 200)]
        [InlineData("2*100", 200)]
        [InlineData("14*200", 2800)]
        [InlineData("200*14", 2800)]
        [InlineData("250*250", 62500)]
        public void Multiplying_TwoNumbers_MultipleDigitInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12 *2", 24)]
        [InlineData("2* 14", 28)]
        [InlineData(" 22*21 ", 462)]
        [InlineData("1 * 1", 1)]
        [InlineData(" 1 * 2", 2)]
        [InlineData("1 * 2 ", 2)]
        [InlineData("  1 * 2 ", 2)]
        [InlineData("  1 * 2  ", 2)]
        [InlineData("  1 *  2  ", 2)]
        public void Multiplying_TwoNumbers_SkipWhitespaces(string input, int expected)
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
