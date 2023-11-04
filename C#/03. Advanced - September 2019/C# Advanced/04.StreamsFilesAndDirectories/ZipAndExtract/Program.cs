using System;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string zipPath = @"../../../myZipFile.zip";
            string picturePath = @"../../../copyMe.png";

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(picturePath, Path.GetFileName(picturePath));
            }

            string extractPath = @"../../";

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
