using System.Linq.Expressions;

namespace LinqSpecs.Transitivity;

public class ParameterExpressionVisitor<T1, T2> : ExpressionVisitor
{
    private readonly Expression<Func<T1, T2>> _propertyExpression;
    private readonly string _name;

    public ParameterExpressionVisitor(Expression<Func<T1, T2>> propertyExpression, string name)
    {
        _propertyExpression = propertyExpression;
        _name = name;
    }

    protected override MemberExpression VisitMember(MemberExpression node)
    {
        var isParamExpr = node.Expression?.Type == typeof(T2) 
            && node.Expression is ParameterExpression parExpr 
            && parExpr.Name == _name;

        if (!isParamExpr)
        {
            return node;
        }

        return Expression.Property(_propertyExpression.Body, node.Member.Name);
    }
}