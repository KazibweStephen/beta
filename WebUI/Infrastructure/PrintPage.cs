using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;

/// <summary>
/// Summary description for PrintPage
/// </summary>
public class PrintPage
{
    private PrintDocument printDoc = new PrintDocument();
    private PageSettings pgSettings = new PageSettings();
	public PrintPage()
	{
        printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);

	}
    private void printDoc_PrintPage(Object sender, PrintPageEventArgs e)
    {
        string strRecNo = "David";
        Bitmap objBitmap = new Bitmap(1, 1);

        Graphics objGraphics;
        objBitmap = new Bitmap(400, 440);
        objGraphics = Graphics.FromImage(objBitmap);
        objGraphics.Clear(Color.White);
        //objGraphics.Clear(Color.White);
        //Draw the pie and fill
        Pen pen = new Pen(Color.Black, 1);

        //Pen p=new Pen(Color.Yellow,0); 
        //Rectangle rect=new Rectangle(10,10,280,280); 
        //objGraphics.DrawEllipse(p,rect); 
        //Draw font
        FontFamily fontfml = new FontFamily(GenericFontFamilies.Serif);
        Font font = new Font(fontfml, 14);
        SolidBrush brush = new SolidBrush(Color.Blue);

        int xpos, ypos, i, varNoOfRecords = 5;
        double ttmoney = 0, betmoney = 0, setodd = 0;
        string strStake = "5000", strExpReturn = "4000", strSetCode = "400", strMatch = "", strChoice = "", strODD = "", _bet_type, choice;
        DateTime vDate = DateTime.Now;
        xpos = 80;
        ypos = 10;
        e.Graphics.DrawString("GlobalBets EA", font, brush, xpos, ypos);
        ypos += 20;
        xpos = 20;

        e.Graphics.DrawString("P.O.Box nnnnn", font, brush, xpos, ypos);
        xpos = 200;
        e.Graphics.DrawString("Kampala", font, brush, xpos, ypos);
        ypos += 20;
        xpos = 20;
        e.Graphics.DrawString("Customer Id:", font, brush, xpos, ypos);
        xpos = 130;
        e.Graphics.DrawString("David", font, brush, xpos, ypos);
        ypos += 20;
        //Print a line accross
        e.Graphics.DrawLine(pen, 20, ypos, 300, ypos);      //Print a line accross
        xpos = 20;
        e.Graphics.DrawString("Set Number:", font, brush, xpos, ypos);
        xpos += 100;
        e.Graphics.DrawString(strSetCode, font, brush, xpos, ypos);  //where strSetCode is the vaiable with the set code from the database
        xpos += 80;
        e.Graphics.DrawString(strRecNo, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Red, 10, 30);
    }

}
