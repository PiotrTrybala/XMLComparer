using System;
using System.Collections.Generic;
using System.Text;

namespace XMLComparer
{

    public struct NodeInfo
    {
        public int level;
        public string nodeName;
    }

    // TODO: maybe change from public to private and add getters and setters
    // TODO: check if struct have to be public in order to work
    public struct FileInfo
    {
        public string filePath;
        public string content;
    };
    public enum NodeDifferenceType
    {
        DIFFERENT_NODE, // if node is not present in another file
        DIFFERENT_COUNT // if node is present in another file but count is different
    }
    public struct NodeDifferenceInfo
    {
        NodeDifferenceType differenceType;
        string firstNodeName;
        string secondNodeName;
    }
}
