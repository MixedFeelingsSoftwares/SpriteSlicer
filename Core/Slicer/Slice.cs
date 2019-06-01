using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpriteSlicer.Core.Slicer
{
    class Slicer
    {

        public class Slices
        {
            public List<Slice> slices = new List<Slice>();

            public class Slice
            {
                public int part { get; set; }
                public Bitmap getBitmap { get; set; }
            }
        }

        private static Bitmap temp_BMP;

        public static Bitmap GetBitmap
        {
            get
            {
                return temp_BMP;
            }
            set
            {
                value.MakeTransparent();
                temp_BMP = value;
            }
        }

        public static void LoadImage(string file)
        {
            GetBitmap = new Bitmap(Image.FromFile(file));
        }

        public static Slices SliceImage(int SliceWidth, int SliceHeight)
        {
            Slices _slices = new Slices();
            int p1 = GetBitmap.Width / SliceWidth;
            int p2 = GetBitmap.Height / SliceHeight;
            for (int y = 0; y < p2; y++)
            {
                for (int x = 0; x < p1; x++)
                {
                    int valX = x * SliceWidth;
                    int valY = y * SliceHeight;

                    var rect = new Rectangle
                    {
                        Width = SliceWidth,
                        Height = SliceHeight,
                        Size = new Size(SliceWidth, SliceHeight),
                        Location = new Point(valX,valY),
                        X = valX,
                        Y = valY,
                    };

                    var bmp = GetBitmap.Clone(rect, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    Slices.Slice slc = new Slices.Slice
                    {
                        getBitmap = bmp,
                        part = x,
                    };
                    _slices.slices.Add(slc);
                }
            }
            return _slices;
        }
    }
}
