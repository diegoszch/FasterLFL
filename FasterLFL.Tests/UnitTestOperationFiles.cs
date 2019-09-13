using System;
using Xunit;
using System.IO;
using System.Text.RegularExpressions;

namespace FasterLFL.Tests
{
    public class UnitTestOperationFiles
    {
        private string _file = "/tmp/cobaia.log";

        [Fact]
        public void TestExtractLastLines()
        {
            int qtdLines = 10;
            var sb = FasterLFL2.GetLastLines(_file, qtdLines);

            Assert.True(Regex.Matches(sb.ToString(), Environment.NewLine).Count == qtdLines);
        }

        [Fact(Skip = "true")]
        public void PopulateTextFile()
        {
            var faker = new Bogus.Faker();
            using (var writer = new StreamWriter(_file))
            {
                for (var i = 0; i < int.MaxValue; i++)
                    writer.WriteLine($"Linha {i} - {faker.Lorem.Paragraph()}");
            }
        }
    }
}