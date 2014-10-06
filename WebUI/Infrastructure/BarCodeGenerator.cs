using System;
using System.Drawing;

public class BarCodeGenerator
{
	public BarCodeGenerator()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public String GenerateRandomString(int stringLength)
    {
        Random random = new Random((int)DateTime.Now.Ticks);
        String randomString = String.Empty;
        for (int i = 0; i < stringLength; i++)
        {
            int num = random.Next();
            randomString += num.ToString();
        }
        return randomString.Substring(0, stringLength);
    }

    public Bitmap CreateBarCode(String data)
    {
        string barcodeData = "*" + data + "*";
        Bitmap barcode = new Bitmap(1, 1);

        Font threeOfNine = new Font("Free 3 of 9 Extended",60, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        Graphics graphics = Graphics.FromImage(barcode);
        SizeF dataSize = graphics.MeasureString(data, threeOfNine);
        barcode = new Bitmap(barcode, dataSize.ToSize());
       // barcode.SetResolution(50, 50);
        graphics = Graphics.FromImage(barcode);
        graphics.Clear(Color.White);
        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
        graphics.DrawString(data, threeOfNine, new SolidBrush(Color.Black), 0, 0);
        graphics.Flush();
        threeOfNine.Dispose();
        graphics.Dispose();
        return barcode;
    }
}
