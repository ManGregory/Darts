namespace DartsWin
{
    partial class GridPlayerPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTeamName = new Telerik.WinControls.UI.RadPanel();
            this.pnlTeamStatus = new Telerik.WinControls.UI.RadPanel();
            this.pnlGrid = new Telerik.WinControls.UI.RadPanel();
            this.gridTeam = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTeamName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTeamStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeam.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTeamName
            // 
            this.pnlTeamName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTeamName.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pnlTeamName.Location = new System.Drawing.Point(0, 0);
            this.pnlTeamName.Name = "pnlTeamName";
            this.pnlTeamName.Size = new System.Drawing.Size(195, 50);
            this.pnlTeamName.TabIndex = 0;
            this.pnlTeamName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTeamStatus
            // 
            this.pnlTeamStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTeamStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pnlTeamStatus.Location = new System.Drawing.Point(0, 193);
            this.pnlTeamStatus.Name = "pnlTeamStatus";
            this.pnlTeamStatus.Size = new System.Drawing.Size(195, 65);
            this.pnlTeamStatus.TabIndex = 1;
            this.pnlTeamStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gridTeam);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 50);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(195, 143);
            this.pnlGrid.TabIndex = 2;
            this.pnlGrid.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridTeam
            // 
            this.gridTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTeam.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridTeam.Location = new System.Drawing.Point(0, 0);
            // 
            // gridTeam
            // 
            this.gridTeam.MasterTemplate.AllowAddNewRow = false;
            this.gridTeam.MasterTemplate.AllowColumnReorder = false;
            this.gridTeam.Name = "gridTeam";
            this.gridTeam.ReadOnly = true;
            this.gridTeam.Size = new System.Drawing.Size(195, 143);
            this.gridTeam.TabIndex = 0;
            // 
            // GridPlayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTeamStatus);
            this.Controls.Add(this.pnlTeamName);
            this.Name = "GridPlayerPanel";
            this.Size = new System.Drawing.Size(195, 258);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTeamName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTeamStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTeam.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel pnlTeamName;
        private Telerik.WinControls.UI.RadPanel pnlTeamStatus;
        private Telerik.WinControls.UI.RadPanel pnlGrid;
        private Telerik.WinControls.UI.RadGridView gridTeam;
    }
}
