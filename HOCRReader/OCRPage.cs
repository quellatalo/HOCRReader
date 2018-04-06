﻿using System.Collections.Generic;
using System.Drawing;

namespace Quellatalo.Nin.HOCRReader
{
    /// <summary>
    /// Represent a HTML OCR page result from Tesseract.
    /// </summary>
    public class OCRPage
    {
        /// <summary>
        /// Gets the rectangle of the page.
        /// </summary>
        public Rectangle Rectangle { get; internal set; }
        /// <summary>
        /// Gets the OCR blocks result in the page.
        /// </summary>
        public List<OCRBlock> Blocks { get; internal set; }
        /// <summary>
        /// Initializes a new instance of OCRPage class.
        /// </summary>
        public OCRPage()
        {
            Blocks = new List<OCRBlock>();
        }
        /// <summary>
        /// Gets all text lines in the page.
        /// </summary>
        /// <returns>A list of OCRLine.</returns>
        public List<OCRLine> GetLines()
        {
            List<OCRLine> result = new List<OCRLine>();
            foreach (OCRBlock block in Blocks)
            {
                result.AddRange(block.GetLines());
            }
            return result;
        }
        /// <summary>
        /// Find all lines which contains/match a specified text.
        /// </summary>
        /// <param name="text">The text to find.</param>
        /// <param name="searchOption">Whether the line contains the text, or match the text.</param>
        /// <returns>A list of OCRLine.</returns>
        public List<OCRLine> FindAllText(string text, SearchOptions searchOption = SearchOptions.Containing)
        {
            List<OCRLine> result = new List<OCRLine>();
            foreach (OCRBlock block in Blocks)
            {
                result.AddRange(block.FindAllText(text, searchOption));
            }
            return result;
        }
        /// <summary>
        /// Find the first line which contains/match a specified text.
        /// </summary>
        /// <param name="text">The text to find.</param>
        /// <param name="searchOption">Whether the line contains the text, or match the text.</param>
        /// <returns>An instance of OCRLine.</returns>
        public OCRLine FindText(string text, SearchOptions searchOption = SearchOptions.Containing)
        {
            OCRLine result = null;
            foreach (OCRBlock block in Blocks)
            {
                result = block.FindText(text, searchOption);
                if (result != null) break;
            }
            return result;
        }
    }
}
