namespace DartsWin
{
    partial class TeamUsers
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridTeamUsers = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeamUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeamUsers.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTeamUsers
            // 
            this.gridTeamUsers.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditOnEnter;
            this.gridTeamUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTeamUsers.Location = new System.Drawing.Point(0, 0);
            // 
            // gridTeamUsers
            // 
            this.gridTeamUsers.MasterTemplate.EnableFiltering = true;
            this.gridTeamUsers.MasterTemplate.ShowFilteringRow = false;
            this.gridTeamUsers.MasterTemplate.ShowHeaderCellButtons = true;
            this.gridTeamUsers.Name = "gridTeamUsers";
            this.gridTeamUsers.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.EnterMovesToNextCell;
            this.gridTeamUsers.ShowHeaderCellButtons = true;
            this.gridTeamUsers.Size = new System.Drawing.Size(292, 270);
            this.gridTeamUsers.TabIndex = 2;
            // 
            // TeamUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 270);
            this.Controls.Add(this.gridTeamUsers);
            this.Name = "TeamUsers";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeamUsers";
            ((System.ComponentModel.ISupportInitialize)(this.gridTeamUsers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeamUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridTeamUsers;
    }
}