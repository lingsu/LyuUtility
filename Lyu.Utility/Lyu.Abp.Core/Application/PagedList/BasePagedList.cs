using System;
using System.Collections.Generic;

namespace Lyu.Core.Application.PagedList
{
	/// <summary>
	/// 	Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </summary>
	/// <remarks>
	/// 	Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </remarks>
	/// <typeparam name = "T">The type of object the collection should contain.</typeparam>
	/// <seealso cref = "IPagedList{T}" />
	/// <seealso cref = "List{T}" />
	[Serializable]
	public abstract class BasePagedList<T> : List<T>, IPagedList<T>
	{
		/// <summary>
		/// Parameterless constructor.
		/// </summary>
		protected internal BasePagedList()
		{
		}

		/// <summary>
		/// 	Initializes a new instance of a type deriving from <see cref = "BasePagedList{T}" /> and sets properties needed to calculate position and size data on the subset and superset.
		/// </summary>
		/// <param name = "pageNumber">The one-based index of the subset of objects contained by this instance.</param>
		/// <param name = "pageSize">The maximum size of any individual subset.</param>
		/// <param name = "totalItemCount">The size of the superset.</param>
		protected internal BasePagedList(int pageNumber, int pageSize, int totalItemCount)
		{
			// set source to blank list if superset is null to prevent exceptions
			TotalItemCount = totalItemCount;
			PageSize = pageSize;
			PageNumber = pageNumber;
		
		}
        /// <summary>
		/// Total number of objects contained within the superset.
		/// </summary>
		/// <value>
		/// Total number of objects contained within the superset.
		/// </value>
		public int TotalItemCount { get; set; }

        /// <summary>
        /// One-based index of this subset within the superset.
        /// </summary>
        /// <value>
        /// One-based index of this subset within the superset.
        /// </value>
        public int PageNumber { get; set; }

        /// <summary>
        /// Maximum size any individual subset.
        /// </summary>
        /// <value>
        /// Maximum size any individual subset.
        /// </value>
        public int PageSize { get; set; }
    }
}