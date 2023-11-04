using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory;

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            FileInfo[] filesInDirectory = directoryInfo.GetFiles();

            Dictionary<string, Dictionary<string, double>> extensionNameSize = new Dictionary<string, Dictionary<string, double>>();

            foreach (FileInfo currentFile in filesInDirectory)
            {
                string fileName = currentFile.Name;
                string fileExpension = currentFile.Extension;
                double fileSize = currentFile.Length / 1024.0;

                bool isExtensionAdded = extensionNameSize.ContainsKey(fileExpension);
                if (!isExtensionAdded)
                {
                    extensionNameSize.Add(fileExpension, new Dictionary<string, double>());
                }

                extensionNameSize[fileExpension].Add(fileName, fileSize);
            }

            Dictionary<string, Dictionary<string, double>> sortedExtensionNameSize = extensionNameSize
                .OrderByDescending(x => x.Value.Keys.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/fileOutputName.txt";

            StringBuilder finalOutput = new StringBuilder();

            foreach (var kvp in sortedExtensionNameSize)
            {
                string extension = kvp.Key;
                Dictionary<string, double> nameAndSize = kvp.Value
                    .OrderBy(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);

                finalOutput.AppendLine($"{extension}");

                foreach (var (name, size) in nameAndSize)
                {
                    finalOutput.AppendLine($"--{name} - {Math.Round(size, 3)}kb");
                }
            }

            File.WriteAllText(pathToDesktop, finalOutput.ToString());
        }
    }
}
