using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pascal_interpreter_csharp.tests
{
    public class InterpreterArbitraryAddSubtractTests
    {
        [Theory]
        [InlineData("1+2-3", 0)]
        [InlineData("8-2-5", 1)]
        [InlineData("2+2+2-1", 5)]
        public void ArbitrarySumSubtractNumbers_SingleDigitInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("10+2-10", 2)]
        [InlineData("18-3+15", 30)]
        [InlineData("22+10+11-1", 42)]
        public void ArbitrarySumSubtractNumbers_MultipleDigitsInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(" 10+ 2-10 ", 2)]
        [InlineData("18 - 3 + 15 ", 30)]
        [InlineData("22 + 10 + 11 - 1", 42)]
        [InlineData(" 10+ 2- 10 ", 2)]
        [InlineData(" 10 + 2- 10 ", 2)]
        public void ArbitrarySumSubtractNumbers_SkipWhitespaces(string input, int expected)
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
