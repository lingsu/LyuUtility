﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Lyu.Core.Application.PagedList
{
	/// <summary>
	/// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </summary>
	/// <remarks>
	/// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </remarks>
	/// <typeparam name="T">The type of object the collection should contain.</typeparam>
	/// <seealso cref="IPagedList{T}"/>
	/// <seealso cref="BasePagedList{T}"/>
	/// <seealso cref="StaticPagedList{T}"/>
	/// <seealso cref="List{T}"/>
	[Serializable]
	public class PagedList<T> : BasePagedList<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PagedList{T}"/> class that divides the supplied superset into subsets the size of the supplied pageSize. The instance then only containes the objects contained in the subset specified by index.
		/// </summary>
		/// <param name="superset">The collection of objects to be divided into subsets. If the collection implements <see cref="IQueryable{T}"/>, it will be treated as such.</param>
		/// <param name="pageNumber">The one-based index of the subset of objects to be contained by this instance.</param>
		/// <param name="pageSize">The maximum size of any individual subset.</param>
		/// <exception cref="ArgumentOutOfRangeException">The specified index cannot be less than zero.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The specified page size cannot be less than one.</exception>
		public PagedList(IQueryable<T> superset, int pageNumber, int pageSize)
		{

			// set source to blank list if superset is null to prevent exceptions
			TotalItemCount =  superset.Count();
			PageSize = pageSize;
			PageNumber = pageNumber;
			
			// add items to internal list
			if (TotalItemCount > 0)
				AddRange(pageNumber == 1
					? superset.Skip(0).Take(pageSize).ToList()
					: superset.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
				);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class that divides the supplied superset into subsets the size of the supplied pageSize. The instance then only containes the objects contained in the subset specified by index.
        /// </summary>
        /// <param name="superset">The collection of objects to be divided into subsets. If the collection implements <see cref="IQueryable{T}"/>, it will be treated as such.</param>
        /// <param name="pageNumber">The one-based index of the subset of objects to be contained by this instance.</param>
        /// <param name="pageSize">The maximum size of any individual subset.</param>
        /// <exception cref="ArgumentOutOfRangeException">The specified index cannot be less than zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified page size cannot be less than one.</exception>
        public PagedList(IEnumerable<T> superset, int pageNumber, int pageSize)
            : this(superset.AsQueryable<T>(), pageNumber, pageSize)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class that divides the supplied superset into subsets the size of the supplied pageSize. The instance then only containes the objects contained in the subset specified by index.
        /// </summary>
        /// <param name="superset">The collection of objects to be divided into subsets. If the collection implements <see cref="IQueryable{T}"/>, it will be treated as such.</param>
        /// <param name="pageNumber">The one-based index of the subset of objects to be contained by this instance.</param>
        /// <param name="pageSize">The maximum size of any individual subset.</param>
        /// <param name="totalItemCount"></param>
        /// <exception cref="ArgumentOutOfRangeException">The specified index cannot be less than zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified page size cannot be less than one.</exception>
        public PagedList(IEnumerable<T> superset, int pageNumber, int pageSize, int totalItemCount)
		{
            AddRange(superset);
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
	}
}