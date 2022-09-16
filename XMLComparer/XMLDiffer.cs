using System;
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

        public List<NodeDifferenceInfo> Differ(string s1, string s2)
        {
            XmlDocument firstDocument = new XmlDocument();
            XmlDocument secondDocument = new XmlDocument();

            firstDocument.LoadXml(s1);
            secondDocument.LoadXml(s2);

            List<NodeInfo> firstNodesInfo = new List<NodeInfo>();
            List<NodeInfo> secondNodesInfo = new List<NodeInfo>();

            // 1. count the nodes

            PrintNodes(0, firstDocument.ChildNodes, firstNodesInfo);
            PrintNodes(0, secondDocument.ChildNodes, secondNodesInfo);

            // 2. counting nodes
            Dictionary<string, int> firstNodeCount = CountNodes(firstDocument);
            Dictionary<string, int> secondNodeCount = CountNodes(secondDocument);

            

            // 3. type checking nodes

            List<XMLValue> firstCheckedTypes = DoTypeChecking(firstDocument);
            List<XMLValue> secondCheckedTypes = DoTypeChecking(secondDocument);

            List<NodeDifferenceInfo> infos = new List<NodeDifferenceInfo>();

            // 1. check DIFFERENT_NODE

            // TODO: move operation (A - B) union (B - A) to separate function
            HashSet<string> firstKeys = new HashSet<string>(firstNodeCount.Keys.ToHashSet());
            HashSet<string> secondKeys = new HashSet<string>(secondNodeCount.Keys.ToHashSet());

            HashSet<string> firstHalf = new HashSet<string>(firstKeys);
            firstHalf.ExceptWith(secondKeys);

            HashSet<string> secondHalf = new HashSet<string>(secondKeys);
            secondHalf.ExceptWith(firstKeys);

            HashSet<string> result = new HashSet<string>(firstHalf);
            result.UnionWith(secondHalf);

            // 1. check DIFFERENT_NODE

            foreach (string key in result)
            {
                NodeDifferenceInfo info = new NodeDifferenceInfo();
                info.differenceType = NodeDifferenceType.DIFFERENT_NODE;
                info.nodeName = key;
                info.nodeValue = "BLANK"; // TODO: get value inside node
                infos.Add(info);
            }

            HashSet<string> allKeys = new HashSet<string>(firstKeys);
            allKeys.UnionWith(secondKeys);

            // 2. check DIFFERENT_COUNT 

            foreach (string key in allKeys)
            {
                // TODO: fix implementation
                try
                {
                    if (!firstNodeCount[key].Equals(secondNodeCount[key]))
                    {
                        NodeDifferenceInfo info = new NodeDifferenceInfo();
                        info.differenceType = NodeDifferenceType.DIFFERENT_COUNT;
                        info.firstName = key;
                        info.secondName = key;
                        infos.Add(info);
                    }
                } catch (KeyNotFoundException) { }

            }

            // 3. check DIFFERENT_VALUE

            Debug.WriteLine("{0} {1}", firstCheckedTypes.ToArray().Length, secondCheckedTypes.ToArray().Length);

            for (int i = 0; i < firstCheckedTypes.ToArray().Length; i++)
            {
                if (!firstCheckedTypes[i].type.Equals(secondCheckedTypes[i].type))
                {
                    NodeDifferenceInfo info = new NodeDifferenceInfo();
                    info.differenceType = NodeDifferenceType.DIFFERENT_VALUE;

                    info.firstValue = firstCheckedTypes[i];
                    info.secondValue = secondCheckedTypes[i];
                    infos.Add(info);
                }
            }

            return infos;

        }

        private List<XMLValue> DoTypeChecking(XmlDocument firstDocument)
        {
            XmlNodeList nodetoTypeCheck = firstDocument.SelectNodes("//*");

            List<XMLValue> XMLValues = new List<XMLValue>();

            foreach (XmlNode node in nodetoTypeCheck)
            {
                string nodeContent = node.InnerText;
                XMLValue value = new XMLValue();

                if (Double.TryParse(nodeContent, out double dOut))
                {
                    value.type = XMLNodeType.NUMBER;
                }
                else if (Boolean.TryParse(nodeContent, out bool bOut))
                {
                    value.type = XMLNodeType.BOOL;
                }
                else
                {
                    value.type = XMLNodeType.STRING;
                }
                value.value = node.Name;
                XMLValues.Add(value);
            }

            return XMLValues;
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
        private void PrintNodes(int index, XmlNodeList nodes, List<NodeInfo> infos)
        {
            index++;
            if (nodes.Count == 0) return;

            foreach (XmlNode node in nodes)
            {
                NodeInfo info = new NodeInfo();
                info.level = index;
                info.nodeName = node.Name;
                
                infos.Add(info);
                PrintNodes(index, node.ChildNodes, infos);
                index--;
            }
        }
    }
}
