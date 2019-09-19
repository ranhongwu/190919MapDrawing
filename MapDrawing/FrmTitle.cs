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
using stdole;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Display;
using MapDrawing;

namespace RHW.CartoGraphic
{
    public partial class FrmTitle : DevExpress.XtraEditors.XtraForm
    {
        public FrmTitle(AxPageLayoutControl axPageLayoutControl)
        {
            InitializeComponent();
            pAxPageLayoutControl = axPageLayoutControl;
        }

        AxPageLayoutControl pAxPageLayoutControl = null;
        Color pColor = Color.Black;
        //字体设置
        IFontDisp pFontDisp = null;
        ITextSymbol pTextSymbol = new TextSymbolClass();

        //加载窗体
        private void FrmTitle_Load(object sender, EventArgs e)
        {
            pFontDisp = new stdole.StdFontClass() as stdole.IFontDisp;
            pFontDisp.Name = "Tahoma";
            pFontDisp.Size = 9;
            pTextSymbol.Font = pFontDisp;
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        //设置文字颜色
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pColor = colorDialog.Color;
                pTextSymbol.Color = ToIColor(pColor);
                richTextBox1.ForeColor = pColor;
            }
            else
            {
                return;
            }
        }

        //设置字体
        private void btnStyle_Click(object sender, EventArgs e)
        {
            System.Drawing.Font font = null;
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                font = fontDialog.Font;
                pFontDisp.Name = font.Name;
                pFontDisp.Size = (decimal)font.Size;
                pFontDisp.Italic = font.Italic;
                pFontDisp.Bold = font.Bold;
                pFontDisp.Underline = font.Underline;
                pTextSymbol.Font = pFontDisp;
            }
            else
            {
                return;
            }

            richTextBox1.Font = font;
        }

        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //应用
        private void btnOK_Click(object sender, EventArgs e)
        {
            #region 输入条件判断
            if(textEdit1.Text.Trim()=="")
            {
                MessageBox.Show("请输入标题!", "提示");
                return;
            }
            #endregion

            (this.Owner as FrmMapDrawing).pTextSymbol = pTextSymbol;
            (this.Owner as FrmMapDrawing).title= textEdit1.Text;
            this.Close();
        }

        #region 封装方法
        public IColor ToIColor(Color color)
        {
            return new RgbColorClass { RGB = color.B * 65536 + color.G * 256 + color.R, Transparency = color.A };
        }
        #endregion
    }
}