﻿using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#if GDI
using System.Drawing;
using System.Drawing.Imaging;
#endif
#if WPF
using System.Windows;
using System.Windows.Media;
#endif
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UnitTests.Helpers;

namespace PdfSharp.UnitTests.Text
{
  /// <summary>
  /// 
  /// </summary>
  [TestClass]
  public class TextStyles1 : TestBase
  {
    /// <summary>
    /// Gets or sets the test context which provides information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext { get; set; }

    [TestInitialize]
    public void TestInitialize()
    {
      BeginPdf();
      BeginImage();
    }

    [TestCleanup]
    public void TestCleanup()
    {
      EndPdf();
      EndImage();
    }

    [TestMethod]
    // ReSharper disable InconsistentNaming
    public void TestTextStyles1_Times_New_Roman_not_embedded()
    // ReSharper restore InconsistentNaming
    {
      Render("TextStyles1_Times_New_Roman_not_embedded", RenderTextStyles);
    }

    static void RenderTextStyles(XGraphics gfx)
    {
      gfx.TranslateTransform(15, 20);

      const string facename = "Times New Roman";
      XFont fontRegular = new XFont(facename, 20);
      XFont fontBold = new XFont(facename, 20, XFontStyle.Bold);
      XFont fontItalic = new XFont(facename, 20, XFontStyle.Italic);
      XFont fontBoldItalic = new XFont(facename, 20, XFontStyle.BoldItalic);

      // The default alignment is baseline left (that differs from GDI+)
      gfx.DrawString(facename + " (regular)", fontRegular, XBrushes.DarkSlateGray, 0, 30);
      gfx.DrawString(facename + " (bold)", fontBold, XBrushes.DarkSlateGray, 0, 65);
      gfx.DrawString(facename + " (italic)", fontItalic, XBrushes.DarkSlateGray, 0, 100);
      gfx.DrawString(facename + " (bold italic)", fontBoldItalic, XBrushes.DarkSlateGray, 0, 135);
    }
  }
}