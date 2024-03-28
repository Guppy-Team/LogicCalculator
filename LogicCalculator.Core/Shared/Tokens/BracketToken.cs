﻿using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.Tokens;

public class BracketToken : IToken
{
    public TokenType Type { get; }
    public string Value { get; }
    public BracketToken(string value)
    {
        Value = value;
        Type = value == "(" ? TokenType.LeftBracket : TokenType.RightBracket;
    }
}
