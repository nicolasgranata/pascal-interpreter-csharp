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

            var term = GetTerm();
            var result = term;
           
            while (_currentToken.Type == TokenType.PLUS || _currentToken.Type == TokenType.MINUS
                || _currentToken.Type == TokenType.MULTIPLICATION
                || _currentToken.Type == TokenType.DIVISION)
            {
                if (_currentToken.Type == TokenType.PLUS)
                {
                    Eat(TokenType.PLUS);
                    term = GetTerm();
                    result += term;
                }
                if (_currentToken.Type == TokenType.MINUS)
                {
                    Eat(TokenType.MINUS);
                    term = GetTerm();
                    result -= term;
                }

                if (_currentToken.Type == TokenType.MULTIPLICATION)
                {
                    Eat(TokenType.MULTIPLICATION);
                    term = GetTerm();
                    result *= term;
                }

                if (_currentToken.Type == TokenType.DIVISION)
                {
                    Eat(TokenType.DIVISION);
                    term = GetTerm();
                    result /= term;
                }
            }

            return result;
        }

        private int GetTerm()
        {
            var token = _currentToken;
            Eat(TokenType.INTEGER);
            return int.Parse(token.Value);
        }

        private void Eat(TokenType tokenType)
        {
            if (_currentToken?.Type == tokenType)
            {
                _currentToken = _lexer.GetNextToken(_text);
            }
            else
            {
                throw new Exception("Invalid syntax exception");
            }
        }
    }
}
