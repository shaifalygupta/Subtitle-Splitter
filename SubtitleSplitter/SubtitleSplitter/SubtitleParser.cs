using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace SubtitleSplitter
{
    public class SubtitleParser
    {
        public string[] Parse(string str)
        {
            if (str.Trim().Length == 0)
                return new  string[] { "Please insert Some Values for parsing." };
            const Int32 MAX_WIDTH = 25;
            try
            {
                int offset = 0;               
                string text = Regex.Replace(str, @"\s{2,}", " ");
                List<string> lines = new List<string>();
                char[] splitStr = { ',', '\r', '\n' };
                string line = "";
                while (offset < text.Length)
                {
                    int index_split = text.IndexOfAny(splitStr, offset);
                    if ((index_split - offset) <= 5 && (index_split - offset) >= 0)
                    {                        
                        line = text.Substring(offset, (index_split - offset));

                        int offset1 = offset + line.Length + 1;
                        string str1 = text.Substring(offset1);
                        if (str1.Length > 0 && str1.Length <= 5)
                            line = text.Substring(offset);                       
                    }
                    else
                    {
                        int index = text.LastIndexOf(" ",
                                      Math.Min(text.Length, offset + MAX_WIDTH));

                        line = text.Substring(offset,
                           (index - offset <= 0 ? text.Length : index) - offset);                        
                    }
                    offset += line.Length + 1;
                    
                    if (line.Length != 0)
                    {
                        lines.Add(line.Trim());
                    }                    
                }
                string[] strq = lines.ToArray();
                return strq;
            }
            catch
            {
                return new string[] { "Getting some error while parsing." };
            }
        }
    }
}
