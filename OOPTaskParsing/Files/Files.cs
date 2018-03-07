using System.Collections.Generic;

namespace OOPTaskParsing
{
    public class Files
    {
        private const string TabCharacter = "\t";
        private const string ExtensionSeparator = ".";

        protected readonly string FileName;
        protected readonly string Size;
        protected readonly string Extension;
        protected readonly string[] Attributes;

        protected Dictionary<string, string> FileAllInfo = new Dictionary<string, string>();

        public Files(string fileName, string size, string extension, string[] attributes)
        {
            this.FileName = fileName;
            this.Size = size;
            this.Extension = extension;
            this.Attributes = attributes;
        }

        public virtual Dictionary<string, string> GetFileInfo()
        {
            FileAllInfo.Add("Filename", this.FileName);
            FileAllInfo.Add("Extension", this.Extension);
            FileAllInfo.Add("Size", this.Size);

            return FileAllInfo;
        }
    }
}