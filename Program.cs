using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RandomText.tw
{
    class RandomTextDictionary {
        public string[] Cities { get; set; }
        public string[] Areas { get; set; }
        public string[] Streets { get; set; }
        public LastName LastName { get; set; }
        public FirstName FirstName { get; set; }
    }

    public class LastName {
        public string[] Single { get; set; }
        public string[] Complex { get; set; }
    }

    public class FirstName {
        public string[] Male { get; set; }
        public string[] Female { get; set; }
    }

    class Program {
        private static List<string> WordPool = new List<string>();

        static void BreakIntoPool(string[] list) {
            foreach (var item in list) {
                var glyphs =

                foreach (var glyph in glyphs) {
                    if(!WordPool.Contains(glyph))
                        WordPool.Add(glyph);
                }
            }
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var anime1 = new RotateStarAnimation();
            anime1.SetRotateSpeed(10);
            anime1.Start();

            try {
                var timeStart = DateTime.Now;
                var dictionaryStr = await File.ReadAllLinesAsync("dictionary.json");
                var dictionary = JsonConvert.DeserializeObject<RandomTextDictionary>(string.Join("", dictionaryStr));

                if (dictionary != null) {
                    Console.WriteLine();
                    Console.WriteLine(dictionary.Streets.Length);
                    Console.WriteLine(dictionary.Areas.Length);
                    Console.WriteLine(dictionary.Cities.Length);
                    Console.WriteLine(dictionary.LastName.Complex.Length);
                    Console.WriteLine(dictionary.LastName.Single.Length);
                    Console.WriteLine(dictionary.FirstName.Male.Length);
                    Console.WriteLine(dictionary.FirstName.Female.Length);

                    BreakIntoPool(dictionary.Cities);
                    foreach(var item in WordPool)
                        Console.Write(item+",");
                    Console.WriteLine();
                    BreakIntoPool(dictionary.Areas);
                    BreakIntoPool(dictionary.Streets);
                    BreakIntoPool(dictionary.LastName.Complex);
                    BreakIntoPool(dictionary.LastName.Single);
                    BreakIntoPool(dictionary.FirstName.Male);
                    BreakIntoPool(dictionary.FirstName.Female);

                    Console.WriteLine(WordPool.Count);
                    var timeEnd = DateTime.Now;
                    var timeDiff = (timeEnd - timeStart).TotalMilliseconds;
                    Console.WriteLine($"Time used: {timeDiff} ms");
                    anime1.Stop();

                    var random = new Random();
                    var surname = dictionary.LastName.Single[random.Next(dictionary.LastName.Single.Length - 1)];
                    var name1 = WordPool[random.Next(WordPool.Count - 1)];
                    var name2 = WordPool[random.Next(WordPool.Count - 1)];
                    Console.WriteLine($"{surname}{name1}{name2}");
                }

            }
            catch(Exception) {
                anime1.Stop();
            }
        }
    }
}
