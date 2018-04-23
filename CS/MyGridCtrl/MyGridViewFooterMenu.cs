using DevExpress.XtraGrid.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;

namespace DevExpress.S170736 {
    public class MyGridViewFooterMenu : GridViewFooterMenu {
        public MyGridViewFooterMenu(GridView view)
            : base(view) {
        }
        public override void Init(object info) {
            var hi = info as BandedGridHitInfo;
            base.Init(info);
            var rowSummaryItem = View.GetRowSummaryItem(hi.RowHandle, hi.Column);
            SetSummaryItem(rowSummaryItem.Key as GridGroupSummaryItem);
            if (hi.HitTest != BandedGridHitTest.RowFooter) {
                return;
            }
            var item = hi.FooterCell.ColumnInfo.Tag as GridGroupSummaryItem;
            SetSummaryItem(item);
        }
        private void SetSummaryItem(GridGroupSummaryItem item) {
            if (item == null) {
                return;
            }
            SummaryItem = item;
            CreateItems();
        }
    }
}
