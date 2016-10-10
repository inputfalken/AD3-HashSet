using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADHashTable {
    internal static class Program {
        private static WordExtracter CommonWordSet { get; } = new WordExtracter("ordlista.txt", CreateStringHashSet());
        private static WordExtracter Boye { get; } = new WordExtracter("boye.txt", CreateStringHashSet());
        private static IEnumerable<char> Vocals { get; } = new[] {'a', 'e', 'i', 'o', 'u', 'y', 'å', 'ä', 'Ö'};

        private static void Main(string[] args) {
            //AssignmentOne();

            //foreach (var keyValuePair in AssignmentThree()) {
            //    foreach (var word in keyValuePair.Value) {
            //        Console.WriteLine($"Ammount Vocals: {keyValuePair.Key}, Word: {word}");
            //    }
            //}

            foreach (var keyValuePair in AssignmentThreeImproved()) {
                foreach (var word in keyValuePair.Value) {
                    Console.WriteLine($"{word} with the vocals: {keyValuePair.Key.Aggregate((c, c1) => c)}");
                }
            }
        }

        private static void AssignmentOne() {
            foreach (var word in Boye) if (!CommonWordSet.Contains(word)) Console.WriteLine(word);
            Console.WriteLine($"Boyset word count {Boye.Count}, Common words count {CommonWordSet.Count}");
        }


        private static Dictionary<int, ICollection<string>> AssignmentThree() {
            var dictionary = new Dictionary<int, ICollection<string>>();
            foreach (var word in CommonWordSet) {
                var vocals = word.Count(Vocals.Contains);
                if (dictionary.ContainsKey(vocals)) dictionary[vocals].Add(word);
                else dictionary[vocals] = new List<string> {word};
            }
            return dictionary;
        }

        private static HashSet<string> CreateStringHashSet()
            => new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
    }
}