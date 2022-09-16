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

    public enum XMLNodeType
    {
        NUMBER,
        STRING,
        BOOL
    };

    // 
    public struct NodeType
    {
        public XMLNodeType type;
        public string name;
    }

    // NodeDifferenceType: type of difference encountered during differ process
    public enum NodeDifferenceType
    {
        DIFFERENT_NODE, // if node is not present in another file
        DIFFERENT_COUNT, // if node is present in another file but count is different
        DIFFERENT_VALUE // if node is present in another file and count is same but value is different
    }

    // XMLValue: struct for storing info about value inside XML node: type - type of value (NUMBER,BOOL,STRING), value - string representation of value
    public struct XMLValue
    {
        public XMLNodeType type;
        public string value;
    }

    // NodeDifferenceInfo: struct for storing info about difference between two nodes
    // TODO: fix what to display
    public struct NodeDifferenceInfo
    {
        public NodeDifferenceType differenceType;
        // nodeName and nodeValue are set when DIFFERENT_NODE
        public string nodeName;
        public string nodeValue;
        // firstName and secondName are set when DIFFERENT_COUNT
        public string firstName;
        public string secondName;
        // firstValue and secondValue are set when DIFFERENT_VALUE
        public XMLValue firstValue;
        public XMLValue secondValue;
    }
}
