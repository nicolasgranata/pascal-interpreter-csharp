/*
Token types

EOF (end-of-file) token is used to indicate that there is no more input left for lexical analysis
*/

namespace pascal_interpreter_csharp
{
    enum TokenType
    {
        INTEGER,
        PLUS,
        MINUS,
        MULTIPLICATION,
        DIVISION,
        EOF,
        NONE
    }
}
