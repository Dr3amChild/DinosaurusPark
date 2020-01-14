using System.Collections.Generic;
using System.Linq;

namespace DinosaursPark.IntegrationTests.Responses
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
