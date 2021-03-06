using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
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
            // because 2d arrays are [row, column] it is formatted different from cells which are (column, row)
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
        /// Cell class for the spreadsheet.
        /// </summary>
        public class SpreadsheetCell : Cell
        {
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
        }
    }
}
