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

    /// <summary>
    /// Main class where all functionality regarding loading and saving files occurs.
    /// </summary>
    public partial class HW3 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HW3"/> class.
        /// </summary>
        public HW3()
        {
            this.InitializeComponent();
            this.textBox1.Select();
        }

        /// <summary>
        /// Method that takes a file, puts the text in the text box into that file, then saves that file.
        /// </summary>
        /// <param name="file">
        /// FileStream file is the file getting text saved into.
        /// </param>
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

        /// <summary>
        /// Method for loading text from a TextReader into the text box.
        /// </summary>
        /// <param name="sr">
        /// TextReader sr is the text getting read.
        /// </param>
        private void LoadText(TextReader sr)
        {
            this.textBox1.Text = sr.ReadToEnd(); // fill in text box with string from ReadToEnd
            sr.Close(); // close out of TextReader
        }

        /// <summary>
        /// Load HW3.
        /// </summary>
        /// <param name="sender">
        /// object sender.
        /// </param>
        /// <param name="e">
        /// event argument.
        /// </param>
        private void HW3_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Method for choosing a .txt file and loading the text from that file into the text box.
        /// </summary>
        /// <param name="sender">
        /// object sender.
        /// </param>
        /// <param name="e">
        /// EventArgs e.
        /// </param>
        private void LoadFromFileToolStripMenuItem1_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Method for loading the first 50 Fibonacci numbers into the text box.
        /// </summary>
        /// </summary>
        /// <param name="sender">
        /// object sender.
        /// </param>
        /// <param name="e">
        /// EventArgs e.
        /// </param>
        private void LoadFibonacciNumbersfirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadText(new FibonacciTextReader(50)); // LoadText for a FibonacciTextReader of size 50
        }

        /// <summary>
        /// Method for loading the first 100 Fibonacci numbers into the text box.
        /// </summary>
        /// </summary>
        /// <param name="sender">
        /// object sender.
        /// </param>
        /// <param name="e">
        /// EventArgs e.
        /// </param>
        private void LoadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadText(new FibonacciTextReader(100)); // LoadText for a FibonacciTextReader of size 100
        }

        /// <summary>
        /// Method that opens up a saveFileDialog to allow you to save the text in the text box to a file.
        /// </summary>
        /// <param name="sender">
        /// object sender.
        /// </param>
        /// <param name="e">
        /// EventArgs e.
        /// </param>
        private void SaveToFileToolStripMenuItem_Click(object sender, EventArgs e)
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
