using Genesis.Models.DTO;
using Genesis.Models.Enums;

namespace Genesis.Services.Extensions
{
    public static class SearchBuilder
    {
        public static SearchParams Create()
        {
            return new SearchParams();
        }
        public static SearchParams OrderBy(this SearchParams searchParams, string fieldName, bool IsDescending = false)
        {
            searchParams.OrderBy = fieldName;
            searchParams.IsDescending = IsDescending;
            return searchParams;
        }
        public static SearchParams AddFilter<T>(this SearchParams searchParams, string fieldName, T Value, ComparisonOperator Comparator)
        {
            searchParams.Filters ??= [];

            searchParams.Filters.Add(new SearchFilters()
            {
                Field = fieldName,
                Value = Value?.ToString() ?? throw new Exception("Invalid filter value"),
                Comparator = Comparator
            });
            return searchParams;
        }
        public static SearchParams FilterJoinAnd(this SearchParams searchParams)
        {
            searchParams.JoinOperator = JoinOperator.JointAnd;
            return searchParams;
        }
        public static SearchParams FilterJoinOr(this SearchParams searchParams)
        {
            searchParams.JoinOperator = JoinOperator.JointOr;
            return searchParams;
        }
        public static SearchParams AddPagination(this SearchParams searchParams, int currPage, int records)
        {
            searchParams.Pagination = new Pagination() { CurrentPage = currPage, RecordsPerPage = records };
            return searchParams;
        }

    }
}
