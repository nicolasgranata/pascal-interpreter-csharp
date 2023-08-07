namespace pascal_interpreter_csharp
{
    internal class Lexer
    {
        private int _position = 0;
        private char? _currentChar = null;
        private string _currentChars = string.Empty;

        internal Token GetNextToken(string text)
        {
            if (_position <= text.Length - 1)
            {
                _currentChar = text[_position];               
            }

            _currentChars = string.Empty;

            while (_currentChar.HasValue)
            {
                SkipWhiteSpace(text);

                if (_currentChar.HasValue && char.IsDigit(_currentChar.Value))
                {
                    return GetInteger(text);
                }

                if (_currentChar.HasValue)
                {
                    return GetTokenOperation();
                }           
            }

            return new Token(TokenType.EOF, null);
        }

        private Token GetInteger(string text)
        {
            while (_currentChar.HasValue && char.IsDigit(_currentChar.Value))
            {
                _currentChars += _currentChar;

                MoveNext(text);
            }

            return GetToken(TokenType.INTEGER, _currentChars);
        }

        private Token GetTokenOperation()
        {
            _position += 1;

            return _currentChar switch
            {
                '+' => GetToken(TokenType.PLUS, "+"),
                '-' => GetToken(TokenType.MINUS, "-"),
                '*' => GetToken(TokenType.MULTIPLICATION, "*"),
                '/' => GetToken(TokenType.DIVISION, "/"),
                _ => throw new Exception("Error parsing input")
            };
        }

        private void SkipWhiteSpace(string text)
        {
            while (_currentChar.HasValue && char.IsWhiteSpace(_currentChar.Value))
            {
                MoveNext(text);
            }
        }

        private void MoveNext(string text)
        {
            _position++;

            // Return null value if no other exits
            if (_position > text.Length - 1)
            {
                _currentChar = null;
            }
            else
            {
                _currentChar = text[_position];
            }
        }

        private static Token GetToken(TokenType type, string value)
        {
            return new Token(type, new string(value));
        }
    }
}
