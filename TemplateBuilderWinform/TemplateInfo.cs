//-----------------------------------------------------------------------
// <copyright file="TemplateInfo.cs" company="YGSoft Corp">
//     Copyright (c) YGSoft Corp. All rights reserved.
// </copyright>
// <summary>TemplateInfo description</summary>
// <author>wenguilong 2012-12-08</author>
//-----------------------------------------------------------------------

namespace TemplateBuilderWinform
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TemplateInfo description
    /// </summary>
    public class TemplateInfo
    {
        /// <summary>
        /// 模板编号
        /// </summary>
        private string tCode;
        public string TCode
        {
            get
            {
                return this.tCode;
            }

            set
            {
                this.tCode = value;
            }
        }

        /// <summary>
        /// 模板名称
        /// </summary>
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// 模板显示图片
        /// </summary>
        private string showImg;
        public string ShowImg
        {
            get
            {
                return this.showImg;
            }

            set
            {
                this.showImg = value;
            }
        }

        /// <summary>
        /// 模板存放路径
        /// </summary>
        private string path;
        public string Path
        {

            get
            {
                return this.path;
            }

            set
            {

                this.path = value;
            }
        }

        /// <summary>
        /// 模板主页面布局
        /// </summary>
        private string layout;
        public string Layout
        {
            get
            {
                return this.layout;
            }
            set
            {
                this.layout = value;
            }
        }
    }
}
