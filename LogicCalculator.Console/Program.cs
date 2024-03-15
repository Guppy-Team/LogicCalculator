﻿// See https://aka.ms/new-console-template for more information

using LogicCalculator.Core.LogicalExpression;
using LogicCalculator.Core.Shared.ExpressionEvaluators;
using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokenizers;

Console.WriteLine("Hello, World!");

var expression = "sin(1/2) * 3 + 5 ^ num1 * 10";
var tokenizer = new ArithmeticTokenizer();
var tokens = tokenizer.Tokenize(expression);

var rpnConverter = new RpnConverter();
var rpnTokens = rpnConverter.Convert(tokens);

var variables = new Dictionary<string, double>
{
    { "num1", 2 }
};
var rpnEvaluator = new RpnEvaluator();
var rpnResult = rpnEvaluator.Evaluate(rpnTokens, variables);


foreach (var token in rpnTokens)
{
    Console.WriteLine($"Token: {token.Value}, \tType: {token.Type}, \tPriority: {token.Priority}");
}

Console.WriteLine($"\nResult: {rpnResult}\n");


var logicalExpression = "a && !b || (c => d)";
var logicalTokenizer = new LogicalTokenizer();
var logicalExpressionTokens = logicalTokenizer.Tokenize(logicalExpression);
var logicalExpressionRpnTokens = rpnConverter.Convert(logicalExpressionTokens);


foreach (var token in logicalExpressionTokens)
{
    Console.WriteLine($"Token: {token.Value}, \tType: {token.Type}, \tPriority: {token.Priority}");
}

// // Создаем экземпляр класса LogicalTokenizer
// var tokenizer = new LogicalTokenizer();
//
// // Логическое выражение
// string expression = "x1 || (x2 => x3)";
//
// // Разбиваем выражение на токены
// List<IToken> tokens = tokenizer.Tokenize(expression);
//
// // Создаем экземпляр класса TruthTable
// var truthTable = new TruthTable();
//
// // Генерируем таблицу истинности
// List<Dictionary<string, bool>> table = truthTable.Generate(tokens);
//
// // Выводим таблицу истинности
// foreach (var row in table)
// {
//     foreach (var variable in row)
//     {
//         Console.Write($"{variable.Value}\t");
//     }
//
//     // Вычисляем значение выражения для текущего набора значений переменных
//     var result = new LogicalExpression(expression).Evaluate(row);
//     Console.WriteLine($"Result: {result}");
// }