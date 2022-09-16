using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace XMLComparer
{
    public partial class MainForm : Form
    {
        private readonly XMLComparer comparer;
        public static List<NodeDifferenceInfo> globalDifferences;
        public MainForm()
        {
            InitializeComponent();
            comparer = new XMLComparer();

        }

        // TODO: find better way to do that
        public enum File
        {
            FIRST,
            SECOND
        }

        class XMLComparer
        {
            private FileInfo firstFile;
            private FileInfo secondFile;

            public FileInfo FirstFile { get { return firstFile; } }
            public FileInfo SecondFile { get { return secondFile; } }

            public XMLComparer()
            {
                firstFile = new FileInfo();
                secondFile = new FileInfo();
            }

            public bool ReadFile(File file)
            {
                FileInfo info = new FileInfo();
                var fileContent = string.Empty;

                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "XML Files(*.xml)|*.xml";
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    info.filePath = dialog.FileName;

                    var FileStream = dialog.OpenFile();

                    using (StreamReader reader = new StreamReader(FileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    info.content = fileContent;
                }

                if (file == File.FIRST)
                {
                    firstFile = info;
                } else
                {
                    secondFile = info;
                }

                return true;
            }

            public void Compare()
            {

                

                FileDiffer differ = new FileDiffer(FileTypes.XML, firstFile.content, secondFile.content);

                List<NodeDifferenceInfo> fileDifferences = differ.Differences;

                // TODO: graphical representation

                globalDifferences = new List<NodeDifferenceInfo>(fileDifferences);
                

                


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            comparer.ReadFile(File.FIRST);

            this.file1.Text = "Wczytano: " + this.comparer.FirstFile.filePath ;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comparer.ReadFile(File.SECOND);

            this.file2.Text = "Wczytano: " + comparer.SecondFile.filePath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comparer.Compare();

            DifferenceWindow window = new DifferenceWindow();
            window.Show();
        }
    }
}
