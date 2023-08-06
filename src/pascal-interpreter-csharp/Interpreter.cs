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
            else
            {
                Eat(TokenType.MINUS);
            }
            
            var right = int.Parse(_currentToken.Value);
            Eat(TokenType.INTEGER);

            if (operation == TokenType.PLUS)
            {
                return left + right;
            }
            else
            {
                return left - right;
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
