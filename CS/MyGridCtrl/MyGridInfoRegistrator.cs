using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace DevExpress.S170736 {
    public class MyGridInfoRegistrator : BandedGridInfoRegistrator {        
        public override XtraGrid.Views.Base.BaseView CreateView(GridControl grid) {
            return new MyBandedGridView(grid as GridControl);
        }
        public override XtraGrid.Views.Base.ViewInfo.BaseViewInfo CreateViewInfo(XtraGrid.Views.Base.BaseView view) {
            return new MyBandedGridViewInfo((BandedGridView)view);
        }
        public override string ViewName {
            get {
                return "MyBandedGridView";
            }
        }
        public override XtraGrid.Views.Base.Handler.BaseViewHandler CreateHandler(XtraGrid.Views.Base.BaseView view) {
            return new MyGridHandler(view as MyBandedGridView);
        }
    }
}
