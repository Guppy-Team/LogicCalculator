using LogicCalculator.Core.Shared.Tokens;

namespace LogicCalculator.Core.Shared.Interfaces;

public interface IToken
{
    TokenType Type { get; }
    string Value { get; }
    int Priority { get; }
}