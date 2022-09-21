using WebApplicationPage.Filter;

namespace WebApplicationPage.Service.Impl
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
