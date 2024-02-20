using Model.DTOs;

namespace Server.Utilities
{
    public static class IQuarybleExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, Pagination pagination)
        {
            return queryable.Skip((pagination.Page - 1) * pagination.QuantityPerPage).Take(pagination.QuantityPerPage);
        }
    }
}
