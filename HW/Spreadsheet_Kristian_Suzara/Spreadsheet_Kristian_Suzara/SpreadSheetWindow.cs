// <copyright file="SpreadSheetWindow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Spreadsheet_Kristian_Suzara
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
    using SpreadsheetEngine;

    /// <summary>
    /// Spreadsheet window class that displays is the winform app.
    /// </summary>
    public partial class SpreadSheetWindow : Form
    {
        private Spreadsheet formSpreadsheet;
        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadSheetWindow"/> class.
        /// </summary>
        public SpreadSheetWindow()
        {
            this.formSpreadsheet = new Spreadsheet(50, 26);
            this.InitializeComponent();

            // Create collumns from A-Z
            string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            for (int i = 0; i < 26; i++)
            {
                this.dataGridView.Columns.Add(alphabet[i], alphabet[i]);
            }

            // Create rows from 1-50
            for (int j = 0; j < 50; j++)
            {
                string header = (j + 1).ToString();
                this.dataGridView.Rows.Add();
                this.dataGridView.Rows[j].HeaderCell.Value = header;
            }

            this.formSpreadsheet.CellPropertyChanged += this.CellChanged;
        }

        /// <summary>
        /// CellChanged event function.
        /// </summary>
        /// <param name="sender">
        /// object sender.
        /// </param>
        /// <param name="e">
        /// PropertyChangedEventArgs e.
        /// </param>
        private void CellChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell newCell = (Cell)sender;
            this.dataGridView[newCell.ColumnIndex, newCell.RowIndex].Value = newCell.Value;
        }
    }
}
