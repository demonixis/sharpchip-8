namespace SharpChip8.WinForms.Debugger
{
    partial class DisassemblerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisassemblerWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemMenuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numérotationDesLignesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuWithLine = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuWithoutLine = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxASM = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.affichageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(394, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMenuSave,
            this.toolStripSeparator1,
            this.itemMenuQuit});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fichierToolStripMenuItem.Text = "File";
            // 
            // itemMenuSave
            // 
            this.itemMenuSave.Name = "itemMenuSave";
            this.itemMenuSave.Size = new System.Drawing.Size(152, 22);
            this.itemMenuSave.Text = "Save";
            this.itemMenuSave.Click += new System.EventHandler(this.itemMenuSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // itemMenuQuit
            // 
            this.itemMenuQuit.Name = "itemMenuQuit";
            this.itemMenuQuit.Size = new System.Drawing.Size(152, 22);
            this.itemMenuQuit.Text = "Close";
            this.itemMenuQuit.Click += new System.EventHandler(this.itemMenuQuit_Click);
            // 
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numérotationDesLignesToolStripMenuItem});
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            this.affichageToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.affichageToolStripMenuItem.Text = "Display";
            // 
            // numérotationDesLignesToolStripMenuItem
            // 
            this.numérotationDesLignesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMenuWithLine,
            this.itemMenuWithoutLine});
            this.numérotationDesLignesToolStripMenuItem.Name = "numérotationDesLignesToolStripMenuItem";
            this.numérotationDesLignesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.numérotationDesLignesToolStripMenuItem.Text = "Line numbers";
            // 
            // itemMenuWithLine
            // 
            this.itemMenuWithLine.Checked = true;
            this.itemMenuWithLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemMenuWithLine.Name = "itemMenuWithLine";
            this.itemMenuWithLine.Size = new System.Drawing.Size(152, 22);
            this.itemMenuWithLine.Text = "Yes";
            this.itemMenuWithLine.Click += new System.EventHandler(this.itemMenuWithLine_Click);
            // 
            // itemMenuWithoutLine
            // 
            this.itemMenuWithoutLine.Name = "itemMenuWithoutLine";
            this.itemMenuWithoutLine.Size = new System.Drawing.Size(152, 22);
            this.itemMenuWithoutLine.Text = "No";
            this.itemMenuWithoutLine.Click += new System.EventHandler(this.itemMenuWithoutLine_Click);
            // 
            // richTextBoxASM
            // 
            this.richTextBoxASM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxASM.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxASM.Location = new System.Drawing.Point(0, 27);
            this.richTextBoxASM.Name = "richTextBoxASM";
            this.richTextBoxASM.Size = new System.Drawing.Size(394, 422);
            this.richTextBoxASM.TabIndex = 2;
            this.richTextBoxASM.Text = "";
            // 
            // DisassemblerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 449);
            this.Controls.Add(this.richTextBoxASM);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DisassemblerWindow";
            this.Text = "Desassembler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMenuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itemMenuQuit;
        private System.Windows.Forms.RichTextBox richTextBoxASM;
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numérotationDesLignesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMenuWithLine;
        private System.Windows.Forms.ToolStripMenuItem itemMenuWithoutLine;
    }
}