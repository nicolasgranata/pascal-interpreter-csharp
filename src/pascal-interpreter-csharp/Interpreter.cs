namespace pascal_interpreter_csharp
{
    public class Interpreter
    {
        private readonly string _text;
        private Token? _currentToken;
        private readonly Lexer _lexer;
        public Interpreter(string text)
        {
            _text = text;
            _currentToken = null;
            _lexer = new Lexer();
        }

        public int Expr()
        {
            _currentToken = _lexer.GetNextToken(_text);
            var left = int.Parse(_currentToken.Value);
            Eat(TokenType.INTEGER);
            var operation = _currentToken.Type;
            
            if (operation == TokenType.PLUS)
            {
                Eat(TokenType.PLUS);
            }

            if (operation == TokenType.MINUS)
            {
                Eat(TokenType.MINUS);
            }

            if (operation == TokenType.MULTIPLICATION)
            {
                Eat(TokenType.MULTIPLICATION);
            }

            if (operation == TokenType.DIVISION)
            {
                Eat(TokenType.DIVISION);
            }

            var right = int.Parse(_currentToken.Value);
            Eat(TokenType.INTEGER);

            if (operation == TokenType.PLUS)
            {
                return left + right;
            }
            if (operation == TokenType.MINUS)
            {
                return left - right;
            }
            if (operation == TokenType.MULTIPLICATION)
            {
                return left * right;
            }
            else
            {
                return left / right;
            }
        }

        private void Eat(TokenType tokenType)
        {
            if (_currentToken?.Type == tokenType)
            {
                _currentToken = _lexer.GetNextToken(_text);
            }
            else
            {
                throw new Exception("Error parsing input");
            }
        }
    }
}
