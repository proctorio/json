using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Proctorio.JSON.Pretty;

namespace Proctorio.JSON.Tests
{
    [TestClass]
    public class JSONPrettyTests
    {
        private static readonly string NewLine = Environment.NewLine;

        private readonly string _complexPrettyPrintArrayInObjectExample = "{\"CreatedDate\": \"\\/Date(1262329200000)\\/\",\"Id\": \"7df51e04-ca58-4804-82f6-e0af2f1d5265\",\"Names\": [\"One\",\"Two\",\"Three\"]}";
        private readonly string _basicPrettyPrintArrayInObjectExample = "[4,5,2,1]";

        [TestMethod]
        public void testComplexPretty()
        {
            string expected = "{" + NewLine +
                "    \"CreatedDate\":  \"\\/Date(1262329200000)\\/\"," + NewLine +
                "    \"Id\":  \"7df51e04-ca58-4804-82f6-e0af2f1d5265\"," + NewLine +
                "    \"Names\":  [" + NewLine +
                "        \"One\"," + NewLine +
                "        \"Two\"," + NewLine +
                "        \"Three\"" + NewLine +
                "    ]" + NewLine +
                "}";
            
            Assert.AreEqual(expected, _complexPrettyPrintArrayInObjectExample.PrettyPrintJson());
        }

        [TestMethod]
        public void testBasicPretty()
        {
            // PrettyPrintJson writes Environment.NewLine, but the fixture's line endings depend on
            // how git checked it out (LF with core.autocrlf false, CRLF with true), so normalize
            // the fixture to this platform's newline before comparing.
            string complexTestString = File.ReadAllText(Path.Combine("TestFiles", "example.json"))
                .Replace("\r\n", "\n").Replace("\n", NewLine);

            Assert.AreEqual(complexTestString, _basicPrettyPrintArrayInObjectExample.PrettyPrintJson());
        }

        
    }
}
