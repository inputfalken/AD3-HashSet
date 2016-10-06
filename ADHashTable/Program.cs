using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADHashTable {
    internal static class Program {
        private static void Main(string[] args) {
            var boyeSet = new WordExtracter("boye.txt", CreateStringHashSet());
            var commonWordSet = new WordExtracter("ordlista.txt", CreateStringHashSet());

            foreach (var word in boyeSet) {
                if (!commonWordSet.Contains(word)) {
                    Console.WriteLine(word);
                }
            }
        }

        private static HashSet<string> CreateStringHashSet()
            => new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
    }
}