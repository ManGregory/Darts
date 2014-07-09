namespace DartsWin
{
    partial class GameSettingsForm
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
            this.pnlGameRules = new Telerik.WinControls.UI.RadPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cmbGameRule = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.pnlControls = new Telerik.WinControls.UI.RadPanel();
            this.btnBeginGame = new Telerik.WinControls.UI.RadButton();
            this.pnlPlayers = new Telerik.WinControls.UI.RadPanel();
            this.gridMembers = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGameRules)).BeginInit();
            this.pnlGameRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGameRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGameRule.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGameRule.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControls)).BeginInit();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBeginGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPlayers)).BeginInit();
            this.pnlPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMembers.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGameRules
            // 
            this.pnlGameRules.Controls.Add(this.radLabel1);
            this.pnlGameRules.Controls.Add(this.cmbGameRule);
            this.pnlGameRules.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGameRules.Location = new System.Drawing.Point(0, 0);
            this.pnlGameRules.Name = "pnlGameRules";
            this.pnlGameRules.Size = new System.Drawing.Size(244, 31);
            this.pnlGameRules.TabIndex = 0;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 7);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(56, 18);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Тип игры:";
            // 
            // cmbGameRule
            // 
            // 
            // cmbGameRule.NestedRadGridView
            // 
            this.cmbGameRule.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.cmbGameRule.EditorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbGameRule.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbGameRule.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.cmbGameRule.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.cmbGameRule.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.cmbGameRule.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.cmbGameRule.EditorControl.MasterTemplate.EnableGrouping = false;
            this.cmbGameRule.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.cmbGameRule.EditorControl.Name = "NestedRadGridView";
            this.cmbGameRule.EditorControl.ReadOnly = true;
            this.cmbGameRule.EditorControl.ShowGroupPanel = false;
            this.cmbGameRule.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.cmbGameRule.EditorControl.TabIndex = 0;
            this.cmbGameRule.Location = new System.Drawing.Point(74, 5);
            this.cmbGameRule.Name = "cmbGameRule";
            this.cmbGameRule.Size = new System.Drawing.Size(159, 20);
            this.cmbGameRule.TabIndex = 1;
            this.cmbGameRule.TabStop = false;
            this.cmbGameRule.SelectedIndexChanged += new System.EventHandler(this.cmbGameRule_SelectedIndexChanged);
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnBeginGame);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControls.Location = new System.Drawing.Point(0, 157);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(244, 25);
            this.pnlControls.TabIndex = 1;
            // 
            // btnBeginGame
            // 
            this.btnBeginGame.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBeginGame.Location = new System.Drawing.Point(147, 0);
            this.btnBeginGame.Name = "btnBeginGame";
            this.btnBeginGame.Size = new System.Drawing.Size(97, 25);
            this.btnBeginGame.TabIndex = 2;
            this.btnBeginGame.Text = "Начать игру";
            this.btnBeginGame.Click += new System.EventHandler(this.btnBeginGame_Click);
            // 
            // pnlPlayers
            // 
            this.pnlPlayers.Controls.Add(this.gridMembers);
            this.pnlPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlayers.Location = new System.Drawing.Point(0, 31);
            this.pnlPlayers.Name = "pnlPlayers";
            this.pnlPlayers.Size = new System.Drawing.Size(244, 126);
            this.pnlPlayers.TabIndex = 2;
            // 
            // gridMembers
            // 
            this.gridMembers.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditOnEnter;
            this.gridMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMembers.Location = new System.Drawing.Point(0, 0);
            // 
            // gridMembers
            // 
            this.gridMembers.MasterTemplate.EnableFiltering = true;
            this.gridMembers.Name = "gridMembers";
            this.gridMembers.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.EnterMovesToNextCell;
            this.gridMembers.Size = new System.Drawing.Size(244, 126);
            this.gridMembers.TabIndex = 2;
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 182);
            this.Controls.Add(this.pnlPlayers);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlGameRules);
            this.Name = "GameSettingsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки игры";
            ((System.ComponentModel.ISupportInitialize)(this.pnlGameRules)).EndInit();
            this.pnlGameRules.ResumeLayout(false);
            this.pnlGameRules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGameRule.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGameRule.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGameRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControls)).EndInit();
            this.pnlControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBeginGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPlayers)).EndInit();
            this.pnlPlayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMembers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel pnlGameRules;
        private Telerik.WinControls.UI.RadPanel pnlControls;
        private Telerik.WinControls.UI.RadPanel pnlPlayers;
        private Telerik.WinControls.UI.RadMultiColumnComboBox cmbGameRule;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnBeginGame;
        private Telerik.WinControls.UI.RadGridView gridMembers;
    }
}