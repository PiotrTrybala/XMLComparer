using System;
using System.Collections.Generic;
using System.Text;

namespace XMLComparer
{
    public interface IDiffer { 
        
        void Differ(string s1, string s2);
    }
}
