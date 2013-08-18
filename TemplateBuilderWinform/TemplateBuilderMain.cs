//-----------------------------------------------------------------------
// <copyright file="Form1.cs" company="YGSoft Corp">
//     Copyright (c) YGSoft Corp. All rights reserved.
// </copyright>
// <summary>Form1 description</summary>
// <author>wenguilong 2012-11-19 19:03:51</author>
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
    using DevExpress.XtraTreeList.Columns;

    /// <summary>
    /// Form1 description
    /// </summary>
    public partial class TemplateBuilderMain : Form
    {
        /// <summary>
        /// Form1 construct
        /// </summary>
        public TemplateBuilderMain()
        {
            InitializeComponent();
            InitToolTree();
        }

        private void NewProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SelectTemplateForm sform = new SelectTemplateForm();
            if (sform.ShowDialog() == DialogResult.OK)
            {
                string layout = sform.selectedTemp.Layout;
                this.InitToolTreeData(layout, sform.MainPath);
                this.htmlEditUserControl1.HtmlEditControl.Navigate(sform.MainPath);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layout"></param>
        /// <param name="MainPath"></param>
        private void InitToolTreeData(string layout, string MainPath)
        {
            DataTable dt = new DataTable();
            DataColumn dctypeid = new DataColumn("TypeID");
            dt.Columns.Add(dctypeid);
            DataColumn typeName = new DataColumn("TypeName");
            dt.Columns.Add(typeName);
            DataColumn ptypeID = new DataColumn("PTypeID");
            dt.Columns.Add(ptypeID);

            if (!string.IsNullOrEmpty(layout))
            {
                string[] layArray = layout.Split(',');
                for (int i = 0; i < layArray.Length; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["TypeID"] = i;
                    dr["PTypeID"] = -1;
                    dr["TypeName"] = layArray[i];
                    dt.Rows.Add(dr);
                    string toolpath = Path.Combine(Path.GetDirectoryName(MainPath), layArray[i]);
                    string[] files = Directory.GetFiles(toolpath);
                    for (int j = 0; j < files.Length; j++)
                    {
                        dr = dt.NewRow();
                        string filename = Path.GetFileName(files[j]);
                        dr["TypeID"] = layArray[i] + j.ToString();
                        dr["PTypeID"] = i;
                        dr["TypeName"] = filename.Split('.')[0];
                        dt.Rows.Add(dr);
                    }
                }
            }

            this.ToolTree.DataSource = dt;
        }

        /// <summary>
        /// 初始树
        /// </summary>
        private void InitToolTree()
        {
            this.ToolTree.BeginInit();
            this.ToolTree.KeyFieldName = "TypeID";
            this.ToolTree.ParentFieldName = "PTypeID";

            TreeListColumn display = new TreeListColumn();
            display.FieldName = "TypeName";
            display.Name = "treeListColumn2";
            display.VisibleIndex = 1;
            display.Width = 180;
            display.Options = ColumnOptions.ReadOnly;

            TreeListColumn id = new TreeListColumn();
            id.FieldName = "TypeID";
            id.Name = "treeListColumn3";
            id.VisibleIndex = -1;
            id.Options = ColumnOptions.ReadOnly;

            TreeListColumn parentID = new TreeListColumn();
            parentID.FieldName = "PTypeID";
            parentID.Name = "treeListColumn4";
            parentID.VisibleIndex = -1;
            parentID.Options = ColumnOptions.ReadOnly;

            this.ToolTree.ViewStylesInfo.FocusedCell.BackColor = this.ToolTree.ViewStylesInfo.FocusedRow.BackColor;
            this.ToolTree.ViewStylesInfo.FocusedCell.ForeColor = this.ToolTree.ViewStylesInfo.FocusedRow.ForeColor;
            TreeListColumn[] col = new TreeListColumn[] { id, display, parentID };
            this.ToolTree.Columns.AddRange(col);
            this.ToolTree.EndInit();
        }

        private void NewItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarOpenProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
