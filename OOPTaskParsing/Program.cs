namespace OOPTaskParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"Text:file.txt(6B);Some string content
                           Image:img.bmp(19MB);1920x1080
                           Text:data.txt(12B);Another string
                           Text:data1.txt(7B);Yet another string
                           Movie:logan.2017.mkv(19GB);2540x1032;2h12m";

            Parser parser = new Parser();
            var parsedFiles = parser.ParseInputData(input);
            PrintResults.PrintParsedFiles(parsedFiles);
        }
    }
}
