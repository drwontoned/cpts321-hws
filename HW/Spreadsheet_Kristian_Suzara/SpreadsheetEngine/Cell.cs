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
        protected string text;
        protected string value;

        // readonly ints for the column and row index.
        private readonly int columnIndex;
        private readonly int rowIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="column">
        /// int value for the column index.
        /// </param>
        /// <param name="row">
        /// int value for the row index.
        /// </param>
        public Cell(int column, int row)
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
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
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
