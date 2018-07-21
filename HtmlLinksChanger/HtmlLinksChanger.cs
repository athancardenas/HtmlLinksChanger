﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace HtmlLinksChanger
{
    public partial class HtmlLinksChanger : Form
    {
        public HtmlLinksChanger()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Trim().Equals(string.Empty) &&
                !textBox3.Text.Trim().Equals(string.Empty))
            {
                HtmlFile htmlFileSource = new HtmlFile(textBox1.Text);
                HtmlHref htmlHref = new HtmlHref(textBox2.Text, textBox3.Text);

                List<string> resultFileLines = new List<string>();

                htmlFileSource.HtmlFileLines.ForEach(l => {
                    resultFileLines.Add(htmlHref.ReplaceHrefString(l));
                });

                if (resultFileLines.Count > 0)
                {
                    string resultFolder = @"result\";
                    string resultFolderPath = Path.GetDirectoryName(htmlFileSource.FilePath) + @"\" + resultFolder;
                    string resultFilePath = resultFolderPath + Path.GetFileName(htmlFileSource.FilePath);

                    if (!Directory.Exists(resultFolderPath))
                    {
                        Directory.CreateDirectory(resultFolderPath);
                    }

                    if (File.Exists(resultFilePath))
                    {
                        File.Delete(resultFilePath);
                    }

                    using (StreamWriter sw = new StreamWriter(resultFilePath))
                    {
                        resultFileLines.ForEach(l => {
                            sw.WriteLine(l);
                        });
                    }
                }
            }

            else
            {
                MessageBox.Show("Make sure to fill-out file to change and string replacement fields.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void _CreateResultFolder()
        {

        }

        private void _SelectResultFileInExplorer()
        {

        }
    }
}