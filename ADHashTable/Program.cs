using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADHashTable {
    internal static class Program {
        private static void Main(string[] args) {
            var wordExtracter = new WordExtracter("boye.txt");
            foreach (var wordExtracterWord in wordExtracter.Words) {
                Console.WriteLine(wordExtracterWord);
            }
        }
    }

    class WordExtracter {
        private string FilePath { get; }

        public List<string> Words { get; }

        public WordExtracter(string fileName) {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo != null) FilePath = directoryInfo.FullName + $@"\{fileName}";

            Words = new List<string>();
            using (var reader = new StreamReader(FilePath, Encoding.Default)) {
                var line = "";
                while (line != null) {
                    if (line != "") {
                        foreach (var word in line.Split(' ')) {
                            if (word != string.Empty) {
                                Words.Add(new string(word.ToCharArray().Where(char.IsLetter).ToArray()));
                            }
                        }
                    }
                    line = reader.ReadLine();
                }
            }
        }


        private static string ExtractWords(string word) {
            return new string(word.Trim('-', ',', '.').ToCharArray().Where(char.IsLetter).ToArray());
        }
    }
}