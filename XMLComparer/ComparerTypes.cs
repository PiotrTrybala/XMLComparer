using System;
using System.Collections.Generic;
using System.Text;

namespace XMLComparer
{

    public enum DifferenceType
    {
        NEW_LINE,
        DIFFERENT_LINE
    }
    // TODO: maybe change from public to private and add getters and setters
    // TODO: check if struct have to be public in order to work
    public struct FileInfo
    {
        public string filePath;
        public string content;
    };

    public struct DifferenceInfo
    {
        public int lineNumber;
        public DifferenceType type;
        public string lineContent1;
        public string lineContent2;
    }
}
