namespace Lyu.Core.Application.PagedList
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BasePageableModel : IPageableModel
    {
        #region Methods

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int PageIndex
        {
            get
            {
                if (Page > 0)
                    return Page;

                return 1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public int PageSize { get; set; }

        #endregion
    }
}