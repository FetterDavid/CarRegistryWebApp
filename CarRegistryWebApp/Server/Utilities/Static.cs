namespace Server.Utilities
{
    public static class Static
    {
        public static int GetListPageCount<T>(IQueryable<T> queryable, int recordsPerPage)
        {
            double count = queryable.Count();
            return (int)Math.Ceiling(count / recordsPerPage);
        }
        public static int GetListPageCount<T>(List<T> list, int recordsPerPage)
        {
            double count = list.Count();
            return (int)Math.Ceiling(count / recordsPerPage);
        }
    }
}
