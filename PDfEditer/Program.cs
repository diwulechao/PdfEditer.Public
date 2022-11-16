using Spire.Pdf;
using Spire.Pdf.General.Find;
using Spire.Pdf.Graphics;
using System;
using System.IO;

namespace PDfEditer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("path to folder:");
            var path = Console.ReadLine();
            PdfDocument mergedDoc = new PdfDocument();

            var files = Directory.GetFiles(path);
            foreach(var file in files)
            {
                if (file.Contains(".pdf"))
                {
                    convert(file, mergedDoc);
                    Console.WriteLine(file + " processed.");
                }
            }

            Console.WriteLine("done.");
            var mergedPath = path + (path.EndsWith("\\") ? "final-merged.pdf" : "\\final-merged.pdf");
            mergedDoc.SaveToFile(mergedPath);
            Console.WriteLine("Merged file saved to: " + mergedPath);
        }

        private static void convert(string path, PdfDocument mergedDoc)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(path);

            foreach (PdfPageBase page in doc.Pages)
            {
                var result = page.FindText("Hello John Snow,", false, false).Finds;
                foreach (PdfTextFind find in result)
                {
                    var rec = find.Bounds;
                    rec.Y -= 3;
                    rec.Width *= 1.5f;
                    rec.Height *= 1.5f;
                    String newText = "Hello White king,";
                    PdfBrush brush = new PdfSolidBrush(System.Drawing.Color.FromArgb(80, 79, 161));
                    PdfTrueTypeFont font = new PdfTrueTypeFont("arial.ttf", 20f);

                    page.Canvas.DrawRectangle(PdfBrushes.White, rec);
                    page.Canvas.DrawString(newText, font, brush, rec);
                }

                result = page.FindText("JOHN SNOW", false, false).Finds;
                foreach (PdfTextFind find in result)
                {
                    var rec = find.Bounds;
                    rec.Y -= 1;
                    rec.Width *= 1.2f;
                    rec.Height *= 1.2f;
                    String newText = "WHITE KING";
                    PdfBrush brush = new PdfSolidBrush(System.Drawing.Color.Black);
                    PdfTrueTypeFont font = new PdfTrueTypeFont("arialbd.ttf", 7.8f);

                    page.Canvas.DrawRectangle(PdfBrushes.White, rec);
                    page.Canvas.DrawString(newText, font, brush, rec);
                }
            }

            doc.SaveToFile(path.Replace(".pdf","-final.pdf"), Spire.Pdf.FileFormat.PDF);
            mergedDoc.InsertPage(doc, 0);
        }
    }
}
