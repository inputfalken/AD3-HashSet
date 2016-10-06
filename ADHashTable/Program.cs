using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADHashTable {
    internal static class Program {
        private static void Main(string[] args) {
            var wordExtracter = new WordExtracter("boye.txt",
                new HashSet<string>(StringComparer.InvariantCultureIgnoreCase));
            foreach (var wordExtracterWord in wordExtracter.Collection) {
                Console.WriteLine(wordExtracterWord);
            }
        }
    }
}