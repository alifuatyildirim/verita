using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Verita.Repository.Mssql
{
    public class SpecificationBase<T>
        where T : class
    {
        public List<Expression<Func<T, bool>>> Conditions { get; set; } = new List<Expression<Func<T, bool>>>();

        public Func<IQueryable<T>, IIncludableQueryable<T, object>> Includes { get; set; }

        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; set; }

        public (string ColumnName, string SortDirection) OrderByDynamic { get; set; }
    }
}