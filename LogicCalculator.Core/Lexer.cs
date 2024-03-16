
        sb.Append(']');

        return sb.ToString();
    }

    // Pasha
    /// <summary>
    /// Конвертирует лексемы из инфиксного выражения в обратную польскую нотацию
    /// </summary>
    /// <param name="infixTokens">Список лексем из инфиксного выражения.</param>
    /// <returns>Список лексем в порядке польской нотации.</returns>
    public static List<Token> ConvertToRpn(List<Token> infixTokens)
    {
        List<Token> result = new();
        Stack<Token> stack = new();

        foreach (Token token in infixTokens)
        {
            switch (token.Type)
            {
                case TokenType.Number:
                case TokenType.Variable:
                    result.Add(token);
                    break;

                case TokenType.Operator:
                {
                    while (stack.Count > 0 && stack.Peek().Type == TokenType.Operator &&
                           OperatorPrecedences[stack.Peek().Value] >= OperatorPrecedences[token.Value])
                    {
                        result.Add(stack.Pop());
                    }

                    stack.Push(token);
                    break;
                }

                case TokenType.Function:
                case TokenType.LeftBracket:
                    stack.Push(token);
                    break;

                case TokenType.RightBracket:
                {
                    while (stack.Count > 0 && stack.Peek().Type != TokenType.LeftBracket)
                    {
                        result.Add(stack.Pop());
                    }

                    stack.Pop();
                    break;
                }
            }
        }

        foreach (Token remainingToken in stack)
        {
            result.Add(remainingToken);
        }

        return result;
    }

    // Bread
    /// <summary>
    /// Находит значение выражения в постфиксной нотации.
    /// </summary>
    /// <param name="rpnTokens">Список лексем из постфиксного выражения.</param>
    /// <returns>Числовое значение.</returns>
    public static double EvaluateRpn(List<Token> rpnTokens)
    {
        Stack<double> stack = new();

        foreach (var token in rpnTokens)
        {
            switch (token.Type)
            {
                case TokenType.Number:
                    stack.Push(double.Parse(token.Value));
                    break;

                case TokenType.Variable:
                    stack.Push(Variables[token.Value]);
                    break;

                case TokenType.Operator:
                {
                    double operand2 = stack.Pop();
                    double operand1 = stack.Pop();
                    double result = PerformOperation(token.Value, operand1, operand2);
                    stack.Push(result);
                    break;
                }

                case TokenType.Function:
                {
                    double operand = stack.Pop();
                    double result = PerformFunction(token.Value, operand);
                    stack.Push(result);
                    break;
                }
            }
        }

        return stack.Pop();
    }

    /// <summary>
    /// Принимает функцию в виде строки и осуществляет её над операндом.
    /// </summary>
    /// <param name="function">Функция в виде строки.</param>
    /// <param name="operand">Операнд.</param>
    /// <returns>Результат функции в виде числового значения.</returns>
    private static double PerformFunction(string function, double operand)
    {
        return Functions[function](operand);
    }

    /// <summary>
    /// Принимает операцию в виде строки и осуществляет её над операндами.
    /// </summary>
    /// <param name="operation">Операция в виде строки.</param>
    /// <param name="op1">Первый операнд.</param>
    /// <param name="op2">Второй операнд.</param>
    /// <returns>Результат операции в виде числового значения.</returns>
    private static double PerformOperation(string operation, double op1, double op2)
    {
        return operation switch
        {
            "+" => op1 + op2,
            "-" => op1 - op2,
            "*" => op1 * op2,
            "/" => op1 / op2,
            "^" => Math.Pow(op1, op2),
            _ => throw new ArgumentException($"Unknown operator: {operation}")
        };
    }

    /// <summary>
    /// Проверяет, является ли токен функцией.
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public static bool IsFunction(string token)
    {
        return Functions.ContainsKey(token);
    }

    // Dasha
    /// <summary>
    /// Проверяет, является ли токен операндом.
    /// </summary>
    /// <param name="token">Токен.</param>
    /// <returns>Булево значение.</returns>
    public static bool IsVariable(string token)
    {
        return !IsOperator(token);
    }

    // Dasha
    /// <summary>
    /// Проверяет, является ли токен оператором.
    /// </summary>
    /// <param name="token">Токен.</param>
    /// <returns>Булево значение.</returns>
    public static bool IsOperator(string token)
    {
        return OperatorPrecedences.ContainsKey(token);
    }

    // Dasha
    /// <summary>
    /// Производит вычисление заданного в инфиксной форме алгебраического выражения.
    /// </summary>
    /// <param name="expression">Алгебраическое выражение.</param>
    /// <returns>Числовое значение.</returns>
    public static double Evaluate(string expression)
    {
        List<Token> infixTokens = Tokenize(expression);
        List<Token> rpnTokens = ConvertToRpn(infixTokens);

        return EvaluateRpn(rpnTokens);
    }
}