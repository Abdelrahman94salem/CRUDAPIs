using Microsoft.Extensions.Options;

namespace DataModel
{
    public static class FileContext 
    {
        public const string fileLocation= @"D:\Me\TransflowProject\Application\DataModel\Sample.txt";
        public static StreamWriter sw = new StreamWriter(fileLocation, true);
        //public FileStream stream;

          
    }
}

