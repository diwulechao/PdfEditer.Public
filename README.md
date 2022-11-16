# PdfEditer.Public
Summary
1. Find the matching text and replace with new text.
2. Align the new text with the old one. Most online pdf editer tools will not get the perpect alignment. You will have to play with the rec code a little to get the perfect alignment.
3. Merge all the pdf files's first page into one single pdf file.

I'm so sick of the 100$ annual fee bulls*t. And made this tool to fit my requirements. And it works much better.
I can use whatever font, size and color I want to match the old text. And with 
```
   var rec = find.Bounds;
   rec.Y -= 3;
   rec.Width *= 1.5f;
   rec.Height *= 1.5f;
```
You can move and adjust the text window to get the perfect alignment.
This code is just a demo. You need to have some basic coding skill to be alter this tool to fit your requirements.

Big thanks to Spire.PDF nuget package to make this possible.
