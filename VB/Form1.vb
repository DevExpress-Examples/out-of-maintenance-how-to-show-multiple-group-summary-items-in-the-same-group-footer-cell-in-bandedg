Imports Microsoft.VisualBasic
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms

Namespace DevExpress.S170736
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			GridCtrlInit()
		End Sub
		Private Sub GridCtrlInit()
			SetDataSource()
			AddSummaries(myBandedGridView1)
			SetToolTip()
			GroupColumns()
			BandColumns()
		End Sub
		Private Sub BandColumns()
			gridBand2.Columns.Add(myBandedGridView1.Columns("Date"))
			gridBand2.Columns.Add(myBandedGridView1.Columns("String"))
			gridBand3.Columns.Add(myBandedGridView1.Columns("Data"))
			gridBand3.Columns.Add(myBandedGridView1.Columns("Int"))
		End Sub
		Private Sub SetDataSource()
			myGridCtrl1.DataSource = GetDataSource()
		End Sub
		Private Function GetDataSource() As Object
			Dim table = CreateDataTable()
			Return table
		End Function
		Private Sub AddSummaries(ByVal view As BandedGridView)
			view.GroupSummary.AddRange(New GridSummaryItem() { New GridGroupSummaryItem() With {.SummaryType = SummaryItemType.Count, .FieldName = "Data", .ShowInGroupColumnFooter = view.Columns("Data"), .DisplayFormat = "Count data = {0}"}, New GridGroupSummaryItem() With {.SummaryType = SummaryItemType.Max, .FieldName = "Date", .ShowInGroupColumnFooter = view.Columns("Date"), .DisplayFormat = "Max date = {0}"}, New GridGroupSummaryItem() With {.SummaryType = SummaryItemType.Min, .FieldName = "Date", .ShowInGroupColumnFooter = view.Columns("Date"), .DisplayFormat = "Min date = {0}"}, New GridGroupSummaryItem() With {.SummaryType = SummaryItemType.Count, .FieldName = "Date", .ShowInGroupColumnFooter = view.Columns("Date"), .DisplayFormat = "Count date = {0}"}, New GridGroupSummaryItem() With {.SummaryType = SummaryItemType.Average, .FieldName = "Int", .ShowInGroupColumnFooter = view.Columns("Int"), .DisplayFormat = "Avg int = {0}"}, New GridGroupSummaryItem() With {.SummaryType = SummaryItemType.Sum, .FieldName = "Int", .ShowInGroupColumnFooter = view.Columns("Int"), .DisplayFormat = "Sum int = {0}"}, New GridGroupSummaryItem() With {.SummaryType = SummaryItemType.Count, .FieldName = "Int", .ShowInGroupColumnFooter = view.Columns("Int"), .DisplayFormat = "Count int = {0}"}, New GridGroupSummaryItem() With {.SummaryType = SummaryItemType.Count, .FieldName = "String", .ShowInGroupColumnFooter = view.Columns("String"), .DisplayFormat = "Count string = {0}"} })
		End Sub
		Private Sub SetToolTip()
			Dim TempToolTipHelper As ToolTipHelper = New ToolTipHelper(myGridCtrl1)
		End Sub
		Private Function CreateDataTable() As DataTable
			Dim table = New DataTable()
			Dim dataCol1 = New DataColumn("String", GetType(String))
			Dim dataCol2 = New DataColumn("Int", GetType(Integer))
			Dim dataCol3 = New DataColumn("Date", GetType(DateTime))
			Dim dataCol4 = New DataColumn("Data", GetType(String))
			table.Columns.AddRange(New DataColumn() { dataCol1, dataCol2, dataCol3, dataCol4 })
			Const rowCount As Integer = 10
			For i = 0 To rowCount - 1
				table.Rows.Add(New Object() { String.Format("Row {0}", i), i, DateTime.Today.AddDays(i / 2 * 2), String.Format("Row #{0}", 100 - i) })
			Next i
			For i = rowCount To 2 * rowCount - 1
				table.Rows.Add(New Object() { String.Format("Row {0}", i), i * 2, DateTime.Today.AddDays(i / 2 * 2), String.Format("Row #{0}", 100 - i) })
			Next i
			Return table
		End Function
		Private Sub GroupColumns()
			myBandedGridView1.Columns("Date").Group()
			myBandedGridView1.Columns("Int").Group()
		End Sub
	End Class
End Namespace

