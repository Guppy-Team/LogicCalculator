// See https://aka.ms/new-console-template for more information

using LogicCalculator.Core.Shared.Tokenizers;

Console.WriteLine("Hello, World!");

var expression = "2 + x * (3 - sin(y)) / num1 ^ 2";
var tokenizer = new ArithmeticTokenizer();
var tokens = tokenizer.Tokenize(expression);

foreach (var token in tokens)
{
    Console.WriteLine($"Token: {token.Value}, Type: {token.Type}, Priority: {token.Priority}");
}