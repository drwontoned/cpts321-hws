﻿// <copyright file="Spreadsheet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Spreadsheet class is a 2D array of cell's.
    /// </summary>
    public class Spreadsheet
    {
        private readonly SpreadsheetCell[,] spreadsheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="rows">
        /// int rows is number of rows for the Spreadsheet.
        /// </param>
        /// <param name="columns">
        /// int columns is the number of columns for this spreadsheet.
        /// </param>
        public Spreadsheet(int rows, int columns)
        {
            this.spreadsheet = new SpreadsheetCell[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    this.spreadsheet[i, j] = new SpreadsheetCell(i, j);
                    this.spreadsheet[i, j].PropertyChanged += this.TextChanged;
                }
            }
        }

        /// <summary>
        /// Cell property changed event.
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged = (sender, e) => { };

        /// <summary>
        /// Gets number of collumns in Spreadsheet.
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return this.spreadsheet.GetLength(1);
            }
        }

        /// <summary>
        /// Gets number of rows in Spreadsheet.
        /// </summary>
        public int RowCount
        {
            get
            {
                return this.spreadsheet.GetLength(0);
            }
        }

        /// <summary>
        /// Gets Cell based on the column and row that was input into function.
        /// </summary>
        /// <param name="column">
        /// int column is the column index of row from 2D array spreadsheet.
        /// </param>
        /// <param name="row">
        /// int row is the row index of row from 2D array spreadsheet.
        /// </param>
        /// <returns>
        /// Cell based on the row and column index.
        /// </returns>
        public Cell GetCell(int row, int column)
        {
            return this.spreadsheet[row, column];
        }

        /// <summary>
        /// function for setting value after text changed.
        /// </summary>
        /// <param name="sender">
        /// Object sender will be the cell being dealt with.
        /// </param>
        /// <param name="e">
        /// Property changed event argument.
        /// </param>
        public void TextChanged(object sender, PropertyChangedEventArgs e)
        {
            SpreadsheetCell cell = (SpreadsheetCell)sender;
            Console.WriteLine(cell.Text);
            if (cell.Text.IndexOf('=') != 0)
            {
                this.spreadsheet[cell.RowIndex, cell.ColumnIndex].SetValue(cell.Text);
                Console.WriteLine(this.spreadsheet[cell.RowIndex, cell.ColumnIndex].Value);
            }
            else
            {
                int row = this.GetRowNumber(cell.Text);
                int column = this.GetColumnNumber(cell.Text);
                this.spreadsheet[cell.RowIndex, cell.ColumnIndex].SetValue(this.spreadsheet[row, column].Text);
                Console.WriteLine(this.spreadsheet[row, column].Value);
            }

            this.CellPropertyChanged(cell, e);
        }

        /// <summary>
        /// Method for getting the row number from an string.
        /// </summary>
        /// <param name="s">
        /// string input that has a row number.
        /// </param>
        /// <returns>
        /// row number converted for the matching value in the 2D array.
        /// </returns>
        public int GetRowNumber(string s)
        {
            string number = string.Empty;
            for (int i = 2; i<s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    number += s[i];
                }
            }

            return int.Parse(number) - 1;
        }

        /// <summary>
        /// Method for getting the column number from an string.
        /// </summary>
        /// string input that has a column letter.
        /// </param>
        /// <returns>
        /// Column number in the 2D array based on the letter in the string.
        /// </returns>
        public int GetColumnNumber(string s)
        {
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int number = 0;
            for (int i = 1; i < s.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (s[i] == alphabet[j])
                    {
                        return j;
                    }
                }
            }

            return number;
        }

        /// <summary>
        /// Cell class for the spreadsheet.
        /// </summary>
        public class SpreadsheetCell : Cell
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
            /// Constructor for a SpreadsheetCell.
            /// </summary>
            /// <param name="row">
            /// int row is the index to be set for rowIndex.
            /// </param>
            /// <param name="column">
            /// int column is the index to be set for columnINdex.
            /// </param>
            public SpreadsheetCell(int row, int column)
                : base(row, column)
            {
            }

            /// <summary>
            /// Sets value.
            /// </summary>
            /// <param name="value">
            /// string value Value will be set to.
            /// </param>
            public void SetValue(string value)
            {
                this.value = value;
            }
        }
    }
}
