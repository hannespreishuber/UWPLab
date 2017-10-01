using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Windows.UI.Xaml;

namespace Lab1
{
    public  class Helper
    {
        [DllImport("user32.dll", CharSet= CharSet.Ansi)]
        static extern char CharUpper(char character);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
         static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        public static int MessageBox1(String text, String caption)
        {
            return MessageBox(new IntPtr(0), text,  caption, 0);
        }

    }
}
