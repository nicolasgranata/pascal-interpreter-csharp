using pascal_interpreter_csharp;

static void Run()
{
    while (true)
    {
        var input = Console.ReadLine();
        var intepreter = new Interpreter(input);
        var result = intepreter.Expr();
        Console.Write((result));
        Console.Write("\n");
    }
}

Run();



