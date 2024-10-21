using System;
using System.IO;

namespace TextureOptimizer
{
    internal class OptimPNG
    {
        public static System.Diagnostics.Process Optim(string path)
        {//requires pngquant to be in same directory as the calling executable
            return System.Diagnostics.Process.Start($"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"pngquant")}", $"--ext .png --force --skip-if-larger \"{path}\"");
        }
    }
}
