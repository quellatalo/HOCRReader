using System.Drawing;

namespace Quellatalo.Nin.HOCRReader
{
    /// <summary>
    /// Represent a HTML OCR line result from Tesseract.
    /// </summary>
    public class OCRLine
    {
        /// <summary>
        /// Gets the rectangle of the line.
        /// </summary>
        public Rectangle Rectangle { get; internal set; }
        /// <summary>
        /// Gets the text in the line.
        /// </summary>
        public string Text { get; internal set; }
    }
}
