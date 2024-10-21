using System;
using System.Collections.Generic;
using System.IO;
using TextureOptimizer;

class Program
{
    static int Main(string[] args)
    {
        Console.WriteLine($"Arguments: {string.Join(", ", args)}");

        if (args.Length == 0)
        {
            string[] args1 = { Environment.CurrentDirectory };//backup is executing directory (NOT the executable directory!)
            return SubMain(args1);
        }
        else return SubMain(args);
    }
    static int SubMain(string[] args)
    {
        for (var i = 0; i < args.Length; i++)
        {
            if (File.Exists(args[i]))
            {
                applyToFile(args[i]);
            }
            else if (Directory.Exists(args[i]))
            {
                foreach (string filePath in getFiles(args[i]))
                {
                    applyToFile(filePath);
                }
            }
            else
            {
                Console.WriteLine($"ERROR: invalid param {i}: {args[i]}");
            }
        }
        System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        return 0;
    }
    static void applyToFile(string filePath)
    {
        DetectedFileType fileType = TextureOptimizer.TypeFileDetector.GetImageFormat(filePath);
        switch (fileType) //apply algo according to file type
        {
            case DetectedFileType.png: Console.WriteLine("PNG: " + filePath); TextureOptimizer.OptimPNG.Optim(filePath); break;//optimise with pngquant https://pngquant.org/
            //case DetectedFileType.jpeg: Console.WriteLine("Jpeg: " + filePath); break;//TODO optimise with https://github.com/tjko/jpegoptim
            default: Console.WriteLine("Not handled file type "+ fileType + ": " + filePath); break;
        }
    }
    static IEnumerable<string> getFiles(string directoryPath)
    {
        string[] files = Directory.GetFiles(directoryPath);//TODO TryCatch
        for (int i = 0; i < files.Length; i++)
        {
            yield return files[i];
        }
        foreach (string subDir in Directory.GetDirectories(directoryPath))//TODO TryCatch
        {
            foreach (string filePath in getFiles(subDir))
            {
                yield return filePath;
            }
        }

        yield break;
    }
}
