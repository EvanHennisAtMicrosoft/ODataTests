namespace WebApplication3.Extensions
{
    public interface IPageSizeProvider
    {
        int PageSize { get; }
    }

    public class PageSizeProvider : IPageSizeProvider
    {
        public PageSizeProvider(int pageSize)
        {
            PageSize = pageSize;
        }

        public int PageSize { get; }
    }
}
