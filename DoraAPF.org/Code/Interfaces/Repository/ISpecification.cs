using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DoraAPF.org.Code.Interfaces.Repository
{
    public interface ISpecification<T>
    {
        List<Expression<Func<T, bool>>> Criterias { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }

        int Take { get; }
        int Skip { get; }
        bool isPagingEnabled { get;}
    }
}
