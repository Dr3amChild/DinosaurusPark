using System.Collections.Generic;
using System.Linq;

namespace DinosaurusPark.WebApplication.Responses
{
    public class CollectionResponse<T>
    {
        public CollectionResponse(IEnumerable<T> items)
        {
            Items = items.ToArray();
        }

        public IReadOnlyCollection<T> Items { get; }
    }
}
