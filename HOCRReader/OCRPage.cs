using System.Collections.Generic;
using System.Drawing;

namespace Quellatalo.Nin.HOCRReader
{
    public class OCRPage
    {
        public Rectangle Rectangle { get; internal set; }
        public List<OCRBlock> Blocks { get; internal set; }
        public OCRPage()
        {
            Blocks = new List<OCRBlock>();
        }
        public List<OCRLine> GetLines()
        {
            List<OCRLine> result = new List<OCRLine>();
            foreach (OCRBlock block in Blocks)
            {
                result.AddRange(block.GetLines());
            }
            return result;
        }
        public List<OCRLine> FindAllText(string text, SearchOptions searchOption = SearchOptions.Containing)
        {
            List<OCRLine> result = new List<OCRLine>();
            foreach (OCRBlock block in Blocks)
            {
                result.AddRange(block.FindAllText(text, searchOption));
            }
            return result;
        }
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
