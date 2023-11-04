using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string picturePath = @"../../../copyMe.png";
            string pictureCopyPath = @"../../../copyMeCopy.png";

            using (FileStream fileReader = new FileStream(picturePath, FileMode.Open))
            {
                using (FileStream fileWriter = new FileStream(pictureCopyPath, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];

                        int currentSize = fileReader.Read(buffer, 0, buffer.Length);

                        bool hasToBreak = currentSize == 0;
                        if (hasToBreak)
                        {
                            break;
                        }

                        fileWriter.Write(buffer, 0, currentSize);
                    }
                }
            }
        }
    }
}
