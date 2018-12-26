using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecialCollectionTest.PipelineSample;

namespace SpecialCollectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //BitArrayTest.Method();
            //BitVectorSample.Method();
            //ObservableCollectionSample.Method();
            //StartPipelineAsync().Wait();
            Console.ReadKey();
        }
        /// <summary>
        /// 控制台输出颜色测试
        /// </summary>
        static void ConsoleColorTest()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Blue·················");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Red ·················");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// 这里是测试管道事件的没有合适的地方写了 ， 就放到了Program.cs里面
        /// </summary>
        /// <returns></returns>
        public static async Task StartPipelineAsync()
        {
            var fileNames = new BlockingCollection<string>();
            var lines = new BlockingCollection<string>();
            var words = new ConcurrentDictionary<string, int>();
            var items = new BlockingCollection<Info>();
            var coloredItems = new BlockingCollection<Info>();
            Task t1 = PipelineStages.ReadFilenamesAsync(@"../..", fileNames);
            ColoredConsole.WriteLine("started stage 1");
            Task t2 = PipelineStages.LoadContentAsync(fileNames, lines);
            ColoredConsole.WriteLine("started stage 2");
            Task t3 = PipelineStages.ProcessContentAsync(lines, words);
            await Task.WhenAll(t1, t2, t3);
            ColoredConsole.WriteLine("stages 1, 2, 3 completed");
            Task t4 = PipelineStages.TransferContentAsync(words, items);
            Task t5 = PipelineStages.AddColorAsync(items, coloredItems);
            Task t6 = PipelineStages.ShowContentAsync(coloredItems);
            ColoredConsole.WriteLine("stages 4, 5, 6 started");

            await Task.WhenAll(t4, t5, t6);
            ColoredConsole.WriteLine("all stages finished");
        }
    }
}
