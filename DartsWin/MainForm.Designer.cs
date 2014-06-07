namespace DartsWin
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.pnlCatalogs = new Telerik.WinControls.UI.RadPanel();
            this.btnUsers = new Telerik.WinControls.UI.RadButton();
            this.btnTeams = new Telerik.WinControls.UI.RadButton();
            this.gridGames = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCatalogs)).BeginInit();
            this.pnlCatalogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGames.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCatalogs
            // 
            this.pnlCatalogs.Controls.Add(this.btnTeams);
            this.pnlCatalogs.Controls.Add(this.btnUsers);
            this.pnlCatalogs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCatalogs.Location = new System.Drawing.Point(0, 206);
            this.pnlCatalogs.Name = "pnlCatalogs";
            this.pnlCatalogs.Size = new System.Drawing.Size(442, 38);
            this.pnlCatalogs.TabIndex = 0;
            // 
            // btnUsers
            // 
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUsers.Location = new System.Drawing.Point(0, 0);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(97, 38);
            this.btnUsers.TabIndex = 0;
            this.btnUsers.Text = "Игроки";
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnTeams
            // 
            this.btnTeams.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTeams.Location = new System.Drawing.Point(97, 0);
            this.btnTeams.Name = "btnTeams";
            this.btnTeams.Size = new System.Drawing.Size(97, 38);
            this.btnTeams.TabIndex = 1;
            this.btnTeams.Text = "Команды";
            this.btnTeams.Click += new System.EventHandler(this.btnTeams_Click);
            // 
            // gridGames
            // 
            this.gridGames.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditOnEnter;
            this.gridGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGames.Location = new System.Drawing.Point(0, 0);
            // 
            // gridGames
            // 
            this.gridGames.MasterTemplate.EnableFiltering = true;
            this.gridGames.Name = "gridGames";
            this.gridGames.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.EnterMovesToNextCell;
            this.gridGames.Size = new System.Drawing.Size(442, 206);
            this.gridGames.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 244);
            this.Controls.Add(this.gridGames);
            this.Controls.Add(this.pnlCatalogs);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCatalogs)).EndInit();
            this.pnlCatalogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGames.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.UI.RadPanel pnlCatalogs;
        private Telerik.WinControls.UI.RadButton btnUsers;
        private Telerik.WinControls.UI.RadButton btnTeams;
        private Telerik.WinControls.UI.RadGridView gridGames;
    }
}

