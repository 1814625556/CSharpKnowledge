using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest
{
    public class FileTest
    {
        public static void DeleteDuplicateFiles(string directory, bool checkOnly)
        {
            IEnumerable<string> fileNames = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
            string previousFileName = string.Empty;
                        
        }
    }
}
