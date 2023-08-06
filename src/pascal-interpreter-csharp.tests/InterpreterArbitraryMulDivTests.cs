namespace pascal_interpreter_csharp.tests
{
    public class InterpreterArbitraryMulDivTests
    {
        [Theory]
        [InlineData("1*2*3", 6)]
        [InlineData("8*2/2", 8)]
        [InlineData("2/2*2/1", 2)]
        public void ArbitratyMulDivNumbers_SingleDigitInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("10*2/10", 2)]
        [InlineData("80*2/20", 8)]
        [InlineData("20/20*20/1", 20)]
        public void ArbitratyMulDivNumbers_MultipleDigitsInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("10 * 2 / 10", 2)]
        [InlineData(" 10 * 2 / 10 ", 2)]
        [InlineData(" 80*2/ 20 ", 8)]
        [InlineData("20 / 20 *  20/ 1", 20)]
        public void ArbitratySumSubtractNumbers_SkipWhitespaces(string input, int expected)
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
