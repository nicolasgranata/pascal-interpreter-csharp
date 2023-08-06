namespace pascal_interpreter_csharp.tests
{
    public class InterpreterSumTests
    {
        [Theory]
        [InlineData("1+2", 3)]
        [InlineData("3+6", 9)]
        [InlineData("2+2", 4)]
        public void Sum_TwoNumbers_SingleDigitInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected,result);
        }

        [Theory]
        [InlineData("12+2", 14)]
        [InlineData("2+14", 16)]
        [InlineData("22+21", 43)]
        [InlineData("100+2", 102)]
        [InlineData("2+100", 102)]
        [InlineData("14+200", 214)]
        [InlineData("200+14", 214)]
        [InlineData("250+250", 500)]
        public void Sum_TwoNumbers_MultipleDigitInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12 +2", 14)]
        [InlineData("2+ 14", 16)]
        [InlineData(" 22+21 ", 43)]
        [InlineData("1 + 1", 2)]
        [InlineData(" 1 + 2", 3)]
        [InlineData("1 + 2 ", 3)]
        [InlineData("  1 + 2 ", 3)]
        [InlineData("  1 + 2  ", 3)]
        [InlineData("  1 +  2  ", 3)]
        public void Sum_TwoNumbers_SkipWhitespaces(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1+2+3", 6)]
        [InlineData("3+6+5", 14)]
        [InlineData("2+2+2", 6)]
        public void Sum_3Numbers_SingleDigitInput(string input, int expected)
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