using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Quellatalo.Nin.HOCRReader
{
    public class OCRWord
    {

        /// <summary>
        /// Gets the rectangle of the word.
        /// </summary>
        public Rectangle Rectangle { get; }

        /// <summary>
        /// Gets the text.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Initializes a new instance of OCRWord class.
        /// </summary>
        /// <param name="rectangle">The rectangle of the word.</param>
        /// <param name="text">The Text.</param>
        public OCRWord(Rectangle rectangle, string text)
        {
            Rectangle = rectangle;
            Text = text;
        }
    }
}
