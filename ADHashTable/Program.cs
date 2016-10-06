using System;
using System.Net.WebSockets;
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
}