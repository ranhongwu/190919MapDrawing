using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using System.Runtime.InteropServices;

namespace RHW.CartoGraphic
{
    public partial class FrmMapExport : DevExpress.XtraEditors.XtraForm
    {
        public FrmMapExport(IActiveView activeView)
        {
            InitializeComponent();
            pActiveView = activeView;
        }

        #region 定义变量
        string pFileType;//用于saveFileDialog的Filter
        string pSimpleFiletype;//仅包含文件扩展名
        double pResolution = 0;
        string pSavePath;
        IActiveView pActiveView;
        #endregion

        //浏览
        private void btnSelectSavePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "选择导出路径";
            saveFileDialog.Filter = pFileType;
            saveFileDialog.OverwritePrompt = false;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pSavePath = saveFileDialog.FileName;
                tbxSavePath.Text = pSavePath;
            }
            else
            {
                return;
            }
        }

        //加载窗体
        private void FrmMapExport_Load(object sender, EventArgs e)
        {
            pFileType = TypeConvert(cbxType.Text.Trim());
            pResolution = Convert.ToDouble(numResolution.Value);
        }

        //选择输出类型
        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pFileType = TypeConvert(cbxType.Text.Trim());
        }

        //修改分辨率大小
        private void numResolution_ValueChanged(object sender, EventArgs e)
        {
            pResolution = Convert.ToDouble(numResolution.Value);
        }

        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //导出
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbxSavePath.Text.Trim() == "" || !tbxSavePath.Text.Trim().Contains("\\"))
            {
                MessageBox.Show("请选择正确的输出路径!", "提示");
                return;
            }
            IExport pExport = null;
            try
            {
                switch (pSimpleFiletype)
                {
                    case "tif":
                        pExport = new ExportTIFF() as IExport;
                        break;
                    case "EMF":
                        pExport = new ExportEMF() as IExport;
                        break;
                    case "eps":
                        pExport = new ExportPS() as IExport;
                        break;
                    case "ai":
                        pExport = new ExportAI() as IExport;
                        break;
                    case "pdf":
                        pExport = new ExportPDF() as IExport;
                        break;
                    case "svg":
                        pExport = new ExportSVG() as IExport;
                        break;
                    case "bmp":
                        pExport = new ExportBMP() as IExport;
                        break;
                    case "jpg":
                        pExport = new ExportEMF() as IExport;
                        break;
                    case "png":
                        pExport = new ExportPNG() as IExport;
                        break;
                    case "gif":
                        pExport = new ExportGIF() as IExport;
                        break;
                    default:
                        return;
                }
                pExport.ExportFileName = pSavePath;
                pExport.Resolution = pResolution;
                tagRECT pTagRECT;
                pTagRECT = pActiveView.ExportFrame;
                IPrintAndExport printAndExport = new PrintAndExport();
                printAndExport.Export(pActiveView, pExport, pResolution, false, null);
                Marshal.ReleaseComObject(pExport);
                MessageBox.Show("导出成功!", "提示");
            }
            catch(COMException ex)
            {
                MessageBox.Show("导出失败\n" + ex.Message, "错误");
                return;
            }
        }

        #region 封装方法
        /// <summary>
        /// 将下拉框中的数据类型转换为纯数据类型字符串
        /// </summary>
        /// <param name="pDisplayType">数据框中的数据类型字符串</param>
        /// <returns>返回纯数据类型的字符串</returns>
        private string TypeConvert(string pDisplayType)
        {
            int index = pDisplayType.IndexOf("（");
            pSimpleFiletype = pDisplayType.Substring(0, index).ToLower();
            return pSimpleFiletype + "(*." + pSimpleFiletype + ")|*." + pSimpleFiletype;
        }
        #endregion
    }
}