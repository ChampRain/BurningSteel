namespace RpgEditor
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitGameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.classMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.weaponMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.armorMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.shieldMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameMenu,
            this.classMenu,
            this.itemMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(738, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameMenu
            // 
            this.gameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameMenu,
            this.saveGameMenu,
            this.loadGameMenu,
            this.toolStripSeparator1,
            this.exitGameMenu});
            this.gameMenu.Name = "gameMenu";
            this.gameMenu.Size = new System.Drawing.Size(50, 20);
            this.gameMenu.Text = "&Game";
            // 
            // newGameMenu
            // 
            this.newGameMenu.Name = "newGameMenu";
            this.newGameMenu.Size = new System.Drawing.Size(152, 22);
            this.newGameMenu.Text = "&New Game";
            // 
            // saveGameMenu
            // 
            this.saveGameMenu.Name = "saveGameMenu";
            this.saveGameMenu.Size = new System.Drawing.Size(152, 22);
            this.saveGameMenu.Text = "&Save Game";
            // 
            // loadGameMenu
            // 
            this.loadGameMenu.Name = "loadGameMenu";
            this.loadGameMenu.Size = new System.Drawing.Size(152, 22);
            this.loadGameMenu.Text = "&Load Game";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitGameMenu
            // 
            this.exitGameMenu.Name = "exitGameMenu";
            this.exitGameMenu.Size = new System.Drawing.Size(152, 22);
            this.exitGameMenu.Text = "E&xit Game";
            // 
            // classMenu
            // 
            this.classMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weaponMenu,
            this.armorMenu,
            this.shieldMenu});
            this.classMenu.Enabled = false;
            this.classMenu.Name = "classMenu";
            this.classMenu.Size = new System.Drawing.Size(57, 20);
            this.classMenu.Text = "&Classes";
            // 
            // weaponMenu
            // 
            this.weaponMenu.Name = "weaponMenu";
            this.weaponMenu.Size = new System.Drawing.Size(123, 22);
            this.weaponMenu.Text = "Weapons";
            // 
            // armorMenu
            // 
            this.armorMenu.Name = "armorMenu";
            this.armorMenu.Size = new System.Drawing.Size(123, 22);
            this.armorMenu.Text = "Armor";
            // 
            // shieldMenu
            // 
            this.shieldMenu.Name = "shieldMenu";
            this.shieldMenu.Size = new System.Drawing.Size(123, 22);
            this.shieldMenu.Text = "Shields";
            // 
            // itemMenu
            // 
            this.itemMenu.Enabled = false;
            this.itemMenu.Name = "itemMenu";
            this.itemMenu.Size = new System.Drawing.Size(43, 20);
            this.itemMenu.Text = "&Item";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 444);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rpg Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameMenu;
        private System.Windows.Forms.ToolStripMenuItem newGameMenu;
        private System.Windows.Forms.ToolStripMenuItem saveGameMenu;
        private System.Windows.Forms.ToolStripMenuItem loadGameMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitGameMenu;
        private System.Windows.Forms.ToolStripMenuItem classMenu;
        private System.Windows.Forms.ToolStripMenuItem weaponMenu;
        private System.Windows.Forms.ToolStripMenuItem armorMenu;
        private System.Windows.Forms.ToolStripMenuItem shieldMenu;
        private System.Windows.Forms.ToolStripMenuItem itemMenu;
    }
}

