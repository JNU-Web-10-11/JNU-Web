﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing.Design;
using System.Drawing;
public partial class ValiCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.CreateCheckCodeImage(RndNum());

    }

    private string RndNum()
    {
        int number;
        char code;
        string ValiCode = String.Empty;

        System.Random random = new Random();

        for (int i = 0; i < 4; i++)
        {
            number = random.Next();
            if (number % 2 == 0)
                code = (char)('0' + (char)(number % 10));
            else
                code = (char)('a' + (char)(number % 26));
            ValiCode += code.ToString();
        }
        Response.Cookies.Add(new HttpCookie("ValiCode", ValiCode));
        return ValiCode;
    }
    private void CreateCheckCodeImage(string valiCode)
    {
        if (valiCode == null || valiCode.Trim() == String.Empty)
            return;
        Bitmap image = new Bitmap((int)Math.Ceiling((valiCode.Length * 15.5)),25);
        Graphics g = Graphics.FromImage(image);
        try
        {
            //生成随机生成器 
            Random random = new Random();
            //清空图片背景色 
            g.Clear(Color.White);
            //画图片的背景噪音线 
            for (int i = 0; i < 25; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
            g.DrawString(valiCode, font, brush, 2, 2);
            //画图片的前景噪音点 
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            //画图片的边框线 
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "image/Gif";
            Response.BinaryWrite(ms.ToArray());
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }
    }

}