using System.Collections.Generic;

namespace Toolbelt
{
    public class CoverImageDownloadArguments
    {
        public string Path { get; set; }
        public List<string> ProductIds { get; set; }
        public List<string> Eans { get; set; }
    }
}
