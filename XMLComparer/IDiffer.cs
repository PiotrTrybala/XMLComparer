using System;
using System.Collections.Generic;
using System.Text;

namespace XMLComparer
{
    public interface IDiffer { 
        
        List<NodeDifferenceInfo> Differ(string s1, string s2);
    }
}
