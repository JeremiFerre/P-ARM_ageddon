using Microsoft.VisualStudio.TestTools.UnitTesting;
using P_ARM_AssemblyParser;
using P_ARM_AssemblyParser.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_ARM_AssemblyParser.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            // Parser le fichier d'exemple
            string exemplePath = "./calculator.s";
            string newFile = SFileParser.ParseFile(exemplePath);
            string goodNewFile = "b098 2000 9014 9010 900c 2001 9008 2002 9004 2003 9000 defe 9820 990c 4288 d104 defe 9818 991c 1840 9028 defe 9820 9908 4288 d104 defe 9818 991c 1a40 9028 defe 9820 9904 4288 d104 defe 9818 991c 4341 9128 defe 9820 9900 4288 d104 defe 9818 991c 4088 9028 defe ded5";

            Assert.AreEqual(goodNewFile, newFile);
        }
    }
}