﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

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
            private string firstFileContent;
            private string secondFileContent;

            public string FirstFileContent { get; set }
            public XMLComparer()
            {
                firstFileContent = string.Empty;
                secondFileContent = string.Empty;
            }

            private string ReadFile()
            {

                var FileContent = string.Empty;

                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "XML Files(*.xml)|*.xml";
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var FileStream = dialog.OpenFile();

                    using (StreamReader reader = new StreamReader(FileStream))
                    {
                        FileContent = reader.ReadToEnd();
                    }
                }

                return FileContent;
            }

            public bool ReadFirstFile()
            {
                firstFileContent = ReadFile();
                if (firstFileContent.Equals(string.Empty))
                {
                    return false;
                }
                return true;
            }

            public bool ReadSecondFile()
            {
                secondFileContent = ReadFile();
                if (secondFileContent.Equals(string.Empty))
                {
                    return false;
                }
                return true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            comparer.ReadFirstFile();


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comparer.ReadSecondFile();
        }
    }
}