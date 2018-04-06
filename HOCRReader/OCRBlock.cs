using System.Collections.Generic;
using System.Drawing;

namespace Quellatalo.Nin.HOCRReader
{
    public class OCRBlock
    {
        public Rectangle Rectangle { get; internal set; }
        public List<OCRPar> Pars { get; internal set; }
        public OCRBlock()
        {
            Pars = new List<OCRPar>();
        }

        public List<OCRLine> GetLines()
        {
            List<OCRLine> result = new List<OCRLine>();
            foreach (OCRPar par in Pars)
            {
                result.AddRange(par.Lines);
            }
            return result;
        }

        public List<OCRLine> FindAllText(string text, SearchOptions searchOption = SearchOptions.Containing)
        {
            List<OCRLine> result = new List<OCRLine>();
            foreach (OCRPar par in Pars)
            {
                result.AddRange(par.FindAllText(text, searchOption));
            }
            return result;
        }
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
