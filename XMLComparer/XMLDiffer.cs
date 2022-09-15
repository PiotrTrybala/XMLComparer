﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLComparer
{
    class XMLDiffer : IDiffer
    {
        public XMLDiffer() { }

        public List<NodeInfo> Differ(string s1, string s2)
        {
            XmlDocument firstDocument = new XmlDocument();
            XmlDocument secondDocument = new XmlDocument();

            firstDocument.LoadXml(s1);
            secondDocument.LoadXml(s2);

            List<NodeInfo> firstNodesInfo = new List<NodeInfo>();
            List<NodeInfo> secondNodesInfo = new List<NodeInfo>();

            // 1. count the nodes
            // 2. check rarity of nodes



            PrintNodes(firstDocument.ChildNodes, firstNodesInfo);
            index = 0;
            PrintNodes(secondDocument.ChildNodes, secondNodesInfo);

            foreach (NodeInfo info in firstNodesInfo)
            {
                Debug.WriteLine("{0} <- {1}", info.level, info.nodeName);
            }
            Debug.WriteLine("=======================");
            foreach (NodeInfo info in secondNodesInfo)
            {
                Debug.WriteLine("{0} <- {1}", info.level, info.nodeName);
            }

            // 2. counting nodes
            Dictionary<string, int> firstNodeCount = CountNodes(firstDocument);
            Dictionary<string, int> secondNodeCount = CountNodes(secondDocument);

            HashSet<string> uniqueNodes = new HashSet<string>();

            foreach (KeyValuePair<string, int> info in firstNodeCount)
            {
                Debug.WriteLine("{0} <- {1}", info.Key, info.Value);
            }
            Debug.WriteLine("=======================");
            foreach (KeyValuePair<string, int> info in secondNodeCount)
            {
                Debug.WriteLine("{0} <- {1}", info.Key, info.Value);
            }

            // 3. type checking nodes



            List<NodeType> firstCheckedTypes = DoTypeChecking(firstDocument);
            List<NodeType> secondCheckedTypes = DoTypeChecking(secondDocument);
            

            return null;

        }

        private List<NodeType> DoTypeChecking(XmlDocument firstDocument)
        {
            XmlNodeList nodetoTypeCheck = firstDocument.SelectNodes("//*");

            List<NodeType> nodeTypes = new List<NodeType>();

            foreach (XmlNode node in nodetoTypeCheck)
            {
                string nodeContent = node.InnerText;
                NodeType nodeType = new NodeType();
                double dOut;
                bool bOut;

                if (Double.TryParse(nodeContent, out dOut))
                {
                    nodeType.type = XMLNodeType.NUMBER;
                }
                else if (Boolean.TryParse(nodeContent, out bOut))
                {
                    nodeType.type = XMLNodeType.BOOL;
                }
                else
                {
                    nodeType.type = XMLNodeType.STRING;
                }
                nodeType.name = node.Name;
                nodeTypes.Add(nodeType);
            }

            return nodeTypes;
        }

        private Dictionary<string, int> CountNodes(XmlDocument firstDocument)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            XmlNodeList elements = firstDocument.SelectNodes("//*");

            foreach (XmlNode node in elements)
            {

                if (!dict.ContainsKey(node.Name))
                {
                    dict.Add(node.Name, 1);
                    continue;
                }
                dict[node.Name]++;

            }

            return dict;
        }

        private int index = 0;
        private void PrintNodes(XmlNodeList nodes, List<NodeInfo> infos)
        {
            index++;
            if (nodes.Count == 0) return;

            foreach (XmlNode node in nodes)
            {
                NodeInfo info = new NodeInfo();
                info.level = index;
                info.nodeName = node.Name;
                
                infos.Add(info);
                PrintNodes(node.ChildNodes, infos);
                index--;
            }
        }
    }
}
