using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExpress.S170736 {
    public class MyGridCtrl : GridControl {
        protected override void RegisterAvailableViewsCore(XtraGrid.Registrator.InfoCollection collection) {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridInfoRegistrator());
        }
        protected override XtraGrid.Views.Base.BaseView CreateDefaultView() {
            return CreateView("MyBandedGridView");
        }
    }
}
