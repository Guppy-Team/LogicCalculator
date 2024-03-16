namespace LogicCalculator.Core.Shared.Interfaces;

public interface ITokenizer
{
    List<IToken> Tokenize(string expression);
}