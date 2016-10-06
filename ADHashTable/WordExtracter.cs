using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ADHashTable {
    internal class WordExtracter {
        public ICollection<string> Collection { get; }
        private string FilePath { get; }


        public WordExtracter(string fileName, ICollection<string> collection) {
            Collection = collection;
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo != null) FilePath = directoryInfo.FullName + $@"\{fileName}";
            PopulateCollection();
        }

        private void PopulateCollection() {
            using (var reader = new StreamReader(FilePath, Encoding.Default)) {
                var line = "";
                while (!reader.EndOfStream) {
                    if (line != "") {
                        if (line != null)
                            foreach (var word in line.Split(' ')) {
                                if (word != string.Empty) {
                                    Collection.Add(ExtractWords(word));
                                }
                            }
                    }
                    line = reader.ReadLine();
                }
            }
        }

        private static string ExtractWords(string word) => new string(word.ToCharArray().Where(char.IsLetter).ToArray());
    }
}