// <copyright file="SpreadsheetTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NUnit.SpreadsheetTests
{
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;

    /// <summary>
    /// Class with tests for the spreadsheet.
    /// </summary>
    [TestFixture]
    public class SpreadsheetTests
    {
        /// <summary>
        /// Test the creation of a spreadsheet and if the size matches the inputs.
        /// </summary>
        [Test]
        public void TestSpreadsheetSize()
        {
            Spreadsheet testSpreadSheet = new Spreadsheet(20, 5);

            // Test if the amount of rows is correct.
            Assert.AreEqual(
                20,
                testSpreadSheet.RowCount);

            // Test if the number of columns is correct.
            Assert.AreEqual(
                5,
                testSpreadSheet.ColumnCount);
        }
    }
}
