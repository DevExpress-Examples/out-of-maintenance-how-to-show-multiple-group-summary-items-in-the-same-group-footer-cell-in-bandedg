using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;

namespace DevExpress.S170736 {
    public class MyBandedGridView : BandedGridView {        
        public MyBandedGridView(GridControl ownerGrid)
            : base(ownerGrid) {
        }
        public MyBandedGridView() {
        }
        protected override string ViewName {
            get {
                return "MyBandedGridView";
            }
        }
        public int GetGroupFooterRowCount() {
            if (IsDesignMode) {
                return 0;
            }
            var footerRowCount = GetFooterRowCount();
            if (footerRowCount.Count == 0) {
                return 0;
            }
            return footerRowCount.Max(kvp => kvp.Value);
        }
        private Dictionary<BandedGridColumn, int> GetFooterRowCount() {
            var columnFooterRowCount = new Dictionary<BandedGridColumn, int>();
            foreach (GridGroupSummaryItem summary in GroupSummary) {
                var column = summary.ShowInGroupColumnFooter as BandedGridColumn;
                if (column == null) {
                    continue;
                }
                if (columnFooterRowCount.ContainsKey(column)) {
                    columnFooterRowCount[column]++;
                }                
                if ((!columnFooterRowCount.ContainsKey(column))) {
                    columnFooterRowCount.Add(column, 1);
                }
            }
            return columnFooterRowCount;
        }
        protected override void SynchronizeSummary(System.Collections.IList gridSum, Data.SummaryItemCollection summary) {
            var gridSumCollection = gridSum as GridGroupSummaryItemCollection;
            if (gridSumCollection == null) {
                base.SynchronizeSummary(gridSum, summary);
                return;
            }
            var myGridSumCollection = new List<GridGroupSummaryItem>();
            var groupFooterRowCount = GetGroupFooterRowCount();
            MyGridSumCollectionAddSummary(gridSumCollection, myGridSumCollection);
            var query = GetGroups(myGridSumCollection);
            var tempSummaryItemList = new List<GridGroupSummaryItem>();            
            FillTempSummaryItemList(groupFooterRowCount, query, tempSummaryItemList);
            GridSumCollectionAddSummaries(gridSumCollection, tempSummaryItemList);
            base.SynchronizeSummary(gridSum, summary);
        }
        private void FillTempSummaryItemList(int groupFooterRowCount, IEnumerable<IGrouping<GridColumn, GridGroupSummaryItem>> query, List<GridGroupSummaryItem> tempSummaryItemList) {
            foreach (var group in query) {
                GridGroupSummaryItem summaryItem = null;
                GridColumn showInGroupColumnFooter = null;
                var fieldName = string.Empty;
                var summaryItemList = group.ToList();
                for (var i = 0; i < groupFooterRowCount; i++) {
                    try {
                        summaryItem = summaryItemList[i];
                    } catch {
                        summaryItem = null;
                    }
                    if (summaryItem != null) {
                        fieldName = summaryItem.FieldName;
                        showInGroupColumnFooter = summaryItem.ShowInGroupColumnFooter;
                        continue;
                    }
                    if (fieldName != string.Empty && showInGroupColumnFooter != null) {
                        summaryItem = new GridGroupSummaryItem() { SummaryType = SummaryItemType.None, ShowInGroupColumnFooter = showInGroupColumnFooter, FieldName = fieldName };
                        tempSummaryItemList.Add(summaryItem);
                    }
                }
            }
            AddEmptySummaryColumn(groupFooterRowCount, tempSummaryItemList);
        }
        private void AddEmptySummaryColumn(int groupFooterRowCount, List<GridGroupSummaryItem> tempSummaryItemList) {
            var footerRowCount = GetFooterRowCount();
            foreach (BandedGridColumn col in Columns) {
                if (footerRowCount.ContainsKey(col)) {
                    continue;
                }
                CreateEmptySummaries(col, tempSummaryItemList, groupFooterRowCount);
            }
        }
        private void CreateEmptySummaries(BandedGridColumn col, List<GridGroupSummaryItem> tempSummaryItemList, int groupFooterRowCount) {
            GridGroupSummaryItem summaryItem = null;
            GridColumn showInGroupColumnFooter = null;
            var fieldName = string.Empty;
            for (var i = 0; i < groupFooterRowCount - 1; i++) {
                showInGroupColumnFooter = col;
                fieldName = col.FieldName;
                summaryItem = new GridGroupSummaryItem() { SummaryType = SummaryItemType.None, ShowInGroupColumnFooter = showInGroupColumnFooter, FieldName = fieldName };
                tempSummaryItemList.Add(summaryItem);
            }
        }
        private void GridSumCollectionAddSummaries(GridGroupSummaryItemCollection gridSumCollection, List<GridGroupSummaryItem> tempSummaryItemList) {
            if (tempSummaryItemList.Count > 0) {
                gridSumCollection.AddRange(tempSummaryItemList.ToArray());
            }
        }
        private IEnumerable<IGrouping<GridColumn, GridGroupSummaryItem>> GetGroups(List<GridGroupSummaryItem> gridSumCollection) {
            var groups = from item in gridSumCollection
                        group item by item.ShowInGroupColumnFooter;
            return groups;
        }
        private void MyGridSumCollectionAddSummary(GridGroupSummaryItemCollection gridSumCollection, List<GridGroupSummaryItem> myGridSumCollection) {
            foreach (GridGroupSummaryItem summaryItem in gridSumCollection) {
                myGridSumCollection.Add(summaryItem);
            }
        }
    }
}
