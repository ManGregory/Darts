namespace DartsWin
{
    partial class RulesForm
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
            this.gridRules = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRules.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridRules
            // 
            this.gridRules.AutoSizeRows = true;
            this.gridRules.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditOnEnter;
            this.gridRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRules.Location = new System.Drawing.Point(0, 0);
            // 
            // gridRules
            // 
            this.gridRules.MasterTemplate.EnableFiltering = true;
            this.gridRules.Name = "gridRules";
            this.gridRules.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.EnterMovesToNextCell;
            this.gridRules.Size = new System.Drawing.Size(593, 270);
            this.gridRules.TabIndex = 1;
            // 
            // RulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 270);
            this.Controls.Add(this.gridRules);
            this.Name = "RulesForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Правила игры";
            ((System.ComponentModel.ISupportInitialize)(this.gridRules.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridRules;
    }
}