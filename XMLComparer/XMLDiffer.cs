using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace XMLComparer
{
    class XMLDiffer : IDiffer
    {
        public XMLDiffer() { }

        public List<DifferenceInfo> Differ(string s1, string s2)
        {
            List<DifferenceInfo> differences = new List<DifferenceInfo>();

            string[] linesOfFirst = s1.Split("\r\n").Select(s => s.Trim()).ToArray();
            string[] linesOfSecond = s2.Split("\r\n").Select(s => s.Trim()).ToArray();

            

            int lengthOfFirst = linesOfFirst.Length;
            int lengthOfSecond = linesOfSecond.Length;

            for (int i = 0; i < Math.Max(lengthOfFirst, lengthOfSecond); i++)
            {
                string a1 = string.Empty, a2 = string.Empty;
                if (i < lengthOfFirst) a1 = linesOfFirst[i];
                if (i < lengthOfSecond) a2 = linesOfSecond[i];

                Debug.WriteLine("{0} {1}", a1, a2);

            }
            if (lengthOfFirst != lengthOfSecond)
            {
                Debug.WriteLine("Difference lengths");
                int startIndex = Math.Min(lengthOfFirst, lengthOfSecond);
                int endIndex = Math.Max(lengthOfFirst, lengthOfSecond);

                // TODO: find more "elegent" way to do that, but if works and it is ugly then it is good :)
                string[] array;
                if (lengthOfFirst < lengthOfSecond) array = linesOfSecond;
                else array = linesOfFirst;


                for (int i = startIndex; i < endIndex; i++)
                {
                    // TODO: maybe create MakeDifferenceInfo function
                    DifferenceInfo info = new DifferenceInfo();
                    info.lineNumber = i;
                    info.type = DifferenceType.NEW_LINE;
                    info.lineContent1 = "BLANK";
                    info.lineContent2 = array[i];

                    differences.Add(info);
                }
            }

            // if l1 = l2

            for (int i = 0; i < lengthOfFirst; i++)
            {

                if (!linesOfFirst[i].Equals(linesOfSecond[i]))
                {
                    DifferenceInfo info = new DifferenceInfo();

                    info.lineNumber = i;
                    info.type = DifferenceType.DIFFERENT_LINE;
                    info.lineContent1 = linesOfFirst[i];
                    info.lineContent2 = linesOfSecond[i];

                    differences.Add(info);
                }

            }
            


            return differences;
        }
    }
}
