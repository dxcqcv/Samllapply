//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="YGSoft Corp">
//     Copyright (c) YGSoft Corp. All rights reserved.
// </copyright>
// <summary>Program description</summary>
// <author>wenguilong 2012-11-19 19:03:51</author>
//-----------------------------------------------------------------------

namespace TemplateBuilderWinform
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// 应用程序的主入口类。
    /// </summary>
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TemplateBuilderMain());
        }
    }
}
