using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Quellatalo.Nin.HOCRReader
{
    public class OCRWord
    {
        /// <summary>
        /// Gets the rectangle of the line.
        /// </summary>
        public Rectangle Rectangle { get; internal set; }
        /// <summary>
        /// Gets the text.
        /// </summary>
        public string Text { get; internal set; }
    }
}
