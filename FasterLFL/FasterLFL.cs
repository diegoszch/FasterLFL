using System.Text;
using System.Collections.Generic;

namespace System.IO
{
    public class FasterLFL2
    {
        public static StringBuilder GetLastLines(string filePath, int lastlines = 1)
        {
            long offset;

            var lines = new StringBuilder();
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                if (!fs.CanRead)
                    throw new IOException("Não é possível fazer a leitura do arquivo");

                var line = new List<char>();
                for (offset = 1; offset <= fs.Length; offset++)
                {
                    fs.Seek(-offset, SeekOrigin.End);

                    var read = fs.ReadByte();
                    if (read == 0x0a)
                    {
                        line.Reverse();
                        lines.AppendLine(new string(line.ToArray()));

                        lastlines -= 1;

                        if(lastlines < 1)
                            break;
                        else
                            continue;
                    }

                    line.Add(Convert.ToChar(read));
                }
            }

            return lines;
        }
    }
}