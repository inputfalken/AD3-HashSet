using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ADHashTable {
    internal class WordExtracter {
        private string FilePath { get; }

        public List<string> Words { get; }

        public WordExtracter(string fileName) {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo != null) FilePath = directoryInfo.FullName + $@"\{fileName}";

            Words = new List<string>();
            using (var reader = new StreamReader(FilePath, Encoding.Default)) {
                var line = "";
                while (!reader.EndOfStream) {
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