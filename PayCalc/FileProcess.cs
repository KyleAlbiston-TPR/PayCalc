using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public class FileProcess
    {
        public bool FileExists(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("filename");
            }
            return File.Exists(fileName);
        }
    }
}
