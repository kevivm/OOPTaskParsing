using System.Collections.Generic;
using System.Linq;

namespace OOPTaskParsing
{
    class ImageFile : Files
    {
        public string Resolution { get; }

        public ImageFile(string name, string size, string extension, string[] attributes)
                        : base(name, size, extension, attributes)
        {
            this.Resolution = attributes.First();
        }

        public override Dictionary<string, string> GetFileInfo()
        {
            base.GetFileInfo();
            FileAllInfo.Add("Resolution", this.Resolution);
            return FileAllInfo;
        }

    }
}
