using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {

            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            var result = newPath(file);

            File.Move(sourcepath, result);

            var imgPath = result;

            imgPath = imgPath.Replace("C:\\Users\\icell\\source\\repos\\ReCapProject\\WebAPI\\wwwroot\\uploads\\", "");

            return imgPath;
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);

            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Delete(sourcePath);

            return result;
        }
        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            string path = Environment.CurrentDirectory + @"\wwwroot\uploads";

            var creatingUniqueFilename = Guid.NewGuid().ToString()
               + "_" + DateTime.Now.Month + "_"
               + DateTime.Now.Day + "_"
               + DateTime.Now.Year + fileExtension;

            string result = $@"{path}\{creatingUniqueFilename}";

            return result;
        }

    }
}
