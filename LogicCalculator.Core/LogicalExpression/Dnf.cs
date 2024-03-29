namespace LogicCalculator.Core.LogicalExpression;

public class Dnf
{
    // public string Build(List<IToken> tokens)
    // {
    //     var truthTable = new TruthTable();
    //     var rows = truthTable.Generate(tokens);
    //
    //     var variables = new List<string>();
        // foreach (var token in tokens)
        // {
            // if (token is VariableToken variableToken && !variables.Contains(variableToken.Value))
            // {
            //     variables.Add(variableToken.Value);
            // }
        // }

        // var dnf = new StringBuilder();
        // bool isFirstTerm = true;
        // bool hasValidRows = false;
        //
        // foreach (var row in rows)
        // {
        //     var evaluator = new LogicalExpressionEvaluator();
        //
        //     if (!evaluator.Evaluate(tokens, row)) continue;
        //
        //     hasValidRows = true;
        //
        //     if (!isFirstTerm)
        //     {
        //         dnf.Append(" || ");
        //     }
        //
        //     dnf.Append('(');
        //     bool isFirstLiteral = true;
        //
        //     foreach (var variable in variables)
        //     {
        //         if (!isFirstLiteral)
        //         {
        //             dnf.Append(" && ");
        //         }
        //
        //         if (row[variable])
        //         {
        //             dnf.Append(variable);
        //         }
        //         else
        //         {
    //                 dnf.Append("!" + variable);
    //             }
    //
    //             isFirstLiteral = false;
    //         }
    //
    //         dnf.Append(')');
    //         isFirstTerm = false;
    //     }
    //
    //     return hasValidRows ? dnf.ToString() : "false";
    // }
}