using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADHashTable {
    internal static class Program {
        private static void Main(string[] args) {
            var boyeSet = new WordExtracter("boye.txt",
                new HashSet<string>(StringComparer.InvariantCultureIgnoreCase));
            var commonWordSet = new WordExtracter("ordlista.txt",
                new HashSet<string>(StringComparer.InvariantCultureIgnoreCase));

            foreach (var word in boyeSet.Collection) {
                if (!commonWordSet.Collection.Contains(word)) {
                    Console.WriteLine(word);
                }
            }
        }
    }
}