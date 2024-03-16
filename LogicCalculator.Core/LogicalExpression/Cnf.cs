using System.Text;
using LogicCalculator.Core.Shared.Interfaces;
using LogicCalculator.Core.Shared.Tokens;

namespace LogicCalculator.Core.LogicalExpression;

public class Cnf
{
    public string Build(List<IToken> tokens)
    {
        var truthTable = new TruthTable();
        var rows = truthTable.Generate(tokens);

        var variables = new List<string>();
        foreach (var token in tokens)
        {
            if (token is VariableToken variableToken && !variables.Contains(variableToken.Value))
            {
                variables.Add(variableToken.Value);
            }
        }

        var cnf = new StringBuilder();
        bool isFirstClause = true;
        bool hasValidRows = false;

        foreach (var row in rows)
        {
            var evaluator = new LogicalExpressionEvaluator();

            if (evaluator.Evaluate(tokens, row)) continue;

            hasValidRows = true;

            if (!isFirstClause)
            {
                cnf.Append(" && ");
            }

            cnf.Append("(");
            bool isFirstLiteral = true;

            foreach (var variable in variables)
            {
                if (!isFirstLiteral)
                {
                    cnf.Append(" || ");
                }

                if (row[variable])
                {
                    cnf.Append("!" + variable);
                }
                else
                {
                    cnf.Append(variable);
                }

                isFirstLiteral = false;
            }

            cnf.Append(")");
            isFirstClause = false;
        }

        return hasValidRows ? cnf.ToString() : "true";
    }
}