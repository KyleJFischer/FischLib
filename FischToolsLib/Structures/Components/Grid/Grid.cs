using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;

namespace FischLib.Structures.Components.Grid
{
    public class Grid
    {
        public GridObject[,] grid;
        public int width = 1;
        public int height = 1;
        public Color defaultColor = Color.Black;

        public Grid(int width, int height)
        {
            grid = new GridObject[width, height];
            this.width = width;
            this.height = height;
        }

        public Grid ToImageFastScale(int scale = 1)
        {
            var picture = ToImage(1);
            return new Bitmap(picture, new Size(scale, scale));
        }

        //public void  ToImage(int SizeOfPixel = 1)
        //{
        //    var endImage = new Bitmap(width * SizeOfPixel, height * SizeOfPixel);
        //    for (int x = 0; x < width; x++)
        //    {
        //        var tempX = x * SizeOfPixel;

        //        for (int y = 0; y < height; y++)
        //        {
        //            var ourThing = grid[x, y];

        //            var tempY = y * SizeOfPixel;
        //            for (int i = 0; i < SizeOfPixel; i++)
        //            {
        //                for (int yI = 0; yI < SizeOfPixel; yI++)
        //                {
        //                    if (ourThing != null)
        //                    {
        //                        endImage.SetPixel(tempX + i, tempY + yI, ourThing.color);
        //                    }
        //                    else
        //                    {
        //                        endImage.SetPixel(tempX + i, tempY + yI, defaultColor);
        //                    }
        //                }
        //            }


        //        }
        //    }

        //    return endImage;
        //}

        public void InsertIntoGrid(int x, int y, GridObject gridObj)
        {
            try
            {
                grid[x, y] = gridObj;

            }
            catch (Exception e)
            {

            }
        }

        public void MovePoint(int x, int y, int newX, int newY)
        {
            var point = grid[x, y];
            grid[newX, newY] = point;
            grid[x, y] = null;
        }

        public void SwapPoint(int x, int y, int secondX, int secondY)
        {
            var point = grid[x, y];


            grid[x, y] = grid[secondX, secondY];
            grid[secondX, secondY] = point;

        }

        public void SwapRow(int x, int secondX)
        {
            for (var i = 0; i < height; i++)
            {
                SwapPoint(x, i, secondX, i);
            }
        }

        public void SwapCol(int y, int secondY)
        {
            for (var i = 0; i < width; i++)
            {
                SwapPoint(i, y, i, secondY);
            }
        }
    }
}
