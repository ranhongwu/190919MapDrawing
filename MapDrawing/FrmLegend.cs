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
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using MapDrawing;

namespace RHW.CartoGraphic
{
    public partial class FrmLegend : DevExpress.XtraEditors.XtraForm
    {
        public FrmLegend(AxPageLayoutControl pageLayout)
        {
            InitializeComponent();
            pPageLayout = pageLayout;
        }

        #region 定义变量
        AxPageLayoutControl pPageLayout = null;
        List<string> pRemoveLayer = new List<string>();
        #endregion

        //加载窗体
        private void FrmLegend_Load(object sender, EventArgs e)
        {
            lbxLayer.Items.Clear();
            for(int i = 0; i < pPageLayout.ActiveView.FocusMap.LayerCount; i++)
            {
                lbxLayer.Items.Add(pPageLayout.ActiveView.FocusMap.Layer[i].Name);
                pRemoveLayer.Add(pPageLayout.ActiveView.FocusMap.Layer[i].Name);
            }
        }

        //添加至右列表框
        private void btnAdd_Click(object sender, EventArgs e)
        {
            object selectItem = lbxLayer.SelectedItem;
            if (selectItem == null) return;
            if (!lbxSelectLayer.Items.Contains(selectItem))
            {
                lbxSelectLayer.Items.Add(selectItem);
            }
        }

        //全部添加至右列表框
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            lbxSelectLayer.Items.Clear();
            foreach(object obj in lbxLayer.Items)
            {
                lbxSelectLayer.Items.Add(obj);
            }
        }

        //右列表框删除一项
        private void btnDel_Click(object sender, EventArgs e)
        {
            object selectItem = lbxSelectLayer.SelectedItem;
            if (selectItem == null) return;
            lbxSelectLayer.Items.Remove(selectItem);
        }

        //右列表框全部删除
        private void btnDelAll_Click(object sender, EventArgs e)
        {
            lbxSelectLayer.Items.Clear();
        }

        //右列表框选择项目上移
        private void btnUp_Click(object sender, EventArgs e)
        {
            object selectItem = lbxSelectLayer.SelectedItem;
            int index = lbxSelectLayer.SelectedIndex;
            if (index == 0) return;
            lbxSelectLayer.Items.Insert(index - 1, selectItem);
            lbxSelectLayer.Items.RemoveAt(index+1);
            lbxSelectLayer.SelectedIndex=index-1;
        }

        //右列表框选择项目下移
        private void btnDown_Click(object sender, EventArgs e)
        {
            object selectItem = lbxSelectLayer.SelectedItem;
            int index = lbxSelectLayer.SelectedIndex;
            if (index == lbxSelectLayer.ItemCount-1) return;
            lbxSelectLayer.Items.Insert(index + 2, selectItem);
            lbxSelectLayer.Items.RemoveAt(index);
            lbxSelectLayer.SelectedIndex = index + 1;
        }

        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //应用，添加图例
        private void btnOK_Click(object sender, EventArgs e)
        {
            (this.Owner as FrmMapDrawing).pLenendItemsString = new List<string>();
            (this.Owner as FrmMapDrawing).pColumnCount = Convert.ToInt32(tbxColumnCount.Value);
            for (int i = 0; i < lbxSelectLayer.ItemCount; i++)
            {
                for(int j = 0; j < lbxLayer.ItemCount; j++)
                {
                    if (lbxSelectLayer.Items[i].ToString() == lbxLayer.Items[j].ToString())
                        pRemoveLayer.Remove(lbxSelectLayer.Items[i].ToString());
                }
            }
            for(int i=0;i< pRemoveLayer.Count;i++)
                (this.Owner as FrmMapDrawing).pLenendItemsString.Add(pRemoveLayer[i]);
            this.Close();
        }
    }
}