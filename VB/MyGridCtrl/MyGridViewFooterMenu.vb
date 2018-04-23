Imports Microsoft.VisualBasic
Imports DevExpress.XtraGrid.Menu
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid.ViewInfo

Namespace DevExpress.S170736
	Public Class MyGridViewFooterMenu
		Inherits GridViewFooterMenu
		Public Sub New(ByVal view As GridView)
			MyBase.New(view)
		End Sub
		Public Overrides Sub Init(ByVal info As Object)
			Dim hi = TryCast(info, BandedGridHitInfo)
			MyBase.Init(info)
			Dim rowSummaryItem = View.GetRowSummaryItem(hi.RowHandle, hi.Column)
			SetSummaryItem(TryCast(rowSummaryItem.Key, GridGroupSummaryItem))
			If hi.HitTest <> BandedGridHitTest.RowFooter Then
				Return
			End If
			Dim item = TryCast(hi.FooterCell.ColumnInfo.Tag, GridGroupSummaryItem)
			SetSummaryItem(item)
		End Sub
		Private Sub SetSummaryItem(ByVal item As GridGroupSummaryItem)
			If item Is Nothing Then
				Return
			End If
			SummaryItem = item
			CreateItems()
		End Sub
	End Class
End Namespace
