using DinosaurusPark.Contracts.Services;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DinosaurusPark.Services
{
    public class ImageProvider : IImageProvider
    {
        private readonly FilesSettings _settings;
        private readonly IFileProvider _fileProvider;

        public ImageProvider(IFileProvider fileProvider, FilesSettings settings)
        {
            _fileProvider = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
            _settings = settings ?? throw new ArgumentNullException(nameof(_settings));
        }

        public IReadOnlyList<string> GetPaths()
        {
            var content = _fileProvider.GetDirectoryContents(_settings.Root);
            return content.Select(f => Path.Combine(_settings.ShortRoot, f.Name)).ToArray();
        }
    }
}