using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ADHashTable {
    internal class WordExtracter : ICollection<string> {
        private ICollection<string> Collection { get; }
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

        public IEnumerator<string> GetEnumerator() => Collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(string item) => Collection.Add(item);

        public void Clear() => Collection.Clear();

        public bool Contains(string item) => Collection.Contains(item);

        public void CopyTo(string[] array, int arrayIndex) => Collection.CopyTo(array, arrayIndex);

        public bool Remove(string item) => Collection.Remove(item);

        public int Count => Collection.Count;

        public bool IsReadOnly => Collection.IsReadOnly;
    }
}