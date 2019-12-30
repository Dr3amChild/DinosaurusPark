using System.Collections.Generic;

namespace DinosaursPark.Contracts.Services
{
    public interface IImageProvider
    {
        IReadOnlyList<string> GetPaths();
    }
}