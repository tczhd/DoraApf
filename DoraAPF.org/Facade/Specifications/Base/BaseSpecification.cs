using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using DoraAPF.org.Facade.Interfaces.Repository;

namespace DoraAPF.org.Facade.Specifications.Base
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        protected BaseSpecification()
        {
            Criterias = new List<Expression<Func<T, bool>>>();
        }
        public List<Expression<Func<T, bool>>> Criterias { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool isPagingEnabled { get; private set; } = false;
        public void AddPagination(int currentPage, int pageSize)
        {
            currentPage = (currentPage >= 1) ? (currentPage - 1) : 0;
            ApplyPaging(currentPage * pageSize, pageSize);
        }
        protected virtual void AddCriteria(Expression<Func<T, bool>> criteria)
        {
            Criterias.Add(criteria);
        }
        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
        protected virtual void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            isPagingEnabled = true;
        }
        protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }
    }
}
