using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class FileUtil
    {
        public static string FileCreate(IFormFile file,string ImagePath, string folder)
        {
            string fileName = Guid.NewGuid() + file.FileName;
            string path = Path.Combine(ImagePath, folder, fileName);

            FileStream fs = new FileStream(path, FileMode.Create);

            file.CopyTo(fs);
            fs.Close();
            fs.Dispose();

            return fileName;
        }

        public static void FileDelete(string path)
        {

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
