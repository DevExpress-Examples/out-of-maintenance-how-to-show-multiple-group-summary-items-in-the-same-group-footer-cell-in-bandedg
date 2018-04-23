Imports Microsoft.VisualBasic
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Columns

Namespace DevExpress.S170736
    Public Class MyBandedGridView
        Inherits BandedGridView
        Public Sub New(ByVal ownerGrid As GridControl)
            MyBase.New(ownerGrid)
        End Sub
        Public Sub New()
        End Sub
        Protected Overrides ReadOnly Property ViewName() As String
            Get
                Return "MyBandedGridView"
            End Get
        End Property
        Public Function GetGroupFooterRowCount() As Integer
            If IsDesignMode Then
                Return 0
            End If
            Dim footerRowCount = GetFooterRowCount()
            If footerRowCount.Count = 0 Then
                Return 0
            End If
            Return footerRowCount.Max(Function(kvp) kvp.Value)
        End Function
        Private Function GetFooterRowCount() As Dictionary(Of BandedGridColumn, Integer)
            Dim columnFooterRowCount = New Dictionary(Of BandedGridColumn, Integer)()
            For Each summary As GridGroupSummaryItem In GroupSummary
                Dim column = TryCast(summary.ShowInGroupColumnFooter, BandedGridColumn)
                If column Is Nothing Then
                    Continue For
                End If
                If columnFooterRowCount.ContainsKey(column) Then
                    columnFooterRowCount(column) += 1
                End If
                If ((Not columnFooterRowCount.ContainsKey(column))) Then
                    columnFooterRowCount.Add(column, 1)
                End If
            Next summary
            Return columnFooterRowCount
        End Function
        Protected Overrides Function SynchronizeSummary(ByVal gridSum As System.Collections.IList, ByVal summary As Data.SummaryItemCollection) As List(Of SummaryItem)
            Dim gridSumCollection = TryCast(gridSum, GridGroupSummaryItemCollection)
            If gridSumCollection Is Nothing Then
                Return MyBase.SynchronizeSummary(gridSum, summary)
            End If
            Dim myGridSumCollection = New List(Of GridGroupSummaryItem)()
            Dim groupFooterRowCount = GetGroupFooterRowCount()
            MyGridSumCollectionAddSummary(gridSumCollection, myGridSumCollection)
            Dim query = From item In gridSumCollection
                        Let summ = CType(item, GridGroupSummaryItem)
                        Group item By summ.ShowInGroupColumnFooter
                        Into Group

            Dim tempSummaryItemList = New List(Of GridGroupSummaryItem)()
            For Each group In query
                Dim summaryItem As GridGroupSummaryItem = Nothing
                Dim showInGroupColumnFooter As GridColumn = Nothing
                Dim fieldName = String.Empty
                For i = 0 To groupFooterRowCount - 1
                    Try
                        summaryItem = group.Group(i)
                    Catch
                        summaryItem = Nothing
                    End Try
                    If summaryItem IsNot Nothing Then
                        fieldName = summaryItem.FieldName
                        showInGroupColumnFooter = summaryItem.ShowInGroupColumnFooter
                        Continue For
                    End If
                    If fieldName IsNot String.Empty AndAlso showInGroupColumnFooter IsNot Nothing Then
                        summaryItem = New GridGroupSummaryItem() With {.SummaryType = SummaryItemType.None, .ShowInGroupColumnFooter = showInGroupColumnFooter, .FieldName = fieldName}
                        tempSummaryItemList.Add(summaryItem)
                    End If
                Next i
            Next group
            AddEmptySummaryColumn(groupFooterRowCount, tempSummaryItemList)
            GridSumCollectionAddSummaries(gridSumCollection, tempSummaryItemList)
            MyBase.SynchronizeSummary(gridSum, summary)
        End Function
        Private Sub AddEmptySummaryColumn(ByVal groupFooterRowCount As Integer, ByVal tempSummaryItemList As List(Of GridGroupSummaryItem))
            Dim footerRowCount = GetFooterRowCount()
            For Each col As BandedGridColumn In Columns
                If footerRowCount.ContainsKey(col) Then
                    Continue For
                End If
                CreateEmptySummaries(col, tempSummaryItemList, groupFooterRowCount)
            Next col
        End Sub
        Private Sub CreateEmptySummaries(ByVal col As BandedGridColumn, ByVal tempSummaryItemList As List(Of GridGroupSummaryItem), ByVal groupFooterRowCount As Integer)
            Dim summaryItem As GridGroupSummaryItem = Nothing
            Dim showInGroupColumnFooter As GridColumn = Nothing
            Dim fieldName = String.Empty
            For i = 0 To groupFooterRowCount - 2
                showInGroupColumnFooter = col
                fieldName = col.FieldName
                summaryItem = New GridGroupSummaryItem() With {.SummaryType = SummaryItemType.None, .ShowInGroupColumnFooter = showInGroupColumnFooter, .FieldName = fieldName}
                tempSummaryItemList.Add(summaryItem)
            Next i
        End Sub
        Private Sub GridSumCollectionAddSummaries(ByVal gridSumCollection As GridGroupSummaryItemCollection, ByVal tempSummaryItemList As List(Of GridGroupSummaryItem))
            If tempSummaryItemList.Count > 0 Then
                gridSumCollection.AddRange(tempSummaryItemList.ToArray())
            End If
        End Sub
        Private Sub MyGridSumCollectionAddSummary(ByVal gridSumCollection As GridGroupSummaryItemCollection, ByVal myGridSumCollection As List(Of GridGroupSummaryItem))
            For Each summaryItem As GridGroupSummaryItem In gridSumCollection
                myGridSumCollection.Add(summaryItem)
            Next summaryItem
        End Sub
    End Class
End Namespace
