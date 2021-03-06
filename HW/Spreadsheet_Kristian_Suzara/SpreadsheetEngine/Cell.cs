// <copyright file="Cell.cs" company="PlaceholderCompany">
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
    /// Abstract class cell that implements INotifyPropertyChanged.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        // protected strings for text and value
        protected string text = string.Empty;
        protected string value = string.Empty;

        // readonly ints for the row and column index.
        private readonly int rowIndex;
        private readonly int columnIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="row">
        /// int value for the row index.
        /// </param>
        /// <param name="column">
        /// int value for the column index.
        /// </param>

        public Cell(int row, int column)
        {
            this.columnIndex = column;
            this.rowIndex = row;
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Gets or sets getter for Text.
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs(" "));
                }

                return;
            }
        }

        /// <summary>
        /// Gets getter for Value.
        /// </summary>
        public string Value { get => this.value; }

        /// <summary>
        /// Gets getter for ColumnIndex.
        /// </summary>
        public int ColumnIndex { get => this.columnIndex; }

        /// <summary>
        /// Gets getter for RowIndex.
        /// </summary>
        public int RowIndex { get => this.rowIndex; }
    }
}
