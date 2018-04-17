using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Quellatalo.Nin.HOCRReader
{
    /// <summary>
    /// Represent a HTML OCR line result from Tesseract.
    /// </summary>
    public class OCRLine
    {
        /// <summary>
        /// Gets the rectangle of the paragraph.
        /// </summary>
        public Rectangle Rectangle { get; internal set; }
        /// <summary>
        /// Gets all text lines in the paragraph.
        /// </summary>
        public List<OCRWord> Words { get; internal set; }
        /// <summary>
        /// Initializes a new instance of OCRPar class.
        /// </summary>
        public OCRLine()
        {
            Words = new List<OCRWord>();
        }
        /// <summary>
        /// Gets the text in the line.
        /// </summary>
        [Obsolete("Text property is deprecated, please use GetText method instead.")]
        public string Text
        {
            get
            {
                return GetText();
            }
        }
        /// <summary>
        /// Gets the text in the line.
        /// </summary>
        public string GetText()
        {
            string rs = "";
            int i = 0;
            for (; i < Words.Count - 1; i++)
            {
                rs += Words[i].Text + " ";
            }
            if (Words.Count > 0) rs += Words[i].Text;
            return rs;
        }
        /// <summary>
        /// Find all lines which contains/match a specified text.
        /// </summary>
        /// <param name="text">The text to find.</param>
        /// <param name="searchOption">Whether the line contains the text, or match the text.</param>
        /// <returns>A list of OCRLine.</returns>
        public List<OCRWord> FindAllText(string text, SearchOptions searchOption = SearchOptions.Containing)
        {
            List<OCRWord> result = new List<OCRWord>();
            switch (searchOption)
            {
                case SearchOptions.Containing:
                    foreach (OCRWord word in Words)
                    {
                        if (word.Text.Contains(text))
                        {
                            result.Add(word);
                        }
                    }
                    break;
                case SearchOptions.Exact:
                    foreach (OCRWord word in Words)
                    {
                        if (word.Text == text)
                        {
                            result.Add(word);
                        }
                    }
                    break;
                case SearchOptions.Containing_Spaces_Ignored:
                    string trip = text.Replace(" ","");
                    foreach (OCRWord word in Words)
                    {
                        if (word.Text.Replace(" ", "").Contains(trip))
                        {
                            result.Add(word);
                        }
                    }
                    break;
                case SearchOptions.Regex:
                    Regex regex = new Regex(text);
                    foreach (OCRWord word in Words)
                    {
                        if (regex.IsMatch(word.Text))
                        {
                            result.Add(word);
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
        public OCRWord FindText(string text, SearchOptions searchOption = SearchOptions.Containing)
        {
            OCRWord result = null;
            switch (searchOption)
            {
                case SearchOptions.Containing:
                    foreach (OCRWord word in Words)
                    {
                        if (word.Text.Contains(text))
                        {
                            result = word;
                            break;
                        }
                    }
                    break;
                case SearchOptions.Exact:
                    foreach (OCRWord word in Words)
                    {
                        if (word.Text == text)
                        {
                            result = word;
                            break;
                        }
                    }
                    break;
                case SearchOptions.Containing_Spaces_Ignored:
                    string trip = text.Replace(" ", "");
                    foreach (OCRWord word in Words)
                    {
                        if (word.Text.Replace(" ", "").Contains(trip))
                        {
                            result = word;
                            break;
                        }
                    }
                    break;
                case SearchOptions.Regex:
                    Regex regex = new Regex(text);
                    foreach (OCRWord word in Words)
                    {
                        if (regex.IsMatch(word.Text))
                        {
                            result = word;
                            break;
                        }
                    }
                    break;
            }
            return result;
        }
    }
}
