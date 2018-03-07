using System;
using System.IO;
using System.Text.RegularExpressions;

namespace OOPTaskParsing
{
    class Parser
    {
        private string ContentDelimeter = ";";
        private string FileTypeDelimeter = ":";

        public Files[] ParseInputData(string input)
        {
            string[] inputEachNewLines = input.Split(
            new[] { Environment.NewLine },
            StringSplitOptions.None
            );

            Files[] fileObjs = new Files[inputEachNewLines.Length];

            int counterFileObjs = 0;

            foreach (string inputEachNewLine in inputEachNewLines)
            {
                string fileType = String.Empty;
                string extension = String.Empty;

                string inputEachNewLineTrim = inputEachNewLine.Trim();
                string[] fileTypes = inputEachNewLineTrim.Split(':');

                fileType = fileTypes[0];

                if (fileType.Length == 0)
                {
                    Exceptions.PrintNotImplementedException("Lenght filetype = 0");

                    continue;
                }

                if (inputEachNewLineTrim.IndexOf(this.FileTypeDelimeter) > -1)
                {
                    string fileName = String.Empty;
                    string size = String.Empty;

                    var inputEachNewLineTrimToFilename = Regex.Match(inputEachNewLineTrim, @":(.*)(?=\([0-9]+[A-Z]+\);)");

                    if (inputEachNewLineTrimToFilename.Length > 0)
                    {
                        fileName = inputEachNewLineTrimToFilename.ToString();
                        fileName = fileName.Remove(0, 1);
                        extension = Path.GetExtension(fileName).Replace(".", "");
                    }

                    var inputEachNewLineTrimToSize = Regex.Match(inputEachNewLineTrim, @"[0-9]+[A-Z]+(?=\);)");

                    if (inputEachNewLineTrimToSize.Length > 0)
                    {
                        size = inputEachNewLineTrimToSize.ToString();
                    }

                    if (!IsValidFilename(fileName))
                    {
                        Exceptions.PrintNotImplementedException("Incorrect filename!");

                        continue;
                    }

                    if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(size) || string.IsNullOrEmpty(extension))
                    {
                        Exceptions.PrintNotImplementedException("fileName or size or exextension are empty");

                        continue;
                    }

                    string resolution = String.Empty;
                    string duration = String.Empty;
                    string content = String.Empty;

                    switch (fileType)
                    {
                        case "Text":
                            var inputEachNewLineTrimToContent = Regex.Match(inputEachNewLineTrim, @"\([0-9]+[A-Z]+\);(.*)");

                            if (inputEachNewLineTrimToContent.Length > 0 && inputEachNewLineTrimToContent.ToString().IndexOf(";") > -1)
                            {
                                var contentTocontent = Regex.Match(inputEachNewLineTrimToContent.ToString(), @";(.*)");
                                content = contentTocontent.ToString().Remove(0, 1);
                            }
                            else
                            {
                                Exceptions.PrintNotImplementedException("Got parameter \"Content\" was failed");
                            }

                            if (!string.IsNullOrEmpty(fileType) && !string.IsNullOrEmpty(fileName) 
                                && !string.IsNullOrEmpty(size) && !string.IsNullOrEmpty(extension) 
                                && !string.IsNullOrEmpty(content))
                            {
                                string[] attributesText = new string[] { content };
                                fileObjs[counterFileObjs] = new TextFile(fileName, size, extension, attributesText);
                                counterFileObjs++;
                            }

                            break;
                        case "Image":
                            var inputEachNewLineTrimToResolution = Regex.Match(inputEachNewLineTrim.ToString(), @";[0-9]+x[0-9]+");

                            if (inputEachNewLineTrimToResolution.Length > 0)
                            {
                                resolution = inputEachNewLineTrimToResolution.ToString().Replace(this.ContentDelimeter, "");
                            }
                            else
                            {
                                Exceptions.PrintNotImplementedException("Got parameter \"Resolution\" was failed");
                            }
                            if (!string.IsNullOrEmpty(fileType) && !string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(size) && !string.IsNullOrEmpty(extension) && !string.IsNullOrEmpty(resolution))
                            {
                                string[] attributesImage = new string[] { resolution };
                                fileObjs[counterFileObjs] = new ImageFile(fileName, size, extension, attributesImage);
                                counterFileObjs++;
                            }

                            break;
                        case "Movie":
                            inputEachNewLineTrimToResolution = Regex.Match(inputEachNewLineTrim.ToString(), @";[0-9]+x[0-9]+;");

                            if (inputEachNewLineTrimToResolution.Length > 0)
                            {
                                resolution = inputEachNewLineTrimToResolution.ToString().Replace(this.ContentDelimeter, "");
                            }
                            else
                            {
                                Exceptions.PrintNotImplementedException("Got parameter \"Resolution\" was failed");
                            }

                            var inputEachNewLineTrimToduration = Regex.Match(inputEachNewLineTrim.ToString(), @";[0-9]+h[0-9]+m");

                            if (inputEachNewLineTrimToduration.Length > 0)
                            {
                                duration = inputEachNewLineTrimToduration.ToString().Replace(this.ContentDelimeter, "");
                            }
                            else
                            {
                                Exceptions.PrintNotImplementedException("Got parameter \"Duration\" was failed");
                            }

                            if (!string.IsNullOrEmpty(fileType) && !string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(size) && !string.IsNullOrEmpty(extension) && !string.IsNullOrEmpty(resolution) && !string.IsNullOrEmpty(duration))
                            {
                                string[] attributesMovie = new string[] { resolution, duration };
                                fileObjs[counterFileObjs] = new MovieFile(fileName, size, extension, attributesMovie);
                                counterFileObjs++;
                            }

                            break;
                        default:
                            Exceptions.PrintNotImplementedExceptionNotSupported(fileType);

                            break;
                    }
                }
                else
                {
                    Exceptions.PrintNotImplementedException("Format is not correct");
                }
            }

            return fileObjs;
        }

        private bool IsValidFilename(string fileName)
        {
            var invalidChars = string.Join("", Path.GetInvalidFileNameChars());
            var regex = new Regex("[" + Regex.Escape(string.Join("", invalidChars)) + "]");

            return !regex.IsMatch(fileName);
        }
    }
}
