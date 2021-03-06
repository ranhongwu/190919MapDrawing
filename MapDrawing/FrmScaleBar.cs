﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using System.Runtime.InteropServices;
using MapDrawing;

namespace RHW.CartoGraphic
{
    public partial class FrmScaleBar : DevExpress.XtraEditors.XtraForm
    {
        public FrmScaleBar()
        {
            InitializeComponent();
        }

        #region 定义变量
        string pStylePath = @"\Styles\ESRI.ServerStyle";
        IStyleGalleryItem pStyleGalleryItem = null;
        #endregion

        //加载窗体
        private void FrmScaleBar_Load(object sender, EventArgs e)
        {
            axSymbologyControl1.LoadStyleFile(Application.StartupPath + pStylePath);
            axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassScaleBars;
        }

        //选择样式，图片框中预览
        private void axSymbologyControl1_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            pStyleGalleryItem = e.styleGalleryItem as IStyleGalleryItem;
            PreviewImage();
        }

        //双击样式选择
        private void axSymbologyControl1_OnDoubleClick(object sender, ISymbologyControlEvents_OnDoubleClickEvent e)
        {
            (this.Owner as FrmMapDrawing).pScaleStyleGalleryItem = pStyleGalleryItem;
            this.Close();
        }

        //加载样式
        private void btnLoadStyle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "style样式文件(*.style)|*.style";
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "选择样式文件";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pStylePath = openFileDialog.FileName;
                try
                {
                    axSymbologyControl1.LoadDesktopStyleFile(pStylePath);
                    MessageBox.Show("样式文件加载成功!", "提示");
                }
                catch (COMException ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                }
            }
        }

        //确定
        private void btnOK_Click(object sender, EventArgs e)
        {
            (this.Owner as FrmMapDrawing).pScaleStyleGalleryItem = pStyleGalleryItem;
            this.Close();
        }

        #region 封装方法
        /// <summary>
        /// 在图片框中预览选择的样式
        /// </summary>
        private void PreviewImage()
        {
            if (pStyleGalleryItem != null)
            {
                stdole.IPictureDisp picture = axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass).
                PreviewItem(pStyleGalleryItem, ptbPreview.Width, ptbPreview.Height);
                ptbPreview.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                IntPtr intPtr = new IntPtr(picture.Handle);
                ptbPreview.Image = Image.FromHbitmap(intPtr);
                picture = null;
            }
        }
        #endregion
        
    }
}