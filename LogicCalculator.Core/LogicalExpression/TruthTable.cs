using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokens;

namespace LogicCalculator.Core.LogicalExpression;

public class TruthTable
{
    public List<Dictionary<string, bool>> Generate(List<IToken> tokens)
    {
        var variables = new List<string>();
        foreach (var token in tokens)
        {
            if (token is VariableToken variableToken && !variables.Contains(variableToken.Value))
            {
                variables.Add(variableToken.Value);
            }
        }

        var rows = (int)Math.Pow(2, variables.Count);
        var table = new List<Dictionary<string, bool>>();

        for (int i = 0; i < rows; i++)
        {
            var row = new Dictionary<string, bool>();
            for (int j = 0; j < variables.Count; j++)
            {
                row[variables[j]] = (i & (1 << j)) != 0;
            }

            table.Add(row);
        }

        return table;
    }
}