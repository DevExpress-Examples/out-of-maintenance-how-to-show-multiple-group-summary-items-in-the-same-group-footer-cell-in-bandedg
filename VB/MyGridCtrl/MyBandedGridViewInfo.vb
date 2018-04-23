Imports Microsoft.VisualBasic
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Drawing
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.BandedGrid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq

Namespace DevExpress.S170736
	Public Class MyBandedGridViewInfo
		Inherits BandedGridViewInfo
		Public Sub New(ByVal gridView As BandedGridView)
			MyBase.New(gridView)
		End Sub
		Protected Overrides Function CalcGroupFooterHeight() As Integer
			Dim myView = CType(View, MyBandedGridView)
			If myView.GetGroupFooterRowCount() <= 0 Then
				Return 0
			End If
			Return MyBase.CalcGroupFooterHeight() * myView.GetGroupFooterRowCount()
		End Function
		Protected Overrides Function GetMaxColumnFooterCount() As Integer
			Return (CType(View, MyBandedGridView)).GetGroupFooterRowCount()
		End Function
		Protected Overrides Sub CalcRowCellsFooterInfo(ByVal fi As GridRowFooterInfo, ByVal ri As GridRowInfo)
			AddColumnsInfo(fi.RowHandle)
			MyBase.CalcRowCellsFooterInfo(fi, ri)
			ChangeDisplayText(fi)
			RemoveColumnsInfo()
		End Sub
		Private Sub AddColumnsInfo(ByVal rowHandle As Integer)
            rowHandle = If(rowHandle >= 0, -1, rowHandle)
            Dim groupSummary = View.GetGroupSummaryValues(rowHandle)
            Dim myGroupSummaryList = New List(Of DictionaryEntry)()
            For Each item As DictionaryEntry In groupSummary
                myGroupSummaryList.Add(item)
            Next item
            Dim query = From item In myGroupSummaryList
                Let summary = CType(item.Key, GridGroupSummaryItem)
                Group item By summary.ShowInGroupColumnFooter
                Into Group
            For Each group In query
                For i = 1 To group.Group.Count - 1
                    Dim sourceCInfo = ColumnsInfo(group.ShowInGroupColumnFooter)
                    If sourceCInfo Is Nothing Then
                        Continue For
                    End If
                    Dim cellInfo = New GridColumnInfoArgs(sourceCInfo.Column)
                    cellInfo.Assign(sourceCInfo)
                    cellInfo.Tag = TryCast(group.Group(i).Key, GridGroupSummaryItem)
                    cellInfo.Info.StartRow = i
                    ColumnsInfo.Add(cellInfo)
                Next i
            Next group
		End Sub
		Private Sub AddNewColumnsInfo(ByVal group As List(Of DictionaryEntry), ByVal i As Integer, ByVal initCellInfo As GridColumnInfoArgs)
			Dim cellInfo = New GridColumnInfoArgs(initCellInfo.Column)
			cellInfo.Assign(initCellInfo)
			cellInfo.Tag = TryCast(group(i).Key, GridGroupSummaryItem)
			cellInfo.Info.StartRow = i
			ColumnsInfo.Add(cellInfo)
		End Sub
		Private Sub ChangeDisplayText(ByVal fi As GridRowFooterInfo)
			For Each fci As GridFooterCellInfoArgs In fi.Cells
				Dim rowSummaryItem = View.GetRowSummaryItem(fi.RowHandle, fci.Column)
				If rowSummaryItem.Key Is Nothing Then
					Continue For
				End If
				Dim item = TryCast(fci.ColumnInfo.Tag, GridGroupSummaryItem)
				If item Is Nothing Then
					fci.Visible = If((CType(rowSummaryItem.Key, GridGroupSummaryItem)).SummaryType = Data.SummaryItemType.None, False, True)
					Continue For
				End If
				fci.Visible = If(item.SummaryType = Data.SummaryItemType.None, False, True)
				ChangeFooterCellDisplayText(fi, fci, item)
			Next fci
		End Sub
		Private Sub ChangeFooterCellDisplayText(ByVal fi As GridRowFooterInfo, ByVal fci As GridFooterCellInfoArgs, ByVal item As GridGroupSummaryItem)
			Dim dEntry = GetCustomSummaryItemValue(fi.RowHandle, fci.Column, item)
			fci.Visible = If(item.SummaryType = Data.SummaryItemType.None, False, True)
			fci.Value = dEntry.Value
			fci.DisplayText = (CType(dEntry.Key, GridSummaryItem)).GetDisplayText(dEntry.Value, False)
		End Sub
		Private Function GetCustomSummaryItemValue(ByVal rowHandle As Integer, ByVal column As DevExpress.XtraGrid.Columns.GridColumn, ByVal summaryItem As Object) As DictionaryEntry
			If column Is Nothing Then
				Return New DictionaryEntry()
			End If
			Dim summary = View.GetGroupSummaryValues(rowHandle)
			If summary Is Nothing Then
				Return New DictionaryEntry()
			End If
			For Each dEntry As DictionaryEntry In summary
				Dim item = TryCast(dEntry.Key, GridGroupSummaryItem)
				If item.ShowInGroupColumnFooter IsNot column OrElse item IsNot summaryItem Then
					Continue For
				End If
				Return dEntry
			Next dEntry
			Return New DictionaryEntry()
		End Function
		Private Sub RemoveColumnsInfo()
			Dim count = GetCount()
			If count < 0 Then
				Return
			End If
			Do While ColumnsInfo.Count > count
				ColumnsInfo.RemoveAt(count)
			Loop
		End Sub
		Private Function GetCount() As Integer
			For i = 0 To ColumnsInfo.Count - 1
				Dim item = TryCast(ColumnsInfo(i).Tag, GridGroupSummaryItem)
				If item Is Nothing Then
					Continue For
				End If
				Return i
			Next i
			Return -1
		End Function
		Protected Overrides Sub UpdateRowFooterInfo(ByVal ri As GridRowInfo, ByVal fi As GridRowFooterInfo)
			MyBase.UpdateRowFooterInfo(ri, fi)
			ChangeDisplayText(fi)
		End Sub
	End Class
End Namespace
