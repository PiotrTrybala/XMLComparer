using System;
using System.Collections.Generic;
using System.Text;

namespace XMLComparer
{
    class FileDiffer
    {

        private FileType type;
        private IDiffer differ;
        public FileDiffer(FileType type)
        {
            this.type = type;

            switch(this.type)
            {
                case FileType.XML:
                    differ = new XMLDiffer();
                    break;
                case FileType.PROTO:
                    differ = new ProtoDiffer();
                    break;
                case FileType.PROTO:
                    throw new UnknownTypeException();
            }
        }
    }
}
