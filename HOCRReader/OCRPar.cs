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
        private readonly Rectangle rectangle;
        private readonly List<OCRLine> lines;
        /// <summary>
        /// Gets the rectangle of the paragraph.
        /// </summary>
        public Rectangle Rectangle => rectangle;
        /// <summary>
        /// Gets all text lines in the paragraph.
        /// </summary>
        public List<OCRLine> Lines => lines;
        /// <summary>
        /// Initializes a new instance of OCRPar class.
        /// </summary>
        /// <param name="rectangle">The rectangle of the paragraph.</param>
        public OCRPar(Rectangle rectangle) : this(rectangle, new List<OCRLine>()) { }
        /// <summary>
        /// Initializes a new instance of OCRPar class.
        /// </summary>
        /// <param name="rectangle">The rectangle of the paragraph.</param>
        /// <param name="lines">The lines in the paragraph.</param>
        public OCRPar(Rectangle rectangle, List<OCRLine> lines)
        {
            this.rectangle = rectangle;
            this.lines = lines;
        }
        /// <summary>
        /// Find all lines which contains/match a specified text.
        /// </summary>
        /// <param name="text">The text to find.</param>
        /// <param name="searchOption">Whether the line contains the text, or match the text.</param>
        /// <returns>A list of OCRLine.</returns>
        public List<OCRLine> FindAllText(string text, SearchOptions searchOption = SearchOptions.Containing)
        {
            string trip;
            Regex regex;
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
                    trip = text.Replace(" ", "");
                    foreach (OCRLine line in Lines)
                    {
                        if (line.GetNoSpacesText() == trip)
                        {
                            result.Add(line);
                        }
                    }
                    break;
                case SearchOptions.Containing_Spaces_Ignored:
                    trip = text.Replace(" ", "");
                    foreach (OCRLine line in Lines)
                    {
                        if (line.GetNoSpacesText().Contains(trip))
                        {
                            result.Add(line);
                        }
                    }
                    break;
                case SearchOptions.Regex:
                    regex = new Regex(text);
                    foreach (OCRLine line in Lines)
                    {
                        if (regex.IsMatch(line.GetText()))
                        {
                            result.Add(line);
                        }
                    }
                    break;
                case SearchOptions.Regex_Spaces_Ignored:
                    regex = new Regex(text);
                    foreach (OCRLine line in Lines)
                    {
                        if (regex.IsMatch(line.GetNoSpacesText()))
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
            string trip;
            OCRLine result = null;
            Regex regex;
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
                    trip = text.Replace(" ", "");
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
                    trip = text.Replace(" ", "");
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
                    regex = new Regex(text);
                    foreach (OCRLine line in Lines)
                    {
                        if (regex.IsMatch(line.GetText()))
                        {
                            result = line;
                            break;
                        }
                    }
                    break;
                case SearchOptions.Regex_Spaces_Ignored:
                    regex = new Regex(text);
                    foreach (OCRLine line in Lines)
                    {
                        if (regex.IsMatch(line.GetNoSpacesText()))
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
