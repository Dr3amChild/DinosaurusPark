using System;
using System.Collections.Generic;
using System.Linq;

namespace DinosaurusPark.Contracts.Models
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
            TotalCount = totalCount;
        }

        public IReadOnlyCollection<TItem> Items { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public int TotalCount { get; }
    }
}