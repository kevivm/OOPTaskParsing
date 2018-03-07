using System;

namespace OOPTaskParsing
{
    class Exceptions
    {

        static public void PrintNotImplementedException(string message)
        {
            try
            {
                throw new NotImplementedException(message);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static public void PrintNotImplementedExceptionNotSupported(string fileType)
        {
            try
            {
                string maybeFileType = "";

                fileType = fileType.ToLower();

                if (fileType == "text" || fileType == "image" || fileType == "movie")
                {
                    maybeFileType = char.ToUpper(fileType[0]) + fileType.Substring(1);
                    throw new NotImplementedException($"Type {fileType} is not supported. Meybe you meant ~{maybeFileType}:~.");
                }

                throw new NotImplementedException($"Type {fileType} is not supported");
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
