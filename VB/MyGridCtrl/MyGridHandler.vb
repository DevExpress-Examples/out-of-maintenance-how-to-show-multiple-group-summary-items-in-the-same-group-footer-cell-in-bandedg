Imports Microsoft.VisualBasic
Imports DevExpress.XtraGrid.Views.Grid.Handler
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid.Views.Grid

Namespace DevExpress.S170736
	Public Class MyGridHandler
		Inherits GridHandler
		Public Sub New(ByVal gridView As GridView)
			MyBase.New(gridView)
		End Sub
		Protected Overrides Function CreateGridViewFooterMenu(ByVal gridView As GridView) As XtraGrid.Menu.GridViewFooterMenu
			Return New MyGridViewFooterMenu(gridView)
		End Function
	End Class
End Namespace
