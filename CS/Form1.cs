using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DevExpress.S170736 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            GridCtrlInit();
        }
        private void GridCtrlInit() {
            SetDataSource();
            AddSummaries(myBandedGridView1);
            SetToolTip();
            GroupColumns();
            BandColumns();
        }
        private void BandColumns() {
            gridBand2.Columns.Add(myBandedGridView1.Columns["Date"]);
            gridBand2.Columns.Add(myBandedGridView1.Columns["String"]);
            gridBand3.Columns.Add(myBandedGridView1.Columns["Data"]);
            gridBand3.Columns.Add(myBandedGridView1.Columns["Int"]); 
        }
        private void SetDataSource() {
            myGridCtrl1.DataSource = GetDataSource();
        }
        private object GetDataSource() {
            var table = CreateDataTable();
            return table;
        }
        private void AddSummaries(BandedGridView view) {
            view.GroupSummary.AddRange(new GridSummaryItem[] { new GridGroupSummaryItem() { SummaryType = SummaryItemType.Count, FieldName = "Data", ShowInGroupColumnFooter = view.Columns["Data"], DisplayFormat = "Count data = {0}" },
                new GridGroupSummaryItem() { SummaryType = SummaryItemType.Max, FieldName = "Date", ShowInGroupColumnFooter = view.Columns["Date"], DisplayFormat = "Max date = {0}" },
                new GridGroupSummaryItem() { SummaryType = SummaryItemType.Min, FieldName = "Date", ShowInGroupColumnFooter = view.Columns["Date"], DisplayFormat = "Min date = {0}" },
                new GridGroupSummaryItem() { SummaryType = SummaryItemType.Count, FieldName = "Date", ShowInGroupColumnFooter = view.Columns["Date"], DisplayFormat = "Count date = {0}" },
                new GridGroupSummaryItem() { SummaryType = SummaryItemType.Average, FieldName = "Int", ShowInGroupColumnFooter = view.Columns["Int"], DisplayFormat = "Avg int = {0}" },
                new GridGroupSummaryItem() { SummaryType = SummaryItemType.Sum, FieldName = "Int", ShowInGroupColumnFooter = view.Columns["Int"], DisplayFormat = "Sum int = {0}" },
                new GridGroupSummaryItem() { SummaryType = SummaryItemType.Count, FieldName = "Int", ShowInGroupColumnFooter = view.Columns["Int"], DisplayFormat = "Count int = {0}" },
                new GridGroupSummaryItem() { SummaryType = SummaryItemType.Count, FieldName = "String", ShowInGroupColumnFooter = view.Columns["String"], DisplayFormat = "Count string = {0}" }
            });
        }
        private void SetToolTip() {
            new ToolTipHelper(myGridCtrl1);
        }
        private DataTable CreateDataTable() {
            var table = new DataTable();
            var dataCol1 = new DataColumn("String", typeof(string));
            var dataCol2 = new DataColumn("Int", typeof(int));
            var dataCol3 = new DataColumn("Date", typeof(DateTime));
            var dataCol4 = new DataColumn("Data", typeof(string));
            table.Columns.AddRange(new DataColumn[] { dataCol1,
            dataCol2,
            dataCol3,
            dataCol4 });
            const int rowCount = 10;
            for (var i = 0; i < rowCount; i++) {
                table.Rows.Add(new object[] { String.Format("Row {0}", i), i, DateTime.Today.AddDays(i / 2 * 2), String.Format("Row #{0}", 100 - i) });
            }
            for (var i = rowCount; i < 2 * rowCount; i++) {
                table.Rows.Add(new object[] { String.Format("Row {0}", i), i * 2, DateTime.Today.AddDays(i / 2 * 2), String.Format("Row #{0}", 100 - i) });
            }
            return table;
        }
        private void GroupColumns() {
            myBandedGridView1.Columns["Date"].Group();
            myBandedGridView1.Columns["Int"].Group();
        }
    }
}

