using DevExpress.XtraGrid.Views.Grid.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;

namespace DevExpress.S170736 {
    public class MyGridHandler : GridHandler {
        public MyGridHandler(GridView gridView)
            : base(gridView) {
        }
        protected override XtraGrid.Menu.GridViewFooterMenu CreateGridViewFooterMenu(GridView gridView) {
            return new MyGridViewFooterMenu(gridView);
        }
    }
}
