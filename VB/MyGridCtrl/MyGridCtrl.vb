Imports Microsoft.VisualBasic
Imports DevExpress.XtraGrid
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace DevExpress.S170736
	Public Class MyGridCtrl
		Inherits GridControl
		Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As XtraGrid.Registrator.InfoCollection)
			MyBase.RegisterAvailableViewsCore(collection)
			collection.Add(New MyGridInfoRegistrator())
		End Sub
		Protected Overrides Function CreateDefaultView() As XtraGrid.Views.Base.BaseView
			Return CreateView("MyBandedGridView")
		End Function
	End Class
End Namespace
