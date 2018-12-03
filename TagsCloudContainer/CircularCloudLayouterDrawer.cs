﻿using System.Collections.Generic;
using System.Drawing;
using TagsCloudContainer.ResultFormatters;

namespace TagsCloudContainer
{
    public class CircularCloudLayouterDrawer : IResultFormatter
    {
        public void GenerateResult(Size size, Font font, Brush brush, string outputFileName,
            Dictionary<string, (Rectangle, int)> rectangles)
        {
            using (var bitmap = new Bitmap(size.Width, size.Height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    foreach (var entry in rectangles)
                    {
                        //graphics.DrawRectangle(new Pen(Color.Red), rectangle);
                        DrawStringInside(graphics, entry.Value.Item1,
                            font, brush, entry.Key);
                    }
                    bitmap.Save(outputFileName);
                }
            }
        }

        private static Graphics DrawStringInside(Graphics graphics, Rectangle rect, Font font, Brush brush, string text)
        {
            var textSize = graphics.MeasureString(text, font);
            var state = graphics.Save();
            graphics.TranslateTransform(rect.Left, rect.Top);
            graphics.ScaleTransform(rect.Width / textSize.Width, rect.Height / textSize.Height);
            graphics.DrawString(text, font, brush, PointF.Empty);
            graphics.Restore(state);

            return graphics;
        }
    }
}