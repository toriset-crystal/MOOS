using Kernel.FS;
using Kernel.Misc;
using System.Drawing;

namespace Kernel.GUI
{
    internal class Desktop
    {
        private static Image FileIcon;
        public static string CurrentDirectory;

        public static void Initialize()
        {
            FileIcon = new PNG(File.Instance.ReadAllBytes("/UNKNOWN.PNG"));
            CurrentDirectory = " root@OS-Sharp: / ";
        }

        public static void Update()
        {
            const int BarHeight = 35;

            string[] names = File.Instance.GetFiles();
            int Devide = 60;
            int X = Devide;
            int Y = Devide + BarHeight;
            for (int i = 0; i < names.Length; i++)
            {
                if (Y + FileIcon.Height + Devide > Framebuffer.Height - Devide)
                {
                    Y = Devide + BarHeight;
                    X += FileIcon.Width + Devide;
                }

                Framebuffer.DrawImage(X, Y, FileIcon);
                BitFont.DrawString("Song", 0xFFFFFFFF, names[i], X, Y + FileIcon.Height, FileIcon.Width + 16);
                //Form.font.DrawString(X, Y + FileIcon.Height, names[i], FileIcon.Width);
                Y += FileIcon.Height + Devide;
            }
            names.Dispose();

            Framebuffer.Fill(0, 0, Framebuffer.Width, BarHeight, 0xFF101010);
            BitFont.DrawString("Song", 0xFFFFFFFF, CurrentDirectory, 0, (BarHeight / 2) - (16 / 2));
            //Form.font.DrawString(0, (BarHeight / 2) - (Form.font.Height / 2), CurrentDirectory, Framebuffer.Width);

            //string CPUUsage = ThreadPool.CPUUsage.ToString();
            string CPUUsage = "0";
            string Memory = ((Allocator.NumPages * Allocator.PageSize) / 1048576).ToString();
            string MemoryUsed = (Allocator.MemoryInUse / 1048576).ToString();
            string Result = $"CPU 0: {CPUUsage}% | Memory: {MemoryUsed}/{Memory}MiB";
            CPUUsage.Dispose();
            Memory.Dispose();
            MemoryUsed.Dispose();

            BitFont.DrawString("Song", 0xFFFFFFFF, Result, Framebuffer.Width - BitFont.MeasureString("Song", Result) - 16, (BarHeight / 2) - (16 / 2));
            //Form.font.DrawString(Framebuffer.Width - Form.font.MeasureString(Result) - Form.font.Width, (BarHeight / 2) - (Form.font.Height / 2), Result);

            Result.Dispose();
        }
    }
}