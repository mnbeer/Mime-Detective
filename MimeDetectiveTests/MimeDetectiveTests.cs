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

        #region "Test valid files"

        [TestMethod]
        public void BmpTest()
        {
            CoreTest("bmp", @"image/bmp");
        }

        [TestMethod]
        public void GifTest()
        {
            CoreTest("gif", @"image/gif");
        }

        [TestMethod]
        public void JpgTest()
        {
            CoreTest("jpg", @"image/jpeg");
        }

        [TestMethod]
        public void TiffTest()
        {
            CoreTest("tif", @"image/tiff");
        }

        [TestMethod]
        public void ExcelXlsxTest()
        {
            CoreTest("xlsx", @"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [TestMethod]
        public void ExcelXlsTest()
        {
            CoreTest("xls", @"application/excel");
        }

        [TestMethod]
        public void PowerPointPptxTest()
        {
            CoreTest("pptx", @"application/vnd.openxmlformats-officedocument.presentationml.presentation");
        }


        [TestMethod]
        public void PowerPointPptTest()
        {
            CoreTest("ppt", @"application/mspowerpoint");
        }

        [TestMethod]
        public void WordDocxTest()
        {
            CoreTest("docx", @"application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

        [TestMethod]
        public void WordDocTest()
        {
            CoreTest("doc", @"application/msword");
        }

        //[TestMethod]
        //public void MppTest()
        //{
        //    var fileName = @"test.mpp";
        //    var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
        //    var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
        //    Assert.AreEqual("application/vnd.ms-project", mimeType.Mime);
        //}


        [TestMethod]
        public void MsgTest()
        {
            CoreTest("msg", @"application/vnd.ms-outlook");
        }

        [TestMethod]
        public void RtfTest()
        {
            CoreTest("rtf", @"application/rtf");
        }

        [TestMethod]
        public void PdfTest()
        {
            CoreTest("pdf", @"application/pdf");
        }


        [TestMethod]
        public void PngTest()
        {
            CoreTest("png", @"image/png");
        }

        [TestMethod]
        public void WavTest()
        {
            CoreTest("wav", @"audio/wav");
        }

        [TestMethod]
        public void ZipTest()
        {
            CoreTest("zip", @"application/x-compressed");
        }

#endregion

        #region Test bad/invalid files

        [TestMethod]
        public void BadPngTest()
        {
            var fileName = @"Bad\test.pdf.png";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreNotEqual("image/png", mimeType.Mime);
        }

        [TestMethod]
        public void BadPdfTest()
        {
            var fileName = @"Bad\test.png.pdf";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreNotEqual("application/pdf", mimeType.Mime);
        }

        #endregion

        void CoreTest(string extension, string expectedMimeType)
        {
            var fileName = $"test.{extension}";
            var fileInfo = new FileInfo(Path.Combine(_pathToFiles, fileName));
            var mimeType = MimeDetective.MimeTypes.GetFileType(fileInfo);
            Assert.AreEqual(expectedMimeType, mimeType.Mime);
            Assert.IsTrue(mimeType.IsValidExtension(Path.GetExtension(fileName)));
        }

    }
}
