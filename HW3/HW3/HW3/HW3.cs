// <copyright file="HW3.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class HW3 : Form
    {
        public HW3()
        {
            this.InitializeComponent();
            this.textBox1.Select();
        }

        private void SaveText(FileStream file)
        {
            StreamWriter sw = new StreamWriter(file); // create a StreamWriter for based on FileStream

            // write text from text box to file using SteamWriter
            using (sw)
            {
                sw.Write(this.textBox1.Text);
                file.SetLength(file.ToString().Length - 20);
            }

            file.Close(); // close out of FileStream
            sw.Close(); // close out of StreamWriter

        }

        private void LoadText(TextReader sr)
        {
            this.textBox1.Text = sr.ReadToEnd(); // fill in text box with string from ReadToEnd
            sr.Close(); // close out of TextReader
        }

        private void HW3_Load(object sender, EventArgs e)
        {

        }

        private void loadFromFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*"; // filter files such that only .txt files can be seen.

            // check for existance of file.
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream file = this.openFileDialog1.OpenFile(); // file to be loaded
                this.LoadText(new StreamReader(file)); // Loads text from file into textbox.
                file.Close(); // close out of Stream
            }

        }

        private void loadFibonacciNumbersfirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadText(new FibonacciTextReader(50));
        }

        private void loadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadText(new FibonacciTextReader(100));
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*"; // filter files such that only .txt files can be saved
            this.saveFileDialog1.FileName = this.openFileDialog1.FileName;

            // check for existance of file.
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Create file stream for the file going to be saved
                FileStream file = new FileStream(
                    this.saveFileDialog1.FileName,
                    FileMode.OpenOrCreate,
                    FileAccess.ReadWrite,
                    FileShare.None);

                this.SaveText(file); // saves text in textbox into a file
            }
        }
    }
}
