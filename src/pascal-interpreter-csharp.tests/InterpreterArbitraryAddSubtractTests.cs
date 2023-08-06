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
        [InlineData("1+2+3", 6)]
        [InlineData("3+6+5", 14)]
        [InlineData("2+2+2", 6)]
        public void SumArbitraryNumbers_SingleDigitInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12-2-3", 7)]
        [InlineData("15-6-5", 4)]
        [InlineData("4-2-2", 0)]
        public void SubtractArbitraryNumbers_SingleDigitInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1+2-3", 0)]
        [InlineData("8-2-5", 1)]
        [InlineData("2+2+2-1", 5)]
        public void ArbitratyAddSubtractNumbers_SingleDigitInput(string input, int expected)
        {
            //Arrange
            var interpreter = new Interpreter(input);

            //Act
            var result = interpreter.Expr();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1+2-3", 0)]
        [InlineData("8-2-5", 1)]
        [InlineData("2+2+2-1", 5)]
        public void ArbitratySumSubtractNumbers_MultipleDigitsInput(string input, int expected)
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
