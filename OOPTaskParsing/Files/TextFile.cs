using System.Collections.Generic;
using System.Linq;

namespace OOPTaskParsing
{
    class TextFile : Files
    {
        public string Content { get; }

        public TextFile(string name, string size, string extension, string[] attributes)
                       : base(name, size, extension, attributes)
        {
            this.Content = attributes.First();
        }

        public override Dictionary<string, string> GetFileInfo()
        {
            base.GetFileInfo();
            FileAllInfo.Add("Content", this.Content);

            return FileAllInfo;
        }

    }
}
