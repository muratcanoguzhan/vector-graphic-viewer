﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;

namespace VectorGraphicViewer.Desktop.Extensions
{
    public static class StringExtension
    {
        public static Color ToColor(this string color, string seperator = ";")
        {
            var arrColorFragments = color.Split(seperator).Select(sFragment => { int.TryParse(sFragment, out int fragment); return fragment; }).ToArray();

            switch (arrColorFragments?.Length)
            {
                case 3:
                    return System.Drawing.Color.FromArgb(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2]);
                case 4:
                    return System.Drawing.Color.FromArgb(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2], arrColorFragments[3]);
                default:
                    return System.Drawing.Color.Transparent;
            }
        }
        
        public static PointF ToPointF(this string point, string seperator = ";")
        {
            var pointArray = point.Split(seperator).Select(x => { float.TryParse(x, NumberStyles.Any,new NumberFormatInfo() { NumberDecimalSeparator = "," }, out float fragment); return fragment; }).ToArray();

            return new PointF(pointArray[0], pointArray[1]);
        }
    }
}
