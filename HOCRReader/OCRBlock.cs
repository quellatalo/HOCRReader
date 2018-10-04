using System.Collections.Generic;
using System.Drawing;

namespace Quellatalo.Nin.HOCRReader
{
    /// <summary>
    /// Represent a HTML OCR block result from Tesseract.
    /// </summary>
    public class OCRBlock
    {
        /// <summary>
        /// Gets the rectangle of the block.
        /// </summary>
        public Rectangle Rectangle { get; }
        /// <summary>
        /// Gets the paragraphs in the block.
        /// </summary>
        public List<OCRPar> Pars { get; }
        /// <summary>
        /// Initializes a new instance of OCRBlock class.
        /// </summary>
        /// <param name="rectangle">The rectangle of the block.</param>
        public OCRBlock(Rectangle rectangle) : this(rectangle, new List<OCRPar>()) { }
        /// <summary>
        /// Initializes a new instance of OCRBlock class.
        /// </summary>
        /// <param name="rectangle">The rectangle of the block.</param>
        /// <param name="pars">The paragraphs in the block.</param>
        public OCRBlock(Rectangle rectangle, List<OCRPar> pars)
        {
            Rectangle = rectangle;
            Pars = new List<OCRPar>();
        }
        /// <summary>
        /// Gets all text lines in the block.
        /// </summary>
        /// <returns>A list of OCRLine.</returns>
        public List<OCRLine> GetLines()
        {
            List<OCRLine> result = new List<OCRLine>();
            foreach (OCRPar par in Pars)
            {
                result.AddRange(par.Lines);
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
            foreach (OCRPar par in Pars)
            {
                result.AddRange(par.FindAllText(text, searchOption));
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
            foreach (OCRPar par in Pars)
            {
                result = par.FindText(text, searchOption);
                if (result != null) break;
            }
            return result;
        }
    }
}
