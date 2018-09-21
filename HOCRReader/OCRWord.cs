using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Quellatalo.Nin.HOCRReader
{
    public class OCRWord
    {
        private readonly Rectangle rectangle;
        private readonly string text;

        /// <summary>
        /// Gets the rectangle of the word.
        /// </summary>
        public Rectangle Rectangle => rectangle;
        
        /// <summary>
        /// Gets the text.
        /// </summary>
        public string Text => text;

        /// <summary>
        /// Initializes a new instance of OCRWord class.
        /// </summary>
        /// <param name="rectangle">The rectangle of the word.</param>
        /// <param name="text">The Text.</param>
        public OCRWord(Rectangle rectangle, string text)
        {
            this.rectangle = rectangle;
            this.text = text;
        }
    }
}
