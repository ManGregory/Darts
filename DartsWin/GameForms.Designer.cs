namespace DartsWin
{
    partial class GameForm
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
            this.grpRule = new Telerik.WinControls.UI.RadGroupBox();
            this.txtRuleDescription = new Telerik.WinControls.UI.RadTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpRule)).BeginInit();
            this.grpRule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuleDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRule
            // 
            this.grpRule.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.grpRule.Controls.Add(this.txtRuleDescription);
            this.grpRule.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRule.HeaderText = "Правила";
            this.grpRule.Location = new System.Drawing.Point(0, 0);
            this.grpRule.Name = "grpRule";
            this.grpRule.Size = new System.Drawing.Size(646, 116);
            this.grpRule.TabIndex = 0;
            this.grpRule.Text = "Правила";
            // 
            // txtRuleDescription
            // 
            this.txtRuleDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRuleDescription.Location = new System.Drawing.Point(2, 18);
            this.txtRuleDescription.Multiline = true;
            this.txtRuleDescription.Name = "txtRuleDescription";
            this.txtRuleDescription.Size = new System.Drawing.Size(642, 96);
            this.txtRuleDescription.TabIndex = 0;
            this.txtRuleDescription.UseCompatibleTextRendering = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 312);
            this.Controls.Add(this.grpRule);
            this.Name = "GameForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.grpRule)).EndInit();
            this.grpRule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRuleDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox grpRule;
        private Telerik.WinControls.UI.RadTextBoxControl txtRuleDescription;
    }
}
