using System;
using System.Collections.Generic;
using System.Text;

namespace XMLComparer
{
    class ProtoDiffer : IDiffer
    {
        public ProtoDiffer() { }
        public List<NodeDifferenceInfo> Differ(string s1, string s2)
        {
            throw new NotImplementedException();
        }
    }
}
