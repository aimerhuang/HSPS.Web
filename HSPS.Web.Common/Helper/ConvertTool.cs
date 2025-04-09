using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Xps.Packaging;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Documents;
using Spire.Pdf;
using O2S.Components.PDFRender4NET;

namespace HSPS.Web.Common.Helper;

/// <summary>
/// 图像处理工具类
/// </summary>
public static class ConvertTool
{
    /// <summary>
    /// 转换文件
    /// 仅在windows系统上支持转换
    /// </summary>
    /// <param name="sourceFile"></param>
    /// <param name="targetFile"></param>
    /// <param name="enumConver"></param>
    public static void ConvertFile(string sourceFile, string targetFile, EnumConver enumConver)
    {
        if (enumConver == EnumConver.Xps2JpegByAspose)
        {
            ConvertPdfToJpeg(sourceFile, targetFile);
        }
        if (enumConver == EnumConver.Pdf2JpegBySpire)
        {
            ConvertPdfToJpegBySpire(sourceFile, targetFile);
        }
        //2.4增加mutool/PDFLibNet/O2S转图方式
        else if (enumConver == EnumConver.Pdf2Png)
        {
            ConvertPdf2ImageByMutool(sourceFile);
        }
        else if (enumConver == EnumConver.Pdf2JpegByPDFLibNet)
        {
            Pdf2JpegPDFLibNet(sourceFile, targetFile);
        }
        else if (enumConver == EnumConver.Pdf2JpegByO2S)
        {
            ConvertPdf2ImageByO2S(sourceFile);
        }
        else if (enumConver == EnumConver.Xps2Jpeg || enumConver == EnumConver.Xps2JpegByAcrobat || enumConver == EnumConver.Xps2JpegByAspose)
        {
            Thread t = new Thread(() =>
            {
                try
                {
                    Convert2Jpeg(sourceFile, targetFile);
                }
                catch (Exception ex)
                {
                    //LogServicesHelper.Error("转换XPS文件时发生了错误:" + ex.Message, ex);
                }
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
        else
        {
            string path = "/FileConvertor/Tools.FileConverter.exe";
            Process convertProcess = new Process();
            convertProcess.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path.TrimStart('/').Replace("/", "\\"));
            convertProcess.StartInfo.Arguments = "\"" + sourceFile + "\" " + "\"" + targetFile + "\" " + "\"" + (int)enumConver + "\" ";
            convertProcess.StartInfo.UseShellExecute = false;
            convertProcess.StartInfo.CreateNoWindow = true;
            convertProcess.StartInfo.RedirectStandardOutput = true;
            convertProcess.StartInfo.RedirectStandardInput = true;

            string outPutStr = string.Empty;
            convertProcess.OutputDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                    outPutStr = e.Data;
            };

            convertProcess.Start();
            convertProcess.BeginOutputReadLine();

            convertProcess.WaitForExit();
            convertProcess.CancelOutputRead();
        }
    }

    public static string[] Convert2Jpeg(string reportFile, string jpegFile)
    {
        var jpegFileInfo = new FileInfo(jpegFile);
        var jpegFileList = new List<string>();

        using (XpsDocument xpsDocument = new XpsDocument(reportFile, FileAccess.Read))
        {
            var documentSequence = xpsDocument.GetFixedDocumentSequence();

            for (int i = 0; i < documentSequence.DocumentPaginator.PageCount; i++)
            {
                //位图编译器
                BitmapEncoder bitmapEncoder = new JpegBitmapEncoder();
                //获取指定页码
                using (DocumentPage documentPage = documentSequence.DocumentPaginator.GetPage(i))
                {
                    
                    //创建目标位图对象
                    RenderTargetBitmap targetBitmap = new RenderTargetBitmap((int)documentPage.Size.Width, (int)documentPage.Size.Height, 96.0, 96.0, PixelFormats.Pbgra32);
                    //建立位图数据
                    targetBitmap.Render(documentPage.Visual);
                    //增加到位图编译器
                    bitmapEncoder.Frames.Add(BitmapFrame.Create(targetBitmap));

                    using (MemoryStream ms = new MemoryStream())
                    {
                        //保存内存流
                        bitmapEncoder.Save(ms);

                        string fileName = string.Format("{0}({1}){2}",
                            jpegFileInfo.Name.Replace(jpegFileInfo.Extension, ""),
                            (i + 1).ToString(),
                            jpegFileInfo.Extension);

                        string currentPageFile = Path.Combine(jpegFileInfo.DirectoryName, fileName);

                        using (Bitmap bitmap = new Bitmap(ms))
                        {
                            bitmap.Save(currentPageFile);
                        }

                        jpegFileList.Add(currentPageFile);
                    }
                }
                bitmapEncoder.Dispatcher.InvokeShutdown();
            }
        }

        return jpegFileList.ToArray();
    }


    public static void ConvertPdfToJpeg(string sourceFile, string targetFile)
    {
        AsposeLicenseHelper.SetPdfLicense();
        //定义Jpeg转换设备
        Aspose.Pdf.Document document = new Aspose.Pdf.Document(sourceFile);
        Aspose.Pdf.Devices.Resolution resolution = new Aspose.Pdf.Devices.Resolution(96);
        var device = new Aspose.Pdf.Devices.JpegDevice(resolution);
        //遍历每一页转为jpg
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();
        for (var i = 1; i <= document.Pages.Count; i++)
        {
            FileStream fs = new FileStream(string.Format("{0}\\{1}({2}){3}", Path.GetDirectoryName(targetFile), Path.GetFileNameWithoutExtension(targetFile), i, Path.GetExtension(targetFile)), FileMode.OpenOrCreate);
            try
            {
                device.Process(document.Pages[i], fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                //LogServicesHelper.Error("pdf转化成jpeg失败", ex);
                fs.Close();
            }

        }
        sw.Stop();
    }

    /// <summary>
    /// 新增PDF转图片组件Spire
    /// </summary>
    /// <param name="sourceFile"></param>
    /// <param name="targetFile"></param>
    public static void ConvertPdfToJpegBySpire(string sourceFile, string targetFile)
    {
        PdfDocument doc = new PdfDocument(sourceFile);
        for (var i = 0; i < doc.Pages.Count; i++)
        {
            var image = doc.SaveAsImage(i, 300, 300);
            var imagePath = string.Format("{0}\\{1}({2}){3}", Path.GetDirectoryName(targetFile), Path.GetFileNameWithoutExtension(targetFile), i + 1, Path.GetExtension(targetFile));
            image.Save(imagePath, ImageFormat.Jpeg);
        }
        doc.Close();
    }

    /// <summary>
    /// 2023-9-15 hkl 增加pdf转png方式
    /// </summary>
    /// <param name="pdfInputPath"></param>
    /// <param name="dpi"></param>
    /// <returns></returns>
    private static List<string> ConvertPdf2ImageByMutool(string pdfInputPath, int dpi = 600)
    {
        List<string> result = new List<string>();
        try
        {
            string pdffile = Path.GetFullPath(pdfInputPath);
            string filedirectory = Path.GetDirectoryName(pdfInputPath);
            string filename = Path.GetFileNameWithoutExtension(pdffile);

            string outPath = Path.Combine(filedirectory, filename) + @"%d.png";
            Process pro = new Process();

            pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pro.StartInfo.Arguments = getArgument("draw") + getArgument("-F") +
                getArgument("png") + getArgument("-r") + getArgument(dpi.ToString()) +
                getArgument("-o") + getArgument(outPath) + getArgument(pdffile);
            pro.StartInfo.FileName = AppSettings.app("WebManage", "mutool");//"D:\\Program Files\\依伴数字\\HSPS\\WebManage\\bin\\mutool.exe";
            pro.Start();
            pro.WaitForExit(1 * 45 * 1000);

            DirectoryInfo folder = new DirectoryInfo(filedirectory);
            foreach (FileInfo file in folder.GetFiles("*.png").OrderByDescending(o => o.CreationTime))
            {
                if (file.Name.Contains(filename))
                {
                    //LogServicesHelper.Warn(string.Concat("文档路径：", Path.Combine(filedirectory, file.Name)));
                    result.Add(Path.Combine(filedirectory, file.Name));
                }
            }
        }
        catch (Exception ex)
        {
            //LogServicesHelper.Error("O2S转换图片异常", ex);
        }
        return result;
    }

    /// <summary>
    /// PDFLibNet 
    /// </summary>
    /// <param name="pdfFile"></param>
    /// <param name="jpegFile"></param>
    /// <param name="DPIX"></param>
    /// <returns></returns>
    private static List<string> Pdf2JpegPDFLibNet(string pdfFile, string jpegFile, int DPIX = 600)
    {
        var jpegFileInfo = new FileInfo(jpegFile);
        var jpegFileList = new List<string>();

        AutoResetEvent parseEvent = new AutoResetEvent(false);

        using (PDFLibNet.PDFWrapper pdfWrapper = new PDFLibNet.PDFWrapper())
        {
            pdfWrapper.LoadPDF(pdfFile);
            for (int i = 1; i <= pdfWrapper.PageCount; i++)
            {
                string fileName = string.Format("{0}({1}){2}",
                    jpegFileInfo.Name.Replace(jpegFileInfo.Extension, ""),
                    i.ToString(),
                    jpegFileInfo.Extension);

                string currentPageFile = Path.Combine(jpegFileInfo.DirectoryName, fileName);

                pdfWrapper.ExportJpg(currentPageFile, i, i, DPIX, 100);
                pdfWrapper.ExportJpgFinished += () => parseEvent.Set();
                parseEvent.Reset();
                parseEvent.WaitOne(1000 * 45);

                if (File.Exists(currentPageFile))
                {
                    jpegFileList.Add(currentPageFile);
                }
                else
                {
                    //LogServicesHelper.Error(string.Format("PDFLib转换图片失败,文件名称{0}，图片名称{1}", pdfFile, jpegFile));
                }
            }
        }
        return jpegFileList;
    }

    /// <summary>
    /// 将PDF文档转换为图片的方法  O2S.Components.PDFRender4NET
    /// </summary>
    /// <param name="pdfInputPath">PDF文件路径</param>
    private static List<string> ConvertPdf2ImageByO2S(string pdfInputPath, int dpi = 600)
    {
        List<string> result = new List<string>();
        try
        {
            PDFFile pdfFile = PDFFile.Open(pdfInputPath);

            // start to convert each page
            for (int i = 1; i <= pdfFile.PageCount; i++)
            {
                Bitmap pageImage = pdfFile.GetPageImage(i - 1, dpi);
                string path = System.IO.Path.GetDirectoryName(pdfInputPath) + @"\" + System.IO.Path.GetFileNameWithoutExtension(pdfInputPath) + "(" + (i - 1).ToString() + ")." + ImageFormat.Jpeg.ToString();
                pageImage.Save(path, ImageFormat.Jpeg);
                result.Add(path);
                pageImage.Dispose();
            }

            pdfFile.Dispose();
        }
        catch (Exception ex)
        {
            //LogServicesHelper.Error("O2S转换图片异常", ex);
        }
        return result;
    }

    private static string getArgument(string arg)
    {
        return " \"" + arg + "\" ";
    }

    /// <summary>
    /// 图片转为base64编码
    /// </summary>
    /// <param name="Imagefilename"></param>
    /// <returns></returns>
    public static string ImgToBase64String(string Imagefilename)
    {
        string strbaser64 = string.Empty;
        try
        {
            Bitmap bmp = new Bitmap(Imagefilename);
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();
            strbaser64 = Convert.ToBase64String(arr);
        }
        catch (Exception ex)
        {
            //LogServicesHelper.Error("ImgToBase64String 转换失败\nException:" + ex.Message);
        }
        return strbaser64;
    }


    public static class AsposeLicenseHelper
    {
        private const string Key = "PExpY2Vuc2U+DQogIDxEYXRhPg0KICAgIDxMaWNlbnNlZFRvPlNoYW5naGFpIEh1ZHVuIEluZm9ybWF0aW9uIFRlY2hub2xvZ3kgQ28uLCBMdGQ8L0xpY2Vuc2VkVG8+DQogICAgPEVtYWlsVG8+MzE3NzAxODA5QHFxLmNvbTwvRW1haWxUbz4NCiAgICA8TGljZW5zZVR5cGU+RGV2ZWxvcGVyIE9FTTwvTGljZW5zZVR5cGU+DQogICAgPExpY2Vuc2VOb3RlPkxpbWl0ZWQgdG8gMSBkZXZlbG9wZXIsIHVubGltaXRlZCBwaHlzaWNhbCBsb2NhdGlvbnM8L0xpY2Vuc2VOb3RlPg0KICAgIDxPcmRlcklEPjE2MDkwMjAwNDQwMDwvT3JkZXJJRD4NCiAgICA8VXNlcklEPjI2NjE2NjwvVXNlcklEPg0KICAgIDxPRU0+VGhpcyBpcyBhIHJlZGlzdHJpYnV0YWJsZSBsaWNlbnNlPC9PRU0+DQogICAgPFByb2R1Y3RzPg0KICAgICAgPFByb2R1Y3Q+QXNwb3NlLlRvdGFsIGZvciAuTkVUPC9Qcm9kdWN0Pg0KICAgIDwvUHJvZHVjdHM+DQogICAgPEVkaXRpb25UeXBlPkVudGVycHJpc2U8L0VkaXRpb25UeXBlPg0KICAgIDxTZXJpYWxOdW1iZXI+NzM4MDNhYmUtYzZkMi00MTY3LTg2MTgtN2I0NDViNDRmOGY0PC9TZXJpYWxOdW1iZXI+DQogICAgPFN1YnNjcmlwdGlvbkV4cGlyeT4yMDE3MDkwNzwvU3Vic2NyaXB0aW9uRXhwaXJ5Pg0KICAgIDxMaWNlbnNlVmVyc2lvbj4zLjA8L0xpY2Vuc2VWZXJzaW9uPg0KICAgIDxMaWNlbnNlSW5zdHJ1Y3Rpb25zPmh0dHA6Ly93d3cuYXNwb3NlLmNvbS9jb3Jwb3JhdGUvcHVyY2hhc2UvbGljZW5zZS1pbnN0cnVjdGlvbnMuYXNweDwvTGljZW5zZUluc3RydWN0aW9ucz4NCiAgPC9EYXRhPg0KICA8U2lnbmF0dXJlPm5LNVVUR3dZMWVJSEtIV0d2NW5sQUxXUy81bDEzWkFuamlvdnlBcGNqQis0ZjNGbm5yOWhjeUlzazlvVzQySWp0ZFYra2JHZlNSMUV4OUozSGlkaThCeE43aHFiR1BERXNaWGo2RlYxaGl1N2MxWmUyNEp3VGc2UnpsNUNJRHY1YVhxbDQyczBkSGw4eXpreDRBM2RTTU5KTzRiQ094a2V2OFBiOWxSaUc3ST08L1NpZ25hdHVyZT4NCjwvTGljZW5zZT4=";
        private static Stream LStream = (Stream)new MemoryStream(Convert.FromBase64String(Key));
        public static void SetPdfLicense()
        {
            var Lic = new Aspose.Pdf.License();
            Lic.SetLicense(LStream);
        }

    }
}
public enum EnumConver
{
    Pdf2Jpeg = 1,
    Xps2Jpeg = 2,
    Pdf2Txt = 3,
    Xps2Txt = 4,
    FilePage = 5,
    Xps2JpegByAcrobat = 6,
    Xps2JpegByAspose = 7,
    Pdf2JpegBySpire = 8,
    Pdf2Png = 9,
    Pdf2JpegByPDFLibNet = 10,
    Pdf2JpegByO2S = 11
}
