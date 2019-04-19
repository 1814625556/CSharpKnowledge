using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 驱动类
            //var driverInfo = new DriverInfoTest();
            //driverInfo.ConsoleS();
            #endregion

            #region 调试测试，实体类中只有属性 字段才会显示出来
            //var item = new Item("zhangsan","上海","15721527020");
            //Console.WriteLine(item.Address);
            #endregion
            #region 测试Path类

            //PathTest.GetDocumentsFolder();
            //PathTest.TestExists();
            //PathTest.TestFileExists();
            #endregion
            #region 文件读取测试
            //StreamSample.ReadFileUsingFileStream("../../Item.cs");
            //StreamSample.WriteTextFile();
            StreamSample.CreateSampleFileAsync(3);
            #endregion

            Console.Read();
        }
    }
}
