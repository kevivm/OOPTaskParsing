using System.Collections.Generic;
using System.Linq;

namespace OOPTaskParsing
{
    class MovieFile : ImageFile
    {
        public string Duration;

        public MovieFile(string name, string size, string extension, string[] attributes)
                        : base(name, size, extension, attributes)
        {
            this.Duration = attributes.Last();
        }

        public override Dictionary<string, string> GetFileInfo()
        {
            base.GetFileInfo();
            FileAllInfo.Add("Duration", this.Duration);

            return FileAllInfo;
        }

    }
}
