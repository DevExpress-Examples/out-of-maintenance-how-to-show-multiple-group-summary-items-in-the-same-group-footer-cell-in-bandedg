using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.Handler;

namespace DevExpress.S170736
{
    public class MyGridHandler : BandedGridHandler {
        public MyGridHandler(BandedGridView gridView)
            : base(gridView) {
        }
        protected override XtraGrid.Menu.GridViewFooterMenu CreateGridViewFooterMenu(GridView gridView) {
            return new MyGridViewFooterMenu(gridView);
        }
    }
}
