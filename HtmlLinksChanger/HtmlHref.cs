using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlLinksChanger
{
    public class HtmlHref
    {
        private static List<char> _HrefQuotes { get; set; }
        private static string _HrefSubstringToReplace { get; set; }
        private static string _HrefSubstringReplacement { get; set; }

        private List<string> _BeforeQuotesHrefs { get; set; }

        public string HrefString { get; set; }

        public HtmlHref(string hrefSubstringToReplace, string hrefSubstringReplacement)
        {
            _HrefQuotes = new List<char>();
            _BeforeQuotesHrefs = new List<string>();

            AddBeforeQuotesHrefs(new string[] {
                "href="
            });

            _HrefQuotes.AddRange(new char[] {
                '\''
                , '"'
            });

            _HrefSubstringToReplace = hrefSubstringToReplace;
            _HrefSubstringReplacement = hrefSubstringReplacement;
        }

        public void AddBeforeQuotesHrefs(string[] additionalBeforeQuotesHrefs)
        {
            _BeforeQuotesHrefs.AddRange(additionalBeforeQuotesHrefs);
        }

        public string ReplaceHrefString(string lineForReplacement)
        {
            _BeforeQuotesHrefs.ForEach(h =>
            {
                _HrefQuotes.ForEach(q =>
                {
                    string substringToReplace = h + q + _HrefSubstringToReplace;

                    if (lineForReplacement.Contains(substringToReplace))
                    {
                        string substringReplacement = h + q + _HrefSubstringReplacement;
                        lineForReplacement = lineForReplacement.Replace(substringToReplace, substringReplacement);
                    }
                });
            });

            return lineForReplacement;
        }
    }
}
