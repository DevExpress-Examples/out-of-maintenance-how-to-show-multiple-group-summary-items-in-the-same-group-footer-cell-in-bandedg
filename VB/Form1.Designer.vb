Imports Microsoft.VisualBasic
Imports System
Namespace DevExpress.S170736
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.myGridCtrl1 = New DevExpress.S170736.MyGridCtrl()
			Me.myBandedGridView1 = New DevExpress.S170736.MyBandedGridView()
			Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
			Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
			Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
			Me.bandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
			Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
			Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
			Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
			CType(Me.myGridCtrl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.myBandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.bandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' myGridCtrl1
			' 
			Me.myGridCtrl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.myGridCtrl1.Location = New System.Drawing.Point(0, 0)
			Me.myGridCtrl1.MainView = Me.myBandedGridView1
			Me.myGridCtrl1.Name = "myGridCtrl1"
			Me.myGridCtrl1.Size = New System.Drawing.Size(617, 349)
			Me.myGridCtrl1.TabIndex = 0
			Me.myGridCtrl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.myBandedGridView1, Me.bandedGridView1})
			' 
			' myBandedGridView1
			' 
			Me.myBandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() { Me.gridBand1})
			Me.myBandedGridView1.GridControl = Me.myGridCtrl1
			Me.myBandedGridView1.Name = "myBandedGridView1"
			' 
			' gridBand1
			' 
			Me.gridBand1.Caption = "Main band"
			Me.gridBand1.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() { Me.gridBand2, Me.gridBand3})
			Me.gridBand1.Name = "gridBand1"
			Me.gridBand1.VisibleIndex = 0
			Me.gridBand1.Width = 140
			' 
			' gridBand2
			' 
			Me.gridBand2.Caption = "The sub-band1"
			Me.gridBand2.Name = "gridBand2"
			Me.gridBand2.VisibleIndex = 0
			' 
			' gridBand3
			' 
			Me.gridBand3.Caption = "The sub-band2"
			Me.gridBand3.Name = "gridBand3"
			Me.gridBand3.VisibleIndex = 1
			' 
			' bandedGridView1
			' 
			Me.bandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() { Me.gridBand4})
			Me.bandedGridView1.GridControl = Me.myGridCtrl1
			Me.bandedGridView1.Name = "bandedGridView1"
			' 
			' gridBand4
			' 
			Me.gridBand4.Caption = "Main band"
			Me.gridBand4.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() { Me.gridBand5, Me.gridBand6})
			Me.gridBand4.Name = "gridBand4"
			Me.gridBand4.VisibleIndex = 0
			Me.gridBand4.Width = 140
			' 
			' gridBand5
			' 
			Me.gridBand5.Caption = "gridBand2"
			Me.gridBand5.Name = "gridBand5"
			Me.gridBand5.VisibleIndex = 0
			' 
			' gridBand6
			' 
			Me.gridBand6.Caption = "gridBand3"
			Me.gridBand6.Name = "gridBand6"
			Me.gridBand6.VisibleIndex = 1
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(617, 349)
			Me.Controls.Add(Me.myGridCtrl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.myGridCtrl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.myBandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.bandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private myGridCtrl1 As MyGridCtrl
		Private myBandedGridView1 As MyBandedGridView
		Private bandedGridView1 As XtraGrid.Views.BandedGrid.BandedGridView
		Private gridBand4 As XtraGrid.Views.BandedGrid.GridBand
		Private gridBand5 As XtraGrid.Views.BandedGrid.GridBand
		Private gridBand6 As XtraGrid.Views.BandedGrid.GridBand
		Private gridBand1 As XtraGrid.Views.BandedGrid.GridBand
		Private gridBand2 As XtraGrid.Views.BandedGrid.GridBand
		Private gridBand3 As XtraGrid.Views.BandedGrid.GridBand

	End Class
End Namespace

