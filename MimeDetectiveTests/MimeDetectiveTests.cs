using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MimeDetectiveTests
{
    [TestClass]
    public class MimeDetectiveTests
    {
        private static string _pathToFiles;

        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            string assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            _pathToFiles = assemblyPath.Substring(0, assemblyPath.LastIndexOf(@"\bin", StringComparison.Ordinal)) + @"\SampleFiles";
        }

        [TestMethod]
        public void BmpTest()
        {
            var fileName = "logo.bmp";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreEqual("image/bmp", mimeType.Mime);
        }

        [TestMethod]
        public void GifTest()
        {
            var fileName = "logo.gif";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreEqual("image/gif", mimeType.Mime);
        }

        [TestMethod]
        public void JpgTest()
        {
            var fileName = "logo.jpg";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreEqual("image/jpeg", mimeType.Mime);
        }

        [TestMethod]
        public void TiffTest()
        {
            var fileName = "logo.tif";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreEqual("image/tiff", mimeType.Mime);
        }

        [TestMethod]
        public void ExcelXlsxTest()
        {
            var fileName = "Sample blank Excel Document.xlsx";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreEqual("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", mimeType.Mime);
        }

        [TestMethod]
        public void ExcelXlsTest()
        {
            var fileName = @"Sample blank Excel 1997-2003 Document.xls";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreEqual("application/excel", mimeType.Mime);
        }

        [TestMethod]
        public void WordDocxTest()
        {
            var fileName = @"Sample blank Word Document.docx";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreEqual("application/vnd.openxmlformats-officedocument.wordprocessingml.document", mimeType.Mime);
        }


        [TestMethod]
        public void WordDocTest()
        {
            var fileName = @"Sample blank Word 1997-2003 Document.doc";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreEqual("application/msword", mimeType.Mime);
        }


        [TestMethod]
        public void PdfTest()
        {
            var fileName = @"ThreePageDummy.pdf";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreEqual("application/pdf", mimeType.Mime);
        }


        [TestMethod]
        public void PngTest()
        {
            var fileName = @"logo.png";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreEqual("image/png", mimeType.Mime);
        }

        [TestMethod]
        public void BadPngTest()
        {
            var fileName = @"Bad\ThreePageDummy.pdf.png";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreNotEqual("image/png", mimeType.Mime);
        }

        [TestMethod]
        public void BadPdfTest()
        {
            var fileName = @"Bad\logo.png.pdf";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreNotEqual("application/pdf", mimeType.Mime);
        }

    }
}
