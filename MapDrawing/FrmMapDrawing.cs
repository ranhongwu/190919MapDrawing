using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using RHW.CartoGraphic;
using stdole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapDrawing
{
    public partial class FrmMapDrawing : DevExpress.XtraEditors.XtraForm
    {
        public FrmMapDrawing()
        {
            InitializeComponent();
        }

        #region 定义通用变量
        int tag = 0;//记录操作的标签
        IMapSurround pMapSurround = null;
        UID pUid = null;
        string pElementTypeName = "";//记录创建元素的名称，图例？比例尺？...
        IMap pMap;
        #endregion

        #region 定义添加标题变量
        public string title = "";
        public ITextSymbol pTextSymbol = new TextSymbolClass();
        #endregion

        #region 定义添加图例变量
        public List<string> pLenendItemsString = new List<string>();
        ILegend2 pLegend2;
        public int pColumnCount = 1;
        //图例标题样式
        ITextSymbol pTitltTextSymbol = new TextSymbolClass();
        IFontDisp pTitltFont = new StdFont() as IFontDisp;
        //图例图层名样式
        ITextSymbol pLayerTextSymbol = new TextSymbolClass();
        IFontDisp pLayerFont = new StdFont() as IFontDisp;
        //图例标签样式
        ITextSymbol pLabelTextSymbol = new TextSymbolClass();
        IFontDisp pLabelFont = new StdFont() as IFontDisp;

        ILegendFormat pLenendFormat = new LegendFormat();
        #endregion

        #region 定义添加指北针变量
        public IStyleGalleryItem pNorthArrowStyleGalleryItem = null;
        #endregion

        #region 定义添加比例尺变量
        public IStyleGalleryItem pScaleStyleGalleryItem = null;
        #endregion

        //添加标题
        private void 标题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tag = 1;
            FrmTitle frmTitle = new FrmTitle(axPageLayoutControl1);
            frmTitle.Owner = this;
            frmTitle.ShowDialog();
        }

        //添加图例
        private void 图例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tag = 2;
            FrmLegend frmLegend = new FrmLegend(axPageLayoutControl1);
            frmLegend.Owner = this;
            frmLegend.ShowDialog();
        }

        //添加指北针
        private void 指北针ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tag = 3;
            FrmNorthArrow frmNorthArrow = new FrmNorthArrow();
            frmNorthArrow.Owner = this;
            frmNorthArrow.ShowDialog();
        }

        //添加比例尺
        private void 比例尺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tag = 4;
            FrmScaleBar frmScaleBar = new FrmScaleBar();
            frmScaleBar.Owner = this;
            frmScaleBar.ShowDialog();
        }

        //地图导出
        private void 地图导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMapExport frmMapExport = new FrmMapExport(axPageLayoutControl1.ActiveView);
            frmMapExport.ShowDialog();
        }

        #region 地图事件
        //点击地图框事件
        private void axPageLayoutControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {
                IPageLayout pPageLayout = axPageLayoutControl1.PageLayout; ;
                IGraphicsContainer pGraphicsContainer = pPageLayout as IGraphicsContainer;
                IActiveView pActiveView = pPageLayout as IActiveView;
                IMapFrame pMapFrame;
                IMapSurroundFrame pMapSurroundFrame;
                IElement pElement;
                switch (tag)
                {
                    #region 添加标题
                    case 1:
                        ITextElement pTextElement = new TextElementClass();
                        pTextElement.Text = title;
                        pTextElement.Symbol = pTextSymbol;
                        pElement = pTextElement as IElement;
                        try
                        {
                            pElement.Geometry = axPageLayoutControl1.TrackRectangle();
                        }
                        catch
                        {
                            MessageBox.Show("请拉框选择范围!", "提示");
                            return;
                        }
                        pGraphicsContainer.AddElement(pElement, 0);
                        axPageLayoutControl1.Refresh();
                        tag = 0;
                        break;
                    #endregion

                    #region 添加图例
                    case 2:
                        pLegend2 = new LegendClass_2();
                        pElement = axPageLayoutControl1.FindElementByName("legend");
                        if (pElement != null)
                        {
                            pGraphicsContainer.DeleteElement(pElement);
                        }

                        pElementTypeName = "lenend";
                        pUid = new UIDClass();
                        pUid.Value = "esriCato.Legend";
                        if (pGraphicsContainer == null) return;
                        pMapSurround = pLegend2 as IMapSurround;
                        pMapSurround.Map = pActiveView.FocusMap;
                        pMapFrame = pGraphicsContainer.FindFrame(pActiveView.FocusMap) as IMapFrame;
                        if (pMapFrame == null) return;

                        pMapSurroundFrame = new MapSurroundFrameClass();
                        pMapSurroundFrame = pMapFrame.CreateSurroundFrame(pUid, null);
                        pMapSurroundFrame.MapSurround = pMapSurround;
                        pMapSurroundFrame.MapSurround.Name = pElementTypeName;
                        pMapSurroundFrame.MapFrame = pMapFrame;

                        pElement = pMapSurroundFrame as IElement;
                        try
                        {
                            pElement.Geometry = axPageLayoutControl1.TrackRectangle();
                        }
                        catch
                        {
                            MessageBox.Show("请拉框选择范围!", "提示");
                            return;
                        }
                        pElement.Activate(pActiveView.ScreenDisplay);
                        pElement.Draw(pActiveView.ScreenDisplay, null);

                        pGraphicsContainer.AddElement(pElement, 0);
                        pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);

                        //图例标题字体样式
                        pLegend2.Title = "图例";
                        pTitltFont.Name = "黑体";
                        pTitltFont.Bold = true;
                        pTitltFont.Size = 16;
                        pTitltTextSymbol.Color = ColorToIColor(Color.Black);
                        pTitltTextSymbol.Font = pTitltFont;
                        pLenendFormat.TitleSymbol = pTitltTextSymbol;

                        //图例图层名字体样式
                        pLayerFont.Name = "仿宋_GB2312";
                        pLayerFont.Size = 13;
                        pLayerTextSymbol.Font = pLayerFont;

                        //图例标签字体样式
                        pLabelFont.Name = "仿宋_GB2312";
                        pLabelFont.Size = 13;
                        pLabelTextSymbol.Font = pLayerFont;

                        for (int i = 0; i < pLenendItemsString.Count; i++)
                        {
                            for (int j = 0; j < pLegend2.ItemCount; j++)
                            {
                                if (pLenendItemsString[i].ToString() == pLegend2.get_Item(j).Layer.Name)
                                    pLegend2.RemoveItem(j);
                            }
                        }
                        pLegend2.AdjustColumns(pColumnCount);
                        pLegend2.Refresh();
                        tag = 0;
                        break;
                    #endregion

                    #region 添加指北针
                    case 3:
                        if (pGraphicsContainer == null) return;
                        pElement = axPageLayoutControl1.FindElementByName("northarrow");
                        if (pElement != null)
                        {
                            pGraphicsContainer.DeleteElement(pElement);
                        }
                        pElementTypeName = "northarrow";
                        pUid = new UIDClass();
                        pUid.Value = "esriCato.MarkerNorthArrow";

                        pMapFrame = pGraphicsContainer.FindFrame(pActiveView.FocusMap) as IMapFrame;
                        pMapSurroundFrame = new MapSurroundFrameClass();
                        pMapSurroundFrame = pMapFrame.CreateSurroundFrame(pUid, null);
                        pMapSurroundFrame.MapSurround = pNorthArrowStyleGalleryItem.Item as IMapSurround;
                        pElement = pMapSurroundFrame as IElement;
                        try
                        {
                            pElement.Geometry = axPageLayoutControl1.TrackRectangle();
                        }
                        catch
                        {
                            MessageBox.Show("请拉框选择范围!", "提示");
                            return;
                        }
                        pGraphicsContainer.AddElement(pElement, 0);
                        pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                        tag = 0;
                        break;
                    #endregion

                    #region 添加比例尺
                    case 4:
                        if (pGraphicsContainer == null) return;
                        pElement = axPageLayoutControl1.FindElementByName("scalebar");
                        if (pElement != null)
                            pGraphicsContainer.DeleteElement(pElement);
                        IScaleBar pScaleBar;
                        pScaleBar = pScaleStyleGalleryItem.Item as IScaleBar;
                        pScaleBar.Units = esriUnits.esriKilometers;
                        pScaleBar.UnitLabel = " KM";
                        pElementTypeName = "scalebar";
                        pUid = new UIDClass();
                        pUid.Value = "esriCato.AlternatingScaleBar";

                        pMapFrame = pGraphicsContainer.FindFrame(pActiveView.FocusMap) as IMapFrame;
                        pMapSurroundFrame = new MapSurroundFrameClass();
                        pMapSurroundFrame = pMapFrame.CreateSurroundFrame(pUid, null);
                        pMapSurroundFrame.MapSurround = pScaleStyleGalleryItem.Item as IMapSurround;
                        pElement = pMapSurroundFrame as IElement;
                        try
                        {
                            pElement.Geometry = axPageLayoutControl1.TrackRectangle();
                        }
                        catch
                        {
                            MessageBox.Show("请拉框选择范围!", "提示");
                        }
                        pGraphicsContainer.AddElement(pElement, 0);
                        pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                        tag = 0;
                        break;
                        #endregion
                }
            }
        }
        #endregion

        #region 封装方法
        /// <summary>
        /// Color转IColor
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static IColor ColorToIColor(Color color)
        {
            IColor pColor = new RgbColorClass();
            pColor.RGB = color.B * 65536 + color.G * 256 + color.R;
            return pColor;
        }
        #endregion
        
    }
}
