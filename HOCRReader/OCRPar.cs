using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Quellatalo.Nin.HOCRReader
{
    /// <summary>
    /// Represent a HTML OCR paragraph result from Tesseract.
    /// </summary>
    public class OCRPar
    {
        /// <summary>
        /// Gets the rectangle of the paragraph.
        /// </summary>
        public Rectangle Rectangle { get; internal set; }
        /// <summary>
        /// Gets all text lines in the paragraph.
        /// </summary>
        public List<OCRLine> Lines { get; internal set; }
        /// <summary>
        /// Initializes a new instance of OCRPar class.
        /// </summary>
        public OCRPar()
        {
            Lines = new List<OCRLine>();
        }
        /// <summary>
        /// Find all lines which contains/match a specified text.
        /// </summary>
        /// <param name="text">The text to find.</param>
        /// <param name="searchOption">Whether the line contains the text, or match the text.</param>
        /// <returns>A list of OCRLine.</returns>
        public List<OCRLine> FindAllText(string text, SearchOptions searchOption = SearchOptions.Containing)
        {
            string trip = text.Replace(" ", "");
            List<OCRLine> result = new List<OCRLine>();
            switch (searchOption)
            {
                case SearchOptions.Containing:
                    foreach (OCRLine line in Lines)
                    {
                        if (line.FindWord(text, searchOption) != null)
                        {
                            result.Add(line);
                        }
                    }
                    break;
                case SearchOptions.Exact:
                    foreach (OCRLine line in Lines)
                    {
                        if (line.GetText() == text)
                        {
                            result.Add(line);
                        }
                    }
                    break;
                case SearchOptions.Spaces_Ignored:
                    foreach (OCRLine line in Lines)
                    {
                        if (line.GetNoSpacesText() == trip)
                        {
                            result.Add(line);
                        }
                    }
                    break;
                case SearchOptions.Containing_Spaces_Ignored:
                    foreach (OCRLine line in Lines)
                    {
                        if (line.GetNoSpacesText().Contains(trip))
                        {
                            result.Add(line);
                        }
                    }
                    break;
                case SearchOptions.Regex:
                    Regex regex = new Regex(text);
                    foreach (OCRLine line in Lines)
                    {
                        if (regex.IsMatch(line.GetText()))
                        {
                            result.Add(line);
                        }
                    }
                    break;
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
            string trip = text.Replace(" ", "");
            OCRLine result = null;
            switch (searchOption)
            {
                case SearchOptions.Containing:
                    foreach (OCRLine line in Lines)
                    {
                        if (line.FindWord(text, searchOption) != null)
                        {
                            result = line;
                            break;
                        }
                    }
                    break;
                case SearchOptions.Exact:
                    foreach (OCRLine line in Lines)
                    {
                        if (line.GetText() == text)
                        {
                            result = line;
                            break;
                        }
                    }
                    break;
                case SearchOptions.Spaces_Ignored:
                    foreach (OCRLine line in Lines)
                    {
                        if (line.GetNoSpacesText() == trip)
                        {
                            result = line;
                            break;
                        }
                    }
                    break;
                case SearchOptions.Containing_Spaces_Ignored:
                    foreach (OCRLine line in Lines)
                    {
                        if (line.GetNoSpacesText().Contains(trip))
                        {
                            result = line;
                            break;
                        }
                    }
                    break;
                case SearchOptions.Regex:
                    Regex regex = new Regex(text);
                    foreach (OCRLine line in Lines)
                    {
                        if (regex.IsMatch(line.GetText()))
                        {
                            result = line;
                            break;
                        }
                    }
                    break;
            }
            return result;
        }
    }
}
