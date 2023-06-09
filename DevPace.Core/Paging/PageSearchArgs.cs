﻿namespace DevPace.Core.Paging
{

    public class PageSearchArgs
    {
        /// <summary>
        /// Page index
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Sorting options
        /// </summary>
        public List<SortingOption> SortingOptions { get; set; }

        /// <summary>
        /// Filtering options
        /// </summary>
        public List<FilteringOption> FilteringOptions { get; set; }
    }

}
