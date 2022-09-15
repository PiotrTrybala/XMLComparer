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
        public MainForm()
        {
            InitializeComponent();
            comparer = new XMLComparer();

        }

        class XMLComparer
        {
            private FileVars firstFile;
            private FileVars secondFile;

            public string FirstFilePath
            {
                get
                {
                    return firstFile.pathName;
                }
            }

            public string SecondFilePath
            {
                get
                {
                    return secondFile.pathName;
                }
            }

            public string FirstFileContent
            {
                get
                {
                    return firstFile.content;
                }
            }

            public string SecondFileContent
            {
                get
                {
                    return secondFile.content;
                }
            }
            public XMLComparer()
            {
                firstFile = new FileVars();
                secondFile = new FileVars();
            }

            struct FileVars
            {
                public string pathName;
                public string content;
            }

            private FileVars ReadFile()
            {
                FileVars vars = new FileVars();
                var FileContent = string.Empty;

                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "XML Files(*.xml)|*.xml";
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    vars.pathName = dialog.FileName;

                    var FileStream = dialog.OpenFile();

                    using (StreamReader reader = new StreamReader(FileStream))
                    {
                        FileContent = reader.ReadToEnd();
                    }

                    vars.content = FileContent;
                }

                return vars;
            }

            public bool ReadFirstFile()
            {
                firstFile = ReadFile();

                // TODO: check if file is empty
                return true;
            }

            public bool ReadSecondFile()
            {
                secondFile = ReadFile();

                // TODO: check if file is empty
                return true;
            }

            public void Compare()
            {

                Debug.WriteLine(FirstFileContent);
                Debug.WriteLine(SecondFileContent);

                if (FirstFilePath == SecondFilePath)
                {
                    MessageBox.Show("Plik jest taki sam"); // TODO: add clearer info messages
                    return;
                }

                if (FirstFileContent == SecondFileContent)
                {
                    MessageBox.Show("Plik jest taki sam"); // TODO: add clearer info messages
                    return;
                }


                MessageBox.Show("Pliki są różne");

                /*                XmlDocument FirstDoc = new XmlDocument();
                                XmlDocument SecondDoc = new XmlDocument();

                                FirstDoc.LoadXml(FirstFileContent);
                                SecondDoc.LoadXml(SecondFileContent);

                                Debug.WriteLine(FirstDoc.InnerXml);
                                Debug.WriteLine(SecondDoc.InnerXml);*/
                // TODO: later add complex analysis for what is different and what is not (maybe)

                FileDiffer differ = new FileDiffer(FileTypes.XML, FirstFileContent, SecondFileContent);

                


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            comparer.ReadFirstFile();

            Debug.WriteLine(comparer.FirstFileContent);

            this.file1.Text = "Wczytano: " + comparer.FirstFilePath;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comparer.ReadSecondFile();

            Debug.WriteLine(comparer.SecondFileContent);

            this.file2.Text = "Wczytano: " + comparer.SecondFilePath;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Debug.WriteLine(comparer.SecondFileContent);
            Debug.WriteLine(comparer.FirstFileContent);

            comparer.Compare();
        }
    }
}
