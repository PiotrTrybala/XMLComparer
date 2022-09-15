using System;
using System.Collections.Generic;
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
            if (lengthOfFirst != lengthOfSecond)
            {
                int startIndex = Math.Min(lengthOfFirst, lengthOfSecond);
                int endIndex = Math.Min(lengthOfFirst, lengthOfSecond);

                for (int i = startIndex; i < endIndex; i++)
                {
                    // TODO: maybe create MakeDifferenceInfo function
                    DifferenceInfo info = new DifferenceInfo();
                    info.lineNumber = i;
                    info.type = DifferenceType.NEW_LINE;
                    info.lineContent1 = linesOfFirst[i];
                    info.lineContent2 = linesOfSecond[i];

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
