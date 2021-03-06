﻿using System.Collections.Generic;
using System.Drawing;
using System.Xml;
namespace Quellatalo.Nin.HOCRReader
{
    /// <summary>
    /// Represent a HTML OCR result from Tesseract.
    /// </summary>
    public class HOCR
    {
        private static readonly string RECTANGLE_DATA = "title";
        private string data;
        /// <summary>
        /// Gets pages in the OCR result.
        /// </summary>
        public List<OCRPage> Pages { get; }
        /// <summary>
        /// Gets or sets the HTML OCR data.
        /// </summary>
        public string Data
        {
            get { return data; }
            set
            {
                data = value;
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(data);
                Pages.Clear();
                foreach (XmlNode node in xml.ChildNodes)
                {
                    OCRPage page = new OCRPage(extractRectangle(node.Attributes[RECTANGLE_DATA].Value));
                    foreach (XmlNode node1 in node.ChildNodes)
                    {
                        OCRBlock block = new OCRBlock(extractRectangle(node1.Attributes[RECTANGLE_DATA].Value));
                        foreach (XmlNode node2 in node1.ChildNodes)
                        {
                            OCRPar par = new OCRPar(extractRectangle(node2.Attributes[RECTANGLE_DATA].Value));
                            foreach (XmlNode node3 in node2.ChildNodes)
                            {
                                OCRLine line = new OCRLine(extractRectangle(node3.Attributes[RECTANGLE_DATA].Value));
                                foreach (XmlNode node4 in node3.ChildNodes)
                                {
                                    OCRWord word = new OCRWord(extractRectangle(node4.Attributes[RECTANGLE_DATA].Value), node4.InnerText);
                                    line.Words.Add(word);
                                }
                                par.Lines.Add(line);
                            }
                            block.Pars.Add(par);
                        }
                        page.Blocks.Add(block);
                    }
                    Pages.Add(page);
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of HOCR class.
        /// </summary>
        public HOCR()
        {
            Pages = new List<OCRPage>();
        }
        /// <summary>
        /// Initializes a new instance of HOCR class.
        /// </summary>
        /// <param name="data">The HTML OCR data.</param>
        public HOCR(string data):this()
        {
            Data = data;
        }
        private Rectangle extractRectangle(string str)
        {
            string[] ss = str.Substring(str.IndexOf("bbox") + 5).Split(';')[0].Split(' ');
            int x = int.Parse(ss[0]), y = int.Parse(ss[1]), ex = int.Parse(ss[2]) - x, ey = int.Parse(ss[3]) - y;
            return new Rectangle(x, y, ex, ey);
        }
        /// <summary>
        /// Gets all text lines in the HOCR result.
        /// </summary>
        /// <returns>A list of OCRLine.</returns>
        public List<OCRLine> GetLines()
        {
            List<OCRLine> result = new List<OCRLine>();
            foreach (OCRPage page in Pages)
            {
                result.AddRange(page.GetLines());
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
            foreach (OCRPage page in Pages)
            {
                result.AddRange(page.FindAllText(text, searchOption));
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
            foreach (OCRPage page in Pages)
            {
                result = page.FindText(text, searchOption);
                if (result != null) break;
            }
            return result;
        }
    }
}
