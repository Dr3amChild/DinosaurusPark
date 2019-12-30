using System;
using System.Collections.Generic;
using System.Linq;

namespace DinosaursPark.Contracts.Models
{
    public class PagingResult<TItem>
    {
        public PagingResult(IEnumerable<TItem> items, int pageNumber, int pageSize, int totalCount)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            Items = items.ToList();
            PageNumber = pageNumber;
            PageSize = pageSize;
            PagesCount = totalCount > 0L ? (int)Math.Ceiling(a: (double)totalCount / pageSize) : 0;
            TotalCount = totalCount;
        }

        public IReadOnlyCollection<TItem> Items { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public int PagesCount { get; set; }

        public int TotalCount { get; }
    }
}