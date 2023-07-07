using System;
using System.IO;
using System.Text;

namespace d1.Extensions
{
    public static class FileReader
    {



        public static List<string> ReadFile(string pathToFile) {

            //if(!File.Exists(pathToFile)) return null;
            string path = Path.GetFullPath(pathToFile);
            var fi1 = new FileInfo(path);
         
            List<string> foodListWithGaps = new List<string>();

            // Open the file to read from.
            using (StreamReader sr = fi1.OpenText())
            {
                var s = "";
                while ((s = sr.ReadLine()) != null)
                {
                   foodListWithGaps.Add(s);
                }
            }
            return foodListWithGaps;
        }
    }
}
