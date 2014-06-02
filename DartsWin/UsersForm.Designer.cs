namespace DartsWin
{
    partial class UsersForm
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
            this.pnlData = new Telerik.WinControls.UI.RadPanel();
            this.gridUsers = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlData)).BeginInit();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.gridUsers);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(528, 279);
            this.pnlData.TabIndex = 1;
            // 
            // gridUsers
            // 
            this.gridUsers.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditOnEnter;
            this.gridUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUsers.EnableCustomFiltering = true;
            this.gridUsers.Location = new System.Drawing.Point(0, 0);
            // 
            // gridUsers
            // 
            this.gridUsers.MasterTemplate.EnableCustomFiltering = true;
            this.gridUsers.MasterTemplate.EnableFiltering = true;
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.EnterMovesToNextCell;
            this.gridUsers.Size = new System.Drawing.Size(528, 279);
            this.gridUsers.TabIndex = 0;
            this.gridUsers.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridUsers_CellEndEdit);
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 279);
            this.Controls.Add(this.pnlData);
            this.Name = "UsersForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Игроки";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.pnlData)).EndInit();
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel pnlData;
        private Telerik.WinControls.UI.RadGridView gridUsers;
    }
}
