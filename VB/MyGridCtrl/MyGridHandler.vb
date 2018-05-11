Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.BandedGrid.Handler

Namespace DevExpress.S170736
    Public Class MyGridHandler
        Inherits BandedGridHandler
        Public Sub New(ByVal gridView As BandedGridView)
            MyBase.New(gridView)
        End Sub
        Protected Overrides Function CreateGridViewFooterMenu(ByVal gridView As GridView) As XtraGrid.Menu.GridViewFooterMenu
            Return New MyGridViewFooterMenu(gridView)
        End Function
    End Class
End Namespace
