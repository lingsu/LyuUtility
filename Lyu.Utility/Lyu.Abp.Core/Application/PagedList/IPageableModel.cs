namespace Lyu.Core.Application.PagedList
{
    /// <summary>
	/// A collection of objects that has been split into pages.
	/// </summary>
    public interface IPageableModel
    {
        /// <summary>
        /// The current page index (starts from 0)
        /// </summary>
        int PageIndex { get; }
        /// <summary>
        /// The current page number (starts from 1)
        /// </summary>
        int Page { get; }
        /// <summary>
        /// The number of items in each page.
        /// </summary>
        int PageSize { get; }
    }

    /// <summary>
    /// Generic form of <see cref="IPageableModel"/>
    /// </summary>
    /// <typeparam name="T">Type of object being paged</typeparam>
    public interface IPagination<T> : IPageableModel
    {

    }
}