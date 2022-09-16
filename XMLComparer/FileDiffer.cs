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
        private List<NodeDifferenceInfo> differences;

        public List<NodeDifferenceInfo> Differences { get { return differences; } }

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

            foreach (NodeDifferenceInfo info in differences)
            {

                /*switch (info.differenceType)
                {
                    case NodeDifferenceType.DIFFERENT_NODE:
                        Debug.Print("{0} -> {1} {2}",
                            NodeDifferenceType.DIFFERENT_NODE.ToString(),
                            info.nodeName,
                            info.nodeValue
                            );
                        break;
                    case NodeDifferenceType.DIFFERENT_COUNT:
                        Debug.Print("{0} -> {1} {2}",
                            NodeDifferenceType.DIFFERENT_COUNT.ToString(),
                            info.firstName,
                            info.secondName
                            );
                        break;
                    case NodeDifferenceType.DIFFERENT_VALUE:
                        Debug.Print("{0} -> {1} {2} | {3} {4}",
                            NodeDifferenceType.DIFFERENT_VALUE.ToString(),
                            info.firstValue.type.ToString(), info.firstValue.value,
                            info.secondValue.type.ToString(), info.secondValue.value
                            );
                        break;
                    default:
                        break;
                }*/
            }
        }
    }
}
