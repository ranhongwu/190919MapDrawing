﻿namespace RHW.CartoGraphic
{
    partial class FrmScaleBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScaleBar));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadStyle = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.ptbPreview = new DevExpress.XtraEditors.PictureEdit();
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPreview.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(287, 372);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnLoadStyle
            // 
            this.btnLoadStyle.Location = new System.Drawing.Point(287, 320);
            this.btnLoadStyle.Name = "btnLoadStyle";
            this.btnLoadStyle.Size = new System.Drawing.Size(75, 23);
            this.btnLoadStyle.TabIndex = 17;
            this.btnLoadStyle.Text = "加载样式";
            this.btnLoadStyle.Click += new System.EventHandler(this.btnLoadStyle_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.ptbPreview);
            this.groupControl3.Location = new System.Drawing.Point(0, 267);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(276, 170);
            this.groupControl3.TabIndex = 16;
            this.groupControl3.Text = "预览";
            // 
            // ptbPreview
            // 
            this.ptbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbPreview.Location = new System.Drawing.Point(2, 21);
            this.ptbPreview.Name = "ptbPreview";
            this.ptbPreview.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.ptbPreview.Size = new System.Drawing.Size(272, 147);
            this.ptbPreview.TabIndex = 0;
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.axSymbologyControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axSymbologyControl1.Location = new System.Drawing.Point(0, 0);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(384, 261);
            this.axSymbologyControl1.TabIndex = 15;
            this.axSymbologyControl1.OnDoubleClick += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnDoubleClickEventHandler(this.axSymbologyControl1_OnDoubleClick);
            this.axSymbologyControl1.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // FrmScaleBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 437);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnLoadStyle);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.axSymbologyControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmScaleBar";
            this.Text = "比例尺";
            this.Load += new System.EventHandler(this.FrmScaleBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbPreview.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnLoadStyle;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.PictureEdit ptbPreview;
        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
    }
}