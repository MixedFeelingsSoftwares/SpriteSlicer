using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteSlicer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Sprite File Path: ");
            Console.ForegroundColor = ConsoleColor.White;

            string pth = Console.ReadLine();
             pth = pth.Replace("\"", "");
            SpriteSlicer.Core.Slicer.Slicer.LoadImage(pth);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Split by Width: ");
            Console.ForegroundColor = ConsoleColor.White;
            string x = Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Split by Height: ");
            Console.ForegroundColor = ConsoleColor.White;
            string y = Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Are you sure you want to split by {x}x{y}");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            var tp = SpriteSlicer.Core.Slicer.Slicer.SliceImage(64, 64);
            foreach (SpriteSlicer.Core.Slicer.Slicer.Slices.Slice slc in tp.slices.FindAll(img => img.getBitmap != null))
            {
                slc.getBitmap.MakeTransparent();
                slc.getBitmap.Save($"{Path.GetDirectoryName(pth)}/split_{slc.part}.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            Console.WriteLine("Successfully split image");
            Console.ReadLine();
        }
    }
}
