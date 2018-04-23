Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid

Namespace DevExpress.S170736
	Public Class MyGridInfoRegistrator
		Inherits BandedGridInfoRegistrator
		Public Overrides Function CreateView(ByVal grid As GridControl) As XtraGrid.Views.Base.BaseView
			Return New MyBandedGridView(TryCast(grid, GridControl))
		End Function
		Public Overrides Function CreateViewInfo(ByVal view As XtraGrid.Views.Base.BaseView) As XtraGrid.Views.Base.ViewInfo.BaseViewInfo
			Return New MyBandedGridViewInfo(CType(view, BandedGridView))
		End Function
		Public Overrides ReadOnly Property ViewName() As String
			Get
				Return "MyBandedGridView"
			End Get
		End Property
		Public Overrides Function CreateHandler(ByVal view As XtraGrid.Views.Base.BaseView) As XtraGrid.Views.Base.Handler.BaseViewHandler
			Return New MyGridHandler(TryCast(view, MyBandedGridView))
		End Function
	End Class
End Namespace
