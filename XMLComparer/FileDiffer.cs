using System;
using System.Collections.Generic;
using System.Text;

namespace XMLComparer
{
    class FileDiffer
    {

        private FileTypes type;
        private IDiffer differ;

        public FileDiffer(FileTypes type, string s1, string s2)
        {
            this.type = type;

            switch(this.type)
            {
                case FileTypes.XML:
                    differ = new XMLDiffer(s1, s2);
                    break;
                case FileTypes.PROTO:
                    differ = new ProtoDiffer(s1, s2);
                    break;
                case FileTypes.PROTO:
                    throw new InvalidOperationException();
            }
        }
    }
}
