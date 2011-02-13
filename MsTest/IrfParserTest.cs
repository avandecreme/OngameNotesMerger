using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerCederberg.Grammatica.Runtime;
using System.IO;
using IrfParserNs;

namespace MsTest
{
    /// <summary>
    /// Summary description for IrfParserTest
    /// </summary>
    [TestClass]
    public class IrfParserTest
    {
        [DeploymentItem("PlayerNotesP5.irf")]
        [TestMethod]
        public void TestIrfObjectReadAndWrite()
        {
            IrfObject irfObjectOriginal;
            IrfObject irfObjectRewrite;

            using (StreamReader irfFile = new StreamReader("PlayerNotesP5.irf"))
            {
                IrfFileReader reader = new IrfFileReader();
                Parser parser = new IrfParserNs.IrfParser(irfFile, reader);
                parser.Parse();
                irfObjectOriginal = reader.IrfObject;
            }
            irfObjectOriginal.WriteToFile("MSTestPlayerNote.irf");

            using (StreamReader irfFile = new StreamReader("MSTestPlayerNote.irf"))
            {
                IrfFileReader reader = new IrfFileReader();
                Parser parser = new IrfParserNs.IrfParser(irfFile, reader);
                parser.Parse();
                irfObjectRewrite = reader.IrfObject;
            }
            
            Assert.AreEqual(irfObjectOriginal, irfObjectRewrite);
        }
    }
}
