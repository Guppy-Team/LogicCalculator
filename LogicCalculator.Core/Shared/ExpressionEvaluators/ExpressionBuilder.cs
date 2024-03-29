using LogicCalculator.Core.Shared.Interfaces;

namespace LogicCalculator.Core.Shared.ExpressionEvaluators;

public class ExpressionBuilder
{
    // Builder Pattern
    public ExpressionBuilder Binary(IToken token,int priority, Func<double,double,double> func)
    {  
        return this;
    }

    public ExpressionBuilder Unary(IToken token, Func<double, double> func)
    {
        return this;
    }

    public ExpressionBuilder FunctionN(string name, int rarity, Func<double[], double> func)
    {
        return this;
    }

    
    
    static IExpression Build(string[] args)
    {
        //binaries
        //unary
        //func

        throw new NotImplementedException();
    }
}