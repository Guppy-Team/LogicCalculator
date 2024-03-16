// See https://aka.ms/new-console-template for more information

using LogicCalculator.Core.LogicalExpression;
using LogicCalculator.Core.Shared.Tokenizers;

var tokenizer = new LogicalTokenizer();
var tokens = tokenizer.Tokenize("(x1 || !x2 => x3) || x1");

// Создаем экземпляр класса Dnf
var dnf = new Dnf();

// Вызываем метод Build, передавая список токенов
var dnfExpression = dnf.Build(tokens);

// Выводим результат
Console.WriteLine(dnfExpression); // Выведет: (a && b) || (!a && c)