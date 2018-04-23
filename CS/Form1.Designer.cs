namespace DevExpress.S170736 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.myGridCtrl1 = new DevExpress.S170736.MyGridCtrl();
            this.myBandedGridView1 = new DevExpress.S170736.MyBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.myGridCtrl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // myGridCtrl1
            // 
            this.myGridCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGridCtrl1.Location = new System.Drawing.Point(0, 0);
            this.myGridCtrl1.MainView = this.myBandedGridView1;
            this.myGridCtrl1.Name = "myGridCtrl1";
            this.myGridCtrl1.Size = new System.Drawing.Size(617, 349);
            this.myGridCtrl1.TabIndex = 0;
            this.myGridCtrl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.myBandedGridView1,
            this.bandedGridView1});
            // 
            // myBandedGridView1
            // 
            this.myBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.myBandedGridView1.GridControl = this.myGridCtrl1;
            this.myBandedGridView1.Name = "myBandedGridView1";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Main band";
            this.gridBand1.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand3});
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 140;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "The sub-band1";
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "The sub-band2";
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 1;
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand4});
            this.bandedGridView1.GridControl = this.myGridCtrl1;
            this.bandedGridView1.Name = "bandedGridView1";
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "Main band";
            this.gridBand4.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand5,
            this.gridBand6});
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 0;
            this.gridBand4.Width = 140;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "gridBand2";
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 0;
            // 
            // gridBand6
            // 
            this.gridBand6.Caption = "gridBand3";
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 349);
            this.Controls.Add(this.myGridCtrl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myGridCtrl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyGridCtrl myGridCtrl1;
        private MyBandedGridView myBandedGridView1;
        private XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private XtraGrid.Views.BandedGrid.GridBand gridBand3;

    }
}

