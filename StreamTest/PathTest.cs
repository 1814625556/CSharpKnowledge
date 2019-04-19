using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest
{
    public class PathTest
    {
        public static string GetDocumentsFolder()
        {
            var tstr1 = Path.Combine("C:", "bb", "dd.txt");
           
            var re_path = "";
#if NET46
            return Enviroment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
#else
            var driver = Environment.GetEnvironmentVariable("HOMEDRIVE");
            var path = Environment.GetEnvironmentVariable("HOMEPATH");
            re_path = Path.Combine(driver, path, "documents");
            return re_path;
#endif
        }
        /// <summary>
        /// 这样子是可以的
        /// </summary>
        public static void TestExists()
        {
            try
            {
                var myFolder = new DirectoryInfo(@"C:\MyDatas\VsProjects\CSharpKnowledge\StreamTes");
                Console.WriteLine(myFolder.Exists);
                myFolder.CreateSubdirectory("ceshiDir2");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        /// <summary>
        /// 查看文件是否存在
        /// </summary>
        public static void TestFileExists()
        {
            try
            {
                File.ReadAllText("");
                var file = new FileInfo(@"C:\MyDatas\VsProjects\CSharpKnowledge\StreamTest\Item.cs");
                Console.WriteLine(file.Exists);
                var readStream = file.OpenRead();

                var result = "";
                var arrs = new byte[1024];
                var sumByte = readStream.Read(arrs, 0, 1024);
                if(sumByte<1024) Array.Clear(arrs,sumByte,0);
                result = Encoding.UTF8.GetString(arrs);
                Console.WriteLine(result);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
