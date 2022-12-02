using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEcosystem.BL.Infrastructure
{
    public static class СonverterImage
    {
        public static byte[] ImageToByteArray(string? path)
        {
            if (!String.IsNullOrEmpty(path))
                return File.ReadAllBytes(Directory.GetCurrentDirectory() + "\\wwwroot" + path);
            else
                return new byte[] {1, 2 }; // Default photo
        }
    }
}
