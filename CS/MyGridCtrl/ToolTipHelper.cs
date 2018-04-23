using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExpress.S170736 {
    public class ToolTipHelper {
        private MyGridCtrl gridCtrl;
        public ToolTipHelper(MyGridCtrl gridControl) {
            Init(gridControl);
        }
        private void Init(MyGridCtrl gridControl) {
            gridCtrl = gridControl;
            var toolTipController = new ToolTipController();
            gridCtrl.ToolTipController = toolTipController;
            toolTipController.GetActiveObjectInfo += new ToolTipControllerGetActiveObjectInfoEventHandler(ToolTipController_GetActiveObjectInfo);
        }        
        private void ToolTipController_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e) {
            ToolTipControlInfo info = null;
            var view = gridCtrl.GetViewAt(e.ControlMousePosition) as MyBandedGridView;
            if (view == null) {
                return;
            }
            var hitInfo = view.CalcHitInfo(e.ControlMousePosition);
            if (hitInfo == null) {
                return;
            }
            var hitInfoFooterCell = hitInfo.FooterCell;
            if (hitInfoFooterCell != null) {
                var summaryItem = new GridGroupSummaryItem();
                var tag = hitInfoFooterCell.ColumnInfo.Tag as GridGroupSummaryItem;
                if (tag != null) {
                    summaryItem = tag;
                } else {
                    var rowSummaryItem = view.GetRowSummaryItem(hitInfo.RowHandle, hitInfoFooterCell.Column);
                    summaryItem = rowSummaryItem.Key as GridGroupSummaryItem;
                }
                if(summaryItem == null)
                    return;
                if (summaryItem.SummaryType == SummaryItemType.None) {
                    return;
                }
                info = new ToolTipControlInfo(hitInfoFooterCell.Value, hitInfoFooterCell.DisplayText);
            }
            if (info == null) {
                return;
            }
            e.Info = info;
        }
    }
}
