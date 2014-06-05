namespace DartsWin
{
    partial class TeamsForm
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
            this.gridTeams = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTeams
            // 
            this.gridTeams.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditOnEnter;
            this.gridTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTeams.Location = new System.Drawing.Point(0, 0);
            // 
            // gridTeams
            // 
            this.gridTeams.MasterTemplate.EnableFiltering = true;
            this.gridTeams.MasterTemplate.ShowFilteringRow = false;
            this.gridTeams.MasterTemplate.ShowHeaderCellButtons = true;
            this.gridTeams.Name = "gridTeams";
            this.gridTeams.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.EnterMovesToNextCell;
            this.gridTeams.ShowHeaderCellButtons = true;
            this.gridTeams.Size = new System.Drawing.Size(292, 270);
            this.gridTeams.TabIndex = 1;
            // 
            // TeamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 270);
            this.Controls.Add(this.gridTeams);
            this.Name = "TeamsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Команды";
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridTeams;
    }
}