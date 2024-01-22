using System;
using System.Linq;
using System.Linq.Expressions;

namespace Verita.Repository.Mssql
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<T> GetSpecifiedQuery<T>(this IQueryable<T> inputQuery, Specification<T> specification)
            where T : class
        {
            IQueryable<T> query = GetSpecifiedQuery(inputQuery, (SpecificationBase<T>)specification);

            if (specification.Skip != null)
            {
                if (specification.Skip < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(specification.Skip),
                        $"The value of {nameof(specification.Skip)} in {nameof(specification)} can not be negative.");
                }

                query = query.Skip((int)specification.Skip);
            }

            if (specification.Take != null)
            {
                if (specification.Take < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(specification.Take),
                        $"The value of {nameof(specification.Take)} in {nameof(specification)} can not be negative.");
                }

                query = query.Take((int)specification.Take);
            }

            return query;
        }

        public static IQueryable<T> GetSpecifiedQuery<T>(this IQueryable<T> inputQuery,
            PaginationSpecification<T> specification)
            where T : class
        {
            if (inputQuery == null)
            {
                throw new ArgumentNullException(nameof(inputQuery));
            }

            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            if (specification.PageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(specification.PageIndex),
                    "The value of pageIndex must be greater than 0.");
            }

            if (specification.PageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(specification.PageSize),
                    "The value of pageSize must be greater than 0.");
            }

            IQueryable<T> query = GetSpecifiedQuery(inputQuery, (SpecificationBase<T>)specification);

            int skip = (specification.PageIndex - 1) * specification.PageSize;

            query = query.Skip(skip).Take(specification.PageSize);

            return query;
        }

        public static IQueryable<T> GetSpecifiedQuery<T>(this IQueryable<T> inputQuery,
            SpecificationBase<T> specification)
            where T : class
        {
            if (inputQuery == null)
            {
                throw new ArgumentNullException(nameof(inputQuery));
            }

            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            IQueryable<T> query = inputQuery;

            if (specification.Conditions != null && specification.Conditions.Any())
            {
                foreach (Expression<Func<T, bool>> specificationCondition in specification.Conditions)
                {
                    query = query.Where(specificationCondition);
                }
            }

            if (specification.Includes != null)
            {
                query = specification.Includes(query);
            }

            if (specification.OrderBy != null)
            {
                query = specification.OrderBy(query);
            }

            return query;
        }
    }
}