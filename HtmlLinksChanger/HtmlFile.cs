using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlLinksChanger
{
    public class HtmlFile
    {
        public string FilePath { get; set; }
        public List<string> HtmlFileLines { get; set; }

        public HtmlFile(string filePath)
        {
            FilePath = filePath.Trim();
            HtmlFileLines = new List<string>();
            _LoadFileLines();
        }

        private void _LoadFileLines()
        {
            using (StreamReader sr = File.OpenText(FilePath))
            {
                string s = string.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    HtmlFileLines.Add(s);
                }
            }
        }
    }
}
