namespace pascal_interpreter_csharp
{
    internal class Token
    {
        public readonly TokenType _type;
        // token value: 0, 1, 2. 3, 4, 5, 6, 7, 8, 9, '+', '-', '*', '/' or Null
        private readonly string? _value;
        public Token(TokenType type, string? value)
        {
            _type = type;
            _value = value;
        }

        public TokenType Type => _type;
        public string Value => _value;
        public override string ToString()
        {
            return $"Tokey{_type}, {_value}";
        }
    }
}
