using System.Collections.Generic;

namespace DinosaurusPark.Contracts.Services
{
    public interface IImageProvider
    {
        IReadOnlyList<string> GetPaths();
    }
}