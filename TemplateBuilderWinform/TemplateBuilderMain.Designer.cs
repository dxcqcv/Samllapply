namespace TemplateBuilderWinform
{
    partial class TemplateBuilderMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ToolTree = new DevExpress.XtraTreeList.TreeList();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.NewProject = new DevExpress.XtraBars.BarButtonItem();
            this.NewItem = new DevExpress.XtraBars.BarButtonItem();
            this.BarOpenProject = new DevExpress.XtraBars.BarButtonItem();
            this.BarSave = new DevExpress.XtraBars.BarButtonItem();
            this.BarExit = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem8 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem9 = new DevExpress.XtraBars.BarSubItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.文件 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.htmlEditUserControl1 = new WebBrowserContorl.HtmlEditUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.文件)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Controller = this.barAndDockingController1;
            this.dockManager1.DockingOptions.ShowCloseButton = false;
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar"});
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("55246243-b1c2-4212-bc77-7b7e6646eca2");
            this.dockPanel1.Location = new System.Drawing.Point(0, 23);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(200, 537);
            this.dockPanel1.Text = "工具箱";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.ToolTree);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 24);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 509);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // ToolTree
            // 
            this.ToolTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolTree.Location = new System.Drawing.Point(0, 0);
            this.ToolTree.Name = "ToolTree";
            this.ToolTree.Size = new System.Drawing.Size(192, 509);
            this.ToolTree.TabIndex = 0;
            this.ToolTree.Text = "treeList1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barSubItem2,
            this.barSubItem3,
            this.barSubItem8,
            this.barSubItem9,
            this.NewProject,
            this.NewItem,
            this.BarOpenProject,
            this.BarSave,
            this.BarExit});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 30;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 1";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem8)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 1";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "文件";
            this.barSubItem1.Id = 16;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarOpenProject),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarExit)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "新建";
            this.barSubItem2.Id = 17;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.NewProject),
            new DevExpress.XtraBars.LinkPersistInfo(this.NewItem)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // NewProject
            // 
            this.NewProject.Caption = "工程";
            this.NewProject.Id = 25;
            this.NewProject.Name = "NewProject";
            this.NewProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NewProject_ItemClick);
            // 
            // NewItem
            // 
            this.NewItem.Caption = "项目";
            this.NewItem.Id = 26;
            this.NewItem.Name = "NewItem";
            this.NewItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NewItem_ItemClick);
            // 
            // BarOpenProject
            // 
            this.BarOpenProject.Caption = "打开";
            this.BarOpenProject.Id = 27;
            this.BarOpenProject.Name = "BarOpenProject";
            this.BarOpenProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarOpenProject_ItemClick);
            // 
            // BarSave
            // 
            this.BarSave.Caption = "保存";
            this.BarSave.Id = 28;
            this.BarSave.Name = "BarSave";
            this.BarSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarSave_ItemClick);
            // 
            // BarExit
            // 
            this.BarExit.Caption = "退出";
            this.BarExit.Id = 29;
            this.BarExit.Name = "BarExit";
            this.BarExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarExit_ItemClick);
            // 
            // barSubItem8
            // 
            this.barSubItem8.Caption = "编辑";
            this.barSubItem8.Id = 23;
            this.barSubItem8.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem9)});
            this.barSubItem8.Name = "barSubItem8";
            // 
            // barSubItem9
            // 
            this.barSubItem9.Caption = "复制";
            this.barSubItem9.Id = 24;
            this.barSubItem9.Name = "barSubItem9";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "打开";
            this.barSubItem3.Id = 18;
            this.barSubItem3.Name = "barSubItem3";
            // 
            // 文件
            // 
            this.文件.Name = "文件";
            // 
            // htmlEditUserControl1
            // 
            this.htmlEditUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlEditUserControl1.IsToolbarVisible = true;
            this.htmlEditUserControl1.Location = new System.Drawing.Point(200, 23);
            this.htmlEditUserControl1.Name = "htmlEditUserControl1";
            this.htmlEditUserControl1.Size = new System.Drawing.Size(732, 537);
            this.htmlEditUserControl1.TabIndex = 6;
            // 
            // TemplateBuilderMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 560);
            this.Controls.Add(this.htmlEditUserControl1);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TemplateBuilderMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模板生成器主窗体";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToolTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.文件)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit 文件;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarSubItem barSubItem8;
        private DevExpress.XtraBars.BarSubItem barSubItem9;
        private DevExpress.XtraBars.BarButtonItem NewProject;
        private DevExpress.XtraBars.BarButtonItem NewItem;
        private DevExpress.XtraBars.BarButtonItem BarOpenProject;
        private DevExpress.XtraBars.BarButtonItem BarSave;
        private DevExpress.XtraBars.BarButtonItem BarExit;
        private WebBrowserContorl.HtmlEditUserControl htmlEditUserControl1;
        private DevExpress.XtraTreeList.TreeList ToolTree;
    }
}

