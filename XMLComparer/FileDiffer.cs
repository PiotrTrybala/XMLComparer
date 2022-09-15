using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace XMLComparer
{
    class FileDiffer
    {

        private FileTypes type;
        private IDiffer differ;
        private List<DifferenceInfo> differences;
        // TODO: do check if two files are different format, then NOTSAMEFORMATEXCEPTION is run
        public FileDiffer(FileTypes type, string s1, string s2)
        {
            this.type = type;

            switch(this.type)
            {
                case FileTypes.XML:
                    differ = new XMLDiffer();
                    break;
                case FileTypes.PROTO:
                    differ = new ProtoDiffer();
                    break;
                case FileTypes.NONE:
                    throw new InvalidOperationException();
            }
            // TODO: maybe move the difference analysis to separate function
            this.differences = differ.Differ(s1, s2);

            foreach (DifferenceInfo info in this.differences)
            {
                Debug.WriteLine("{0} {1} {2} {3}", info.lineNumber, info.type.ToString(), info.lineContent1, info.lineContent2);
            }


        }
    }
}
