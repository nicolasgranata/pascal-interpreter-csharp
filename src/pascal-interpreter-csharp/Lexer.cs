namespace pascal_interpreter_csharp
{
    internal class Lexer
    {
        private int _position = 0;

        internal Token GetNextToken(string text)
        {
            if (_position > text.Length - 1)
            {
                return new Token(TokenType.EOF, null);
            }

            char? currentChar = text[_position];

            string currentChars = string.Empty;

            currentChar = SkipWhiteSpace(currentChar, text);

            while (currentChar.HasValue && char.IsDigit(currentChar.Value))
            {
                currentChars += currentChar;

                currentChar = MoveNext(text);

                if (currentChar is null)
                {
                    return GetToken(TokenType.INTEGER, currentChars);
                }

                if (char.IsWhiteSpace(currentChar.Value))
                {
                    currentChar = MoveNext(text);
                }

                if (currentChar == '+' || currentChar == '-')
                {
                    return GetToken(TokenType.INTEGER, currentChars);
                }
            }

            currentChar = SkipWhiteSpace(currentChar, text);

            if (currentChar is null)
            {
                return GetToken(TokenType.INTEGER, currentChars);
            }

            if (currentChar == '+')
            {
                _position += 1;
                return GetToken(TokenType.PLUS, "+");
            }

            if (currentChar == '-')
            {
                _position += 1;
                return GetToken(TokenType.MINUS, "-");
            }

            throw new Exception("Error parsing input");
        }

        private char? SkipWhiteSpace(char? currentChar, string text)
        {
            while (currentChar.HasValue && char.IsWhiteSpace(currentChar.Value))
            {
                currentChar = MoveNext(text);
            }

            return currentChar;
        }

        private char? MoveNext(string text)
        {
            _position++;

            // Return null value if no other exits
            if (_position > text.Length - 1)
            {
                return null;
            }

            return text[_position];
        }

        private static Token GetToken(TokenType type, string value)
        {
            return new Token(type, new string(value));
        }
    }
}
