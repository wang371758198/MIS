using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;

namespace MIS.Frame
{
    /// <summary>
    /// 图片帮助类
    /// </summary>
    public static class ImageHelper
    {
        public static bool SaveImage(string fileName, string filePath, byte[] buffer)
        {
            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string path = filePath + "\\" + fileName;
                Stream stream = new FileStream(path, FileMode.Create);
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }


    }
}
