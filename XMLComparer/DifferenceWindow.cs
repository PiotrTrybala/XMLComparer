using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLComparer
{
    public partial class DifferenceWindow : Form
    {

        private void PopulateDataGridView()
        {
            
            foreach (NodeDifferenceInfo info in MainForm.globalDifferences)
            {
                switch(info.differenceType)
                {
                    case NodeDifferenceType.DIFFERENT_NODE:
                        string [] row1 = new string[] {
                            NodeDifferenceType.DIFFERENT_NODE.ToString(),
                            info.nodeName,
                            info.nodeValue,
                            "-",
                            "-"
                        };
                        dataGridView1.Rows.Add(row1);
                        break;
                    case NodeDifferenceType.DIFFERENT_COUNT:
                        string[] row2 = new string[] {
                            NodeDifferenceType.DIFFERENT_COUNT.ToString(),
                            info.nodeNameCount,
                            info.firstCount.ToString(),
                            info.secondCount.ToString(),
                            "-"
                        };
                        dataGridView1.Rows.Add(row2);

                        break;
                    case NodeDifferenceType.DIFFERENT_VALUE:
                        string[] row3 = new string[] {
                            NodeDifferenceType.DIFFERENT_VALUE.ToString(),
                            info.firstValue.value,
                            info.firstValue.type.ToString(),
                            info.secondValue.value,
                            info.secondValue.type.ToString()
                        };
                        dataGridView1.Rows.Add(row3);
                        break;
                    default:
                        break;

                    

                }

            }

        }


        public DifferenceWindow()
        {
            InitializeComponent();
            PopulateDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
