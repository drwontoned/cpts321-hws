// <copyright file="Spreadsheet.cs" company="PlaceholderCompany">
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
            // Because 2D arrays are [row, column] it is formatted different from cells which are (column, row)
            this.spreadsheet = new SpreadsheetCell[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    this.spreadsheet[i, j] = new SpreadsheetCell(j, i);
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
        public Cell GetCell(int column, int row)
        {
            return this.spreadsheet[row, column];
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
            public SpreadsheetCell(int column, int row)
                : base(column, row)
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
