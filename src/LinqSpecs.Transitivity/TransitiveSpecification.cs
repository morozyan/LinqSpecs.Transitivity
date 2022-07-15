using System.Linq.Expressions;

namespace LinqSpecs.Transitivity;

public class TransitiveSpecification<T1, T2> : Specification<T1>
{
    private readonly Specification<T2> _specification;
    private readonly Expression<Func<T1, T2>> _propertyExpression;

    public TransitiveSpecification( Expression<Func<T1, T2>> propertyExpression, Specification<T2> specification)
    {
        _specification = specification;
        _propertyExpression = propertyExpression;
    }

    public override Expression<Func<T1, bool>> ToExpression()
    {
        var specExpression = _specification.ToExpression();
        var specParam = specExpression.Parameters.First();
        var specExpressionBody = specExpression.Body;
        
        var par = new ParameterExpressionVisitor<T1, T2>(_propertyExpression, specParam.Name).Visit(specExpressionBody) ;
        
        return Expression.Lambda<Func<T1, bool>>(par, _propertyExpression.Parameters.First());

    }
}