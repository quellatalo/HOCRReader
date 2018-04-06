using System.Collections.Generic;
using System.Drawing;

namespace Quellatalo.Nin.HOCRReader
{
    public class OCRPar
    {
        public Rectangle Rectangle { get; internal set; }
        public List<OCRLine> Lines { get; internal set; }
        public OCRPar()
        {
            Lines = new List<OCRLine>();
        }
        public List<OCRLine> FindAllText(string text, SearchOptions searchOption = SearchOptions.Containing)
        {
            List<OCRLine> result = new List<OCRLine>();
            switch (searchOption)
            {
                case SearchOptions.Containing:
                    foreach (OCRLine line in Lines)
                    {
                        if (line.Text.Contains(text))
                        {
                            result.Add(line);
                        }
                    }
                    break;
                case SearchOptions.Exact:
                    foreach (OCRLine line in Lines)
                    {
                        if (line.Text == text)
                        {
                            result.Add(line);
                        }
                    }
                    break;
            }
            return result;
        }
        public OCRLine FindText(string text, SearchOptions searchOption = SearchOptions.Containing)
        {
            OCRLine result = null;
            switch (searchOption)
            {
                case SearchOptions.Containing:
                    foreach (OCRLine line in Lines)
                    {
                        if (line.Text.Contains(text))
                        {
                            result = line;
                            break;
                        }
                    }
                    break;
                case SearchOptions.Exact:
                    foreach (OCRLine line in Lines)
                    {
                        if (line.Text == text)
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
