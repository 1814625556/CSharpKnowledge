using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCollectionTest.PipelineSample
{
    public class Info
    {
        public string Word { get; set; }
        public int Count { get; set; }
        public string Color { get; set; }

        public override string ToString() => $"{Count} times: {Word}";
    }
    public class ColoredConsole
    {
        private static object syncOutput = new object();
        public static void WriteLine(string message)
        {
            lock (syncOutput)
            {
                Console.WriteLine(message);
            }
        }
        public static void WriteLine(string message, string color)
        {
            lock (syncOutput)
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(
                    typeof(ConsoleColor), color);
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }
    public static class PipelineStages
    {
        public static Task ReadFilenamesAsync(string path, BlockingCollection<string> output)
        {
            return Task.Factory.StartNew(() =>
            {
                foreach (string filename in Directory.EnumerateFiles(path, "*.cs",
                    SearchOption.AllDirectories))
                {
                    output.Add(filename);
                    ColoredConsole.WriteLine($"stage 1: added {filename}");
                }
                output.CompleteAdding();//通知所有读取器不用持续等待集合中的人和额外项
            }, TaskCreationOptions.LongRunning);
        }

        public static async Task LoadContentAsync(BlockingCollection<string> input, BlockingCollection<string> output)
        {
            foreach (var filename in input.GetConsumingEnumerable())//从集合中移除并返回项
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    var reader = new StreamReader(stream);
                    string line = null;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        output.Add(line);
                        ColoredConsole.WriteLine($"stage 2: added {line}");
                        await Task.Delay(20);
                    }
                }
            }
            output.CompleteAdding();//通知所有读取器不用持续等待集合中的人和额外项
        }

        public static Task ProcessContentAsync(BlockingCollection<string> input, ConcurrentDictionary<string, int> output)
        {
            return Task.Factory.StartNew(() =>
            {
                foreach (var line in input.GetConsumingEnumerable())
                {
                    string[] words = line.Split(' ', ';', '\t', '{', '}', '(', ')',
                        ':', ',', '"');
                    foreach (var word in words.Where(w => !string.IsNullOrEmpty(w)))
                    {
                        output.AddOrUpdate(key: word, addValue: 1, updateValueFactory: (s, i) => ++i);
                        ColoredConsole.WriteLine($"stage 3: added {word}");
                    }
                }
            }, TaskCreationOptions.LongRunning);
        }

        public static Task TransferContentAsync(ConcurrentDictionary<string, int> input, BlockingCollection<Info> output)
        {
            return Task.Factory.StartNew(() =>
            {
                foreach (var word in input.Keys)
                {
                    int value;
                    if (input.TryGetValue(word, out value))
                    {
                        var info = new Info { Word = word, Count = value };
                        output.Add(info);
                        ColoredConsole.WriteLine($"stage 4: added {info}");
                    }
                }
                output.CompleteAdding();//通知所有读取器不用持续等待集合中的人和额外项
            }, TaskCreationOptions.LongRunning);
        }

        public static Task AddColorAsync(BlockingCollection<Info> input, BlockingCollection<Info> output)
        {
            return Task.Factory.StartNew(() =>
            {
                foreach (var item in input.GetConsumingEnumerable())
                {
                    if (item.Count > 40)
                    {
                        item.Color = "Red";
                    }
                    else if (item.Count > 20)
                    {
                        item.Color = "Yellow";
                    }
                    else
                    {
                        item.Color = "Green";
                    }
                    output.Add(item);
                    ColoredConsole.WriteLine($"stage 5: added color {item.Color} to {item}");
                }
                output.CompleteAdding();//通知所有读取器不用持续等待集合中的人和额外项
            }, TaskCreationOptions.LongRunning);
        }

        public static Task ShowContentAsync(BlockingCollection<Info> input)
        {
            return Task.Factory.StartNew(() =>
            {
                foreach (var item in input.GetConsumingEnumerable())
                {
                    ColoredConsole.WriteLine($"stage 6: {item}", item.Color);
                }
            }, TaskCreationOptions.LongRunning);
        }
    }
}
