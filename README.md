# HOCRReader

An utility to read Html OCR data from Tesseract.

### Installation

The package is available on Nuget: [Quellatalo.Nin.HOCRReader](https://www.nuget.org/packages/Quellatalo.Nin.HOCRReader)

## Example code
_(Working together with [TheEyes](https://github.com/quellatalo/TheEyes) library)_
```cs
/// <summary>
/// A test to run on windows 8 and later.
/// This code will prepare a tesseract ocr for English,
/// find the lines with the "great" word in them, and highlight those lines as another new image file.
/// Please prepare tesseract, tessdata folder, original image and update the parameters accordingly.
/// </summary>
using Quellatalo.Nin.TheEyes.Imaging;
using Quellatalo.Nin.HOCRReader;
using Emgu.CV;
using Emgu.CV.OCR;
using System.Drawing;
using System.Threading;

void HOCRTest()
{
    Tesseract tesseract = new Tesseract(@"path\to\tessdata", "eng", OcrEngineMode.TesseractLstmCombined)
    {
        PageSegMode = PageSegMode.SparseText
    };
    using (Bitmap img = new Bitmap(@"path\to\OriginalImage.png"))
    using (Graphics g = Graphics.FromImage(img))
    using (Image<Bgr, byte> b = new Image<Bgr, byte>(img))
    {
        tesseract.SetImage(b);
        HOCR hOCR = new HOCR(tesseract.GetHOCRText());
		// find all lines that contain Japanese 'ru' character and highlight them
        List<OCRLine> foundLines = hOCR.FindAllText("great");
        foreach (OCRLine line in foundLines)
        {
            GraphicX.Instance.Highlight(g, line.Rectangle, Pens.Red);
        }
		// save the highlighted work to another file.
        img.Save(@"path\to\HighlightedImageOutput.png");
    }
}
```

License
----

MIT


**It's free. El Psy Congroo!**
