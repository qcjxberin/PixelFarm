﻿//MIT 2014-2016, WinterDev

using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Mini
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //----------------------------
            OpenTK.Toolkit.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PixelFarm.Drawing.WinGdi.WinGdiPortal.Start();
            Application.Run(new FormDev());
        }
    }
}
