//-----------------------------------------------------------------------
// <copyright file="SelectTemplateForm.cs" company="YGSoft Corp">
//     Copyright (c) YGSoft Corp. All rights reserved.
// </copyright>
// <summary>SelectTemplateForm description</summary>
// <author>wenguilong 2012-11-20 9:34:08</author>
//-----------------------------------------------------------------------

namespace TemplateBuilderWinform
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Xml;
    using ICSharpCode.SharpZipLib.Zip;

    /// <summary>
    /// SelectTemplateForm description
    /// </summary>
    public partial class SelectTemplateForm : Form
    {
        private string currentPath = string.Empty;
        public string CurrentPath
        {
            get
            {
                if (String.IsNullOrEmpty(currentPath))
                {
                    string codeBase = typeof(SelectTemplateForm).Assembly.CodeBase;
                    currentPath = Path.GetDirectoryName(codeBase.Substring(8, codeBase.Length - 8));
                }

                return currentPath;
            }
        }

        /// <summary>
        /// 首页临时路径，用于在编辑器里打开
        /// </summary>
        private string mainPath = string.Empty;

        /// <summary>
        /// 首页临时路径，用于在编辑器里打开
        /// </summary>
        public string MainPath
        {
            get
            {
                return this.mainPath;
            }

            set
            {
                this.mainPath = value;
            }
        }

        /// <summary>
        /// 获取当前选中的项信息
        /// </summary>
        public TemplateInfo selectedTemp
        {
            get
            {
                ListViewItem item = this.listView1.SelectedItems[0];
                if (item != null)
                {
                    return this.templateInfoList[item.Name];
                }
                else
                {
                   return  new TemplateInfo();
                }
            }
        }

        /// <summary>
        /// 主页面布局方式
        /// </summary>
        private Dictionary<string, TemplateInfo> templateInfoList = new Dictionary<string, TemplateInfo>();

        /// <summary>
        /// 主页面布局方式
        /// </summary>
        public Dictionary<string, TemplateInfo> TemplateInfoList
        {
            get { return this.templateInfoList; }
            set { this.templateInfoList = value; }
        }

        /// <summary>
        /// SelectTemplateForm construct
        /// </summary>
        public SelectTemplateForm()
        {
            InitializeComponent();
            this.listView1.LargeImageList = this.imageList1;
            // this.imageList1.ImageSize = new Size(64, 64);
        }

        private void SelectTemplateForm_Load(object sender, EventArgs e)
        {
            //加载图片列表
            this.InitImage();
        }

        private void InitImage()
        {
            string templateXml = Path.Combine(CurrentPath, "templs.xml");
            XmlUtil xml = new XmlUtil(templateXml);
            XmlNode node = xml.GetNode("TemplateRoot");
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                XmlNode n = node.ChildNodes[i];
                string code = n.Attributes["TCode"].Value.ToString();
                string name = n.Attributes["Name"].Value.ToString();
                string showimg = n.Attributes["ShowImg"].Value.ToString();
                string temppath = n.Attributes["Path"].Value.ToString();
                string layout = n.Attributes["Layout"].Value.ToString();
                string imageKeyFile = Path.Combine(CurrentPath, showimg);
                Bitmap toolResource = new Bitmap(imageKeyFile);
                this.imageList1.Images.Add(code, toolResource);
                TemplateInfo tempinfo = new TemplateInfo() { TCode = code, Name = name, ShowImg = showimg, Path = temppath, Layout = layout };
                if (this.templateInfoList.ContainsKey(code))
                {
                    this.templateInfoList[code] = tempinfo;
                }
                else
                {
                    this.templateInfoList.Add(code, tempinfo);
                }

                ListViewItem item = new ListViewItem();
                item.ImageKey = code;
                item.Name = code;
                item.Tag = temppath;
                item.Text = name;
                item.Group = this.listView1.Groups[0];
                this.listView1.Items.Add(item);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.listView1.SelectedItems[0];
            string templatePath = Path.Combine(CurrentPath, item.Tag.ToString());
            string templateCommFile = Path.Combine(currentPath, "webTmpl\\TmplComm.zip");
            string tempPath = Path.Combine(CurrentPath, item.Name + "\\");
            if (!Directory.Exists(tempPath))
            {
                string[] args = new string[] { templatePath, tempPath };
                UnZipClass.UnZip(args);
                args = new string[] { templateCommFile, tempPath };
                UnZipClass.UnZip(args);
            }
            else
            {
                Directory.Delete(tempPath, true);
                string[] args = new string[] { templatePath, tempPath };
                UnZipClass.UnZip(args);
                args = new string[] { templateCommFile, tempPath };
                UnZipClass.UnZip(args);
            }

            string configPath = tempPath + "libs\\config.js";
            StreamReader sr = new StreamReader(configPath);
            string config = sr.ReadToEnd();
            config = config.Replace("{0}", item.Name);
            ////config = string.Format(config, item.Name);
            sr.Close();
            StreamWriter sw = new StreamWriter(configPath);
            sw.Write(config);
            sw.Close();

            mainPath = tempPath + "main.html";
            this.DialogResult = DialogResult.OK;
        }
    }
}

