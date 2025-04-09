using HSPS.Web.Model.Models.Extensions;
using HSPS.Web.Model.Models;
using YiBan.FileTransfer.Client;
using HSPS.Web.Model;
using System.Text.RegularExpressions;

namespace HSPS.Web.Common.Helper;

/// <summary>
/// 报告文件处理
/// </summary>
public static class ReportFileHelper
{
   

    static FileTransferClient _client = new FileTransferClient(AppSettings.app("WebManage", "FileServerHost"), AppSettings.app("WebManage", "FileServerPort").ObjToInt());
    //static ReportFileHelper()
    //{
    //    _client = new FileTransferClient(AppSettings.app("WebManage", "FileServerHost"), AppSettings.app("WebManage", "FileServerPort").ObjToInt());
    //}

    /// <summary>
    /// 获取报告/胶片的图片文件（ ReportId ，ServerPath，Url ，Height，Width ）
    /// </summary>
    /// <param name="rc"></param>
    /// <returns></returns>
    public static List<object> GetReportImage(Report rc, bool isOverride, bool isBmp = false, bool isSmallImg = false)
    {

        List<object> result = new List<object>();

        string servicePath = rc.ReportPath;//服务端文件路径

        string[] files = GetReportFiles(rc);

        //判断报告文件是否存在
        if (files == null || files.Length == 0)
        {
            return result;
        }

        //相对路径
        string oppositePath = Path.Combine(AppSettings.app("WebManage", "FileServerHost"), DateTime.Parse(rc.ReceiveTime).ToString("yyyy-MM-dd"), rc.ID);
        //绝对路径
        string localPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, oppositePath.TrimStart('/').Replace("/", "\\"));

        if (!Directory.Exists(localPath))
            Directory.CreateDirectory(localPath);

        if (rc.ParseRuleType == FileTypeEnum.Report)//报告预览图片直接下载源文件再转换成jpeg图片
        {
            result = GetReportImage(servicePath, oppositePath, localPath, files, rc);
        }
        else//胶片预览图片直接从文件服务器上下载转换后的图片
        {
            result = GetFilmImage(servicePath, oppositePath, localPath, files, rc, isOverride, isBmp, isSmallImg);
        }

        return result;
    }

    /// <summary>
    /// 获取报告预览的文件信息
    /// </summary>
    /// <param name="servicePath"></param>
    /// <param name="oppositePath"></param>
    /// <param name="localPath"></param>
    /// <param name="files"></param>
    /// <param name="rc"></param>
    /// <returns></returns>
    public static List<object> GetReportImage(string servicePath, string oppositePath, string localPath, string[] files, Report rc)
    {
        List<object> result = new List<object>();
        ReportFile reportFile = GetReportSourceFile(files, rc.FileExtType);

        if (reportFile == null)
        {
            //LogServicesHelper.Warn(string.Format("未找到后缀为{0}的报告源文件", rc.FileExtType));
            return result;
        }

        if (!Directory.Exists(localPath))
        {
            Directory.CreateDirectory(localPath);
        }

        string fileFullName = string.Empty;

        string oppositeFullName = Path.Combine(oppositePath.TrimStart('/').Replace("/", "\\"), string.Format("report_{0}", rc.ID));

        if (rc.FileExtType == FileExtTypeEnum.Pdf)
        {
            oppositeFullName += ".pdf";
        }
        else if (rc.FileExtType == FileExtTypeEnum.Xps)
        {
            oppositeFullName += ".xps";
        }

        fileFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, oppositeFullName);

        servicePath = Path.Combine(servicePath, reportFile.FileName);

        //已经转换过后，就无需转换了
        bool isExist = IsExistImage(fileFullName);
        if (!isExist)
        {
            try
            {
                //下载报告的原始文件
                GetFile(servicePath, fileFullName);

                //文件转换
                ConvertToFile(oppositeFullName, rc.FileExtType, FileExtTypeEnum.Jpeg);
            }
            catch (Exception ex)
            {
                //LogServicesHelper.Error("文件下载或转换失败", ex);
            }
        }

        //获取转换后的图片信息（路径、大小等等）
        result = GetImageInfo(rc, fileFullName, oppositePath);


        return result;
    }

    /// <summary>
    /// 获取胶片预览的文件信息
    /// </summary>
    /// <param name="servicePath"></param>
    /// <param name="oppositePath"></param>
    /// <param name="localPath"></param>
    /// <param name="files"></param>
    /// <param name="rc"></param>
    /// <returns></returns>
    public static List<object> GetFilmImage(string servicePath, string oppositePath, string localPath, string[] files, Report rc, bool isOverride, bool isBmp = false, bool isSmallImg = false)
    {
        List<object> result = new List<object>();
        List<ReportFile> rfList = SortFileNames(files, isBmp, isSmallImg);
        if (rfList.Count == 0)
        {
            //LogServicesHelper.Warn(string.Format("ID为{0}的胶片文件在文件服务器上不存在，文件路径：{1}", rc.ID, servicePath));
        }
        //文件下载
        for (int i = 0; i < rfList.Count; i++)
        {
            servicePath = Path.Combine(rc.ReportPath, rfList[i].FileName);
            string fileName = string.Format("report_{0}_{1}.{2}", rc.ID, i, rfList[i].FileName.Split('.')[1]);
            string localPathName = Path.Combine(localPath, fileName);
            string oppositePathName = Path.Combine(oppositePath, fileName).Replace(@"\", "/");

            bool isExist = File.Exists(localPathName);

            if (isExist)
            {
                if (isOverride)
                {
                    try
                    {
                        File.Delete(localPathName);
                    }
                    catch (Exception ex)
                    {
                        //LogServicesHelper.Error(string.Format("删除报告文件失败，路径：{0}", localPathName), ex);
                    }
                    GetFile(servicePath, localPathName);
                }
            }
            else
            {
                GetFile(servicePath, localPathName);
            }


            //获取图片文件的高度和宽度
            System.Drawing.Size size = FileHelper.GetImageSize(localPathName);
            var imageInfo = new
            {
                ReportId = rc.ID,
                ReportContextId = rc.ReportID.ToString(),
                ServerPath = rc.ReportPath,
                Url = oppositePathName,
                Height = size.Height.ToString(),
                Width = size.Width.ToString()

            };
            result.Add(imageInfo);
        }
        return result;
    }


    /// <summary>
    /// 下载文件
    /// </summary>
    /// <param name="serverFileName">服务器文件名</param>
    /// <param name="localFilePath">本地存放路径，包含文件名</param>
    public static void GetFile(string serverFileName, string localFilePath)
    {
        //var client = new FileTransferClient(AppSettings.app("WebManage", "FileServerHost"), AppSettings.app("WebManage", "FileServerPort").ObjToInt());
        _client.GetFile(serverFileName, localFilePath);//_client
    }

    /// <summary>
    /// 异步下载文件
    /// </summary>
    /// <param name="path"></param>
    /// <param name="fileName"></param>
    public static void AsyncGetFile(string path, string fileName)
    {
        string localFile = Path.Combine(path, fileName);
        var client = new FileTransferClient(AppSettings.app("WebManage", "FileServerHost"), AppSettings.app("WebManage", "FileServerPort").ObjToInt());
        //_client
        client.BeginGetFile(fileName, localFile, (ar) =>
        {
            //上传完毕时执行此回调
            try
            {
                client.EndGetFile(ar);
            }
            catch (Exception ex)
            {
                //处理异常
                //LogServicesHelper.Error("异步下载文件出错", ex);
            }
        });
    }

    /// <summary>
    /// 获取报告的文件
    /// </summary>
    /// <param name="rc"></param>
    /// <returns></returns>
    public static string[] GetReportFiles(Report rc)
    {
        string serverFilePath = rc.ReportPath;

        if (string.IsNullOrEmpty(serverFilePath))
        {
            //LogServicesHelper.Warn(string.Format("ID为{0}的报告/胶片文件文件路径不存在", rc.ID));
            return null;
        }

        string[] files = GetFilesName(serverFilePath);

        if (files == null || files.Length == 0)
        {
            //LogServicesHelper.Warn(string.Format("ID为{0}的报告/胶片文件在文件服务器上不存在，文件路径：{1}", rc.ID, rc.ReportPath));
            return null;
        }

        return files;
    }

    /// <summary>
    /// 获取服务器指文路径下所有文件名
    /// </summary>
    /// <param name="path"></param>
    public static string[] GetFilesName(string path)
    {
        try
        {
            //_client = new FileTransferClient(AppSettings.app("WebManage", "FileServerHost"), AppSettings.app("WebManage", "FileServerPort").ObjToInt());
            string[] fileNames = _client.GetFilesName(path);
            return fileNames;
        }
        catch (Exception ex)
        {
            //LogServicesHelper.Error("获取服务器指文路径下所有文件名", ex);
        }
        return null;
    }

    /// <summary>
    /// 获取报告原始文件名（优先PDF，然后XPS）
    /// </summary>
    /// <param name="files"></param>
    /// <returns></returns>
    private static ReportFile GetReportSourceFile(string[] files, FileExtTypeEnum fileType)
    {
        ReportFile reportFile = null;
        for (int i = 0; i < files.Length; i++)
        {
            string ext = Path.GetExtension(files[i]);
            string sourceExt = Constant.DEFAULT_REPORT_PDF_EXTENSION;
            if (fileType == FileExtTypeEnum.Xps)
                sourceExt = Constant.DEFAULT_REPORT_XPS_EXTENSION;
            if (ext.ToLower().Equals(sourceExt))
            {
                reportFile = new ReportFile();
                reportFile.FileName = files[i];
                reportFile.FileExtType = fileType;
                return reportFile;
            }
        }
        return reportFile;
    }

    /// <summary>
    /// 判断是否已经转换为图片
    /// </summary>
    /// <param name="fileFullName"></param>
    /// <returns></returns>
    public static bool IsExistImage(string fileFullName)
    {

        string filePath = Path.GetDirectoryName(fileFullName);
        string[] files = Directory.GetFiles(filePath);

        List<object> result = new List<object>();
        if (files != null)
        {
            List<ReportFile> rfList = GetImageFiles(files);
            if (rfList != null && rfList.Count > 0)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 获取图片文件
    /// </summary>
    /// <param name="files"></param>
    /// <returns></returns>
    private static List<ReportFile> GetImageFiles(string[] files)
    {
        //文件排序
        List<ReportFile> rfList = new List<ReportFile>();
        Regex reg = new Regex(@"\(([^)]*)\).");
        for (int i = 0; i < files.Length; i++)
        {
            string ext = Path.GetExtension(files[i]);
            if (ext.ToLower().Equals(Constant.DEFAULT_REPORT_IMAGE_EXTENSION) || ext.ToLower().Equals(".png"))
            {
                int no = 0;
                string fileName = Path.GetFileName(files[i]);
                Match m = reg.Match(fileName);
                if (m.Success && !int.TryParse(m.Groups[m.Groups.Count - 1].Value, out no))
                {
                    //LogServicesHelper.Warn(string.Format("报告文件名称编号{0}转换数字失败", m.Groups[m.Groups.Count - 1].Value));

                }
                ReportFile rf = new ReportFile();
                rf.FileName = files[i];
                rf.No = no;
                rfList.Add(rf);
            }
        }
        return rfList;
    }

    /// <summary>
    /// 将报告的原始文件转换成图片或文本文件
    /// 2.4增加mutool/PDFLibNet/PDFRender4NET
    /// </summary>
    /// <param name="oppositePath"></param>
    /// <param name="sourceFileType"></param>
    /// <param name="targetFileType"></param>
    /// <returns></returns>
    private static void ConvertToFile(string oppositePath, FileExtTypeEnum sourceFileType, FileExtTypeEnum targetFileType)
    {
        string localPath = AppDomain.CurrentDomain.BaseDirectory;

        string targetFile = string.Empty;
        string sourceFile = Path.Combine(localPath, oppositePath);

        EnumConver conver = EnumConver.Xps2Jpeg;
        if (targetFileType == FileExtTypeEnum.Jpeg)
        {
            if (sourceFileType == FileExtTypeEnum.Pdf)
            {
                //根据配置选择不同的PDF转图片组件

                conver = EnumConver.Pdf2Jpeg;
                string pdf2JpegLib = AppSettings.app("WebManage", "PDF2JpegLib");

                switch (pdf2JpegLib)
                {
                    case "0":
                        conver = EnumConver.Pdf2Jpeg;
                        break;
                    case "1":
                        conver = EnumConver.Xps2JpegByAspose;
                        break;
                    case "2":
                        conver = EnumConver.Xps2JpegByAcrobat;
                        break;
                    case "3":
                        conver = EnumConver.Pdf2JpegBySpire;
                        break;
                    case "4":
                        conver = EnumConver.Pdf2Png;
                        break;
                    case "5":
                        conver = EnumConver.Pdf2JpegByPDFLibNet;
                        break;
                    case "6":
                        conver = EnumConver.Pdf2JpegByO2S;
                        break;

                    default:
                        conver = EnumConver.Pdf2Jpeg;
                        break;
                }

                targetFile = sourceFile.Replace(".pdf", Constant.DEFAULT_REPORT_IMAGE_EXTENSION);
            }
            else if (sourceFileType == FileExtTypeEnum.Xps)
            {
                conver = EnumConver.Xps2Jpeg;
                targetFile = sourceFile.Replace(".xps", Constant.DEFAULT_REPORT_IMAGE_EXTENSION);
            }

        }
        else
        {
            if (sourceFileType == FileExtTypeEnum.Pdf)
            {
                conver = EnumConver.Pdf2Txt;
                targetFile = sourceFile.Replace(".pdf", Constant.DEFAULT_REPORT_TXT_EXTENSION);
            }
            else if (sourceFileType == FileExtTypeEnum.Xps)
            {
                conver = EnumConver.Xps2Txt;
                targetFile = sourceFile.Replace(".xps", Constant.DEFAULT_REPORT_TXT_EXTENSION);
            }

        }
        ConvertTool.ConvertFile(sourceFile, targetFile, conver);
        //LogServicesHelper.Info(string.Format("文件转换路径：{0}    转换方式：{1}", sourceFile, conver.ToString()));
    }


    /// <summary>
    /// 获取目录下面所有的报告图片文件信息
    /// </summary>
    /// <param name="report"></param>
    /// <param name="fileFullName"></param>
    /// <param name="oppositePath"></param>
    /// <returns></returns>
    private static List<object> GetImageInfo(Report report, string fileFullName, string oppositePath)
    {
        string filePath = Path.GetDirectoryName(fileFullName);

        string[] files = Directory.GetFiles(filePath);

        List<object> result = new List<object>();
        if (files == null)
        {
            //LogServicesHelper.Warn("文件下载失败，Web临时存放目录下无报告源文件");
            return null;
        }
        //文件排序
        List<ReportFile> rfList = GetImageFiles(files);

        if (rfList == null || rfList.Count == 0)
        {
            //LogServicesHelper.Warn("文件转换失败，Web临时存放目录无图片文件");
            return null;
        }
        rfList = rfList.OrderBy(file => file.No).ToList();

        for (int i = 0; i < rfList.Count; i++)
        {
            string fileName = Path.GetFileName(rfList[i].FileName);
            string localPathName = rfList[i].FileName;
            string oppositePathName = Path.Combine(oppositePath, fileName);

            //获取图片文件的高度和宽度
            System.Drawing.Size size = FileHelper.GetImageSize(localPathName);

            var imageInfo = new
            {
                ReportId = report.ID,
                ServerPath = "",
                Url = oppositePathName + "?random=" + DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Base64String = ConvertTool.ImgToBase64String(localPathName),
                Height = size.Height.ToString(),
                Width = size.Width.ToString(),
                ImageName = fileName.Split('.')[0],
                ReportFilePath = report.ReportPath
            };
            result.Add(imageInfo);
        }
        return result;
    }

    /// <summary>
    /// 根据文件名对文件进行排序
    /// </summary>
    /// <param name="files"></param>
    /// <returns></returns>
    private static List<ReportFile> SortFileNames(string[] files, bool isBmp = false, bool isSmallImg = false)
    {
        //文件排序
        List<ReportFile> rfList = new List<ReportFile>();
        Regex reg = new Regex(@"\(([^)]*)\).");

        for (int i = 0; i < files.Length; i++)
        {
            string ext = Path.GetExtension(files[i]);
            var postfix = Constant.DEFAULT_REPORT_IMAGE_EXTENSION;
            if (isBmp)
            {
                postfix = Constant.DEFAULT_REPORT_MANAYFILMIMAGE_EXTENSION;
                if (!ext.ToLower().Equals(postfix))
                {
                    postfix = Constant.DEFAULT_REPORT_IMAGE_EXTENSION;
                }
            }
            else if (isSmallImg)
            {
                postfix = Constant.DEFAULT_REPORT_FILMSMALLIMAGE_EXTENSION;
            }
            if (ext.ToLower().Equals(postfix))
            {
                int no = 0;
                Match m = reg.Match(files[i]);
                if (m.Success)
                {
                    int.TryParse(m.Groups[m.Groups.Count - 1].Value, out no);
                }

                ReportFile rf = new ReportFile();
                rf.FileName = files[i];
                rf.No = no;
                rfList.Add(rf);
            }

        }
        //兼容2.2版本，如果没有略缩图，取大图
        if (isSmallImg && rfList.Count == 0)
        {
            if (files[files.Length - 1].IndexOf(Constant.DEFAULT_REPORT_IMAGE_EXTENSION) > -1)
            {
                int no = 0;
                Match m = reg.Match(files[files.Length - 1]);
                if (m.Success)
                {
                    int.TryParse(m.Groups[m.Groups.Count - 1].Value, out no);
                }

                ReportFile rf = new ReportFile();
                rf.FileName = files[files.Length - 1];
                rf.No = no;
                rfList.Add(rf);
            }
        }

        rfList = rfList.OrderBy(file => file.No).ToList();
        return rfList;
    }
}
