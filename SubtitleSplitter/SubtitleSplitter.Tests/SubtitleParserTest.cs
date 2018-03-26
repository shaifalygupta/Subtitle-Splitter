using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net.Http;

namespace SubtitleSplitter.Tests
{
    [TestFixture]
    class SubtitleParserTest
    {
        [Test]
        public void ParseTest()
        {
            string SAMPLE_TEXT =
                "Please write a program that breaks this text into small chucks. Each chunk should have a maximum length of 25 " +
                "characters. The program should try to break on complete sentences or punctuation marks if possible.  " +
                "If a comma or sentence break occurs within 5 characters of the max line length, the line should be broken early.  " +
                "The exception to this rule is when the next line will only contain 5 characters.  Redundant whitespace should " +
                "not be counted between lines, and any duplicate   spaces should be removed.  " +
                "Does this make sense? If not please ask for further clarification, an array containing " +
                "the desired outcome has been provided below. Any text beyond this point is not part of the instructions, " +
                "it's only here to ensure test converge. Finish line. Aaa asdf asdfjk las, asa.";

            var controller = new SubtitleParser();


            string[] Result = controller.Parse(SAMPLE_TEXT);

            Assert.IsNotNull(Result);
            //Assert.AreEqual(Result[0].ToString(), "Getting some error while parsing.");

        }
    }


}
