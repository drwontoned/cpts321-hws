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
