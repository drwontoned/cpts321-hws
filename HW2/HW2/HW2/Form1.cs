// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Main class for window app.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// constructor for Form1 class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            RandomList list = new RandomList();
            this.textBox1.Text = list.StringOutput();
        }

        /// <summary>
        /// Load method.
        /// </summary>
        /// <param name="sender">
        /// object sender.
        /// </param>
        /// <param name="e">
        /// EventArgs e.
        /// </param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
