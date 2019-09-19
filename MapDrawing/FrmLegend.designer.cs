namespace RHW.CartoGraphic
{
    partial class FrmLegend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxLayer = new DevExpress.XtraEditors.ListBoxControl();
            this.lbxSelectLayer = new DevExpress.XtraEditors.ListBoxControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.tbxColumnCount = new System.Windows.Forms.NumericUpDown();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lbxLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbxSelectLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxColumnCount)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxLayer
            // 
            this.lbxLayer.Location = new System.Drawing.Point(6, 29);
            this.lbxLayer.Name = "lbxLayer";
            this.lbxLayer.Size = new System.Drawing.Size(202, 200);
            this.lbxLayer.TabIndex = 0;
            // 
            // lbxSelectLayer
            // 
            this.lbxSelectLayer.Location = new System.Drawing.Point(257, 29);
            this.lbxSelectLayer.Name = "lbxSelectLayer";
            this.lbxSelectLayer.Size = new System.Drawing.Size(202, 200);
            this.lbxSelectLayer.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(214, 27);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(37, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = ">";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(214, 56);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(37, 23);
            this.btnAddAll.TabIndex = 3;
            this.btnAddAll.Text = ">>";
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnDelAll
            // 
            this.btnDelAll.Location = new System.Drawing.Point(214, 130);
            this.btnDelAll.Name = "btnDelAll";
            this.btnDelAll.Size = new System.Drawing.Size(37, 23);
            this.btnDelAll.TabIndex = 5;
            this.btnDelAll.Text = "<<";
            this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(214, 101);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(37, 23);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "<";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(214, 202);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(37, 23);
            this.btnDown.TabIndex = 7;
            this.btnDown.Text = "↓";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(214, 173);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(37, 23);
            this.btnUp.TabIndex = 6;
            this.btnUp.Text = "↑";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // tbxColumnCount
            // 
            this.tbxColumnCount.Location = new System.Drawing.Point(261, 235);
            this.tbxColumnCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbxColumnCount.Name = "tbxColumnCount";
            this.tbxColumnCount.Size = new System.Drawing.Size(198, 22);
            this.tbxColumnCount.TabIndex = 8;
            this.tbxColumnCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(219, 237);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "列数：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(384, 271);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "应用";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(277, 271);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "地图图层：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(257, 9);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "图例项：";
            // 
            // FrmLegend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 311);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tbxColumnCount);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDelAll);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbxSelectLayer);
            this.Controls.Add(this.lbxLayer);
            this.MaximizeBox = false;
            this.Name = "FrmLegend";
            this.Text = "图例";
            this.Load += new System.EventHandler(this.FrmLegend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lbxLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbxSelectLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxColumnCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl lbxLayer;
        private DevExpress.XtraEditors.ListBoxControl lbxSelectLayer;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnAddAll;
        private DevExpress.XtraEditors.SimpleButton btnDelAll;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnDown;
        private DevExpress.XtraEditors.SimpleButton btnUp;
        private System.Windows.Forms.NumericUpDown tbxColumnCount;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}