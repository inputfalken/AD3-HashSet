using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADHashTable {
    class Program {
        static void Main(string[] args) {

        }

        private static string ExtractWords(string word) {
            return new string(word.Trim('-', ',', '.').ToCharArray().Where(char.IsLetter).ToArray());
        }
    }
}