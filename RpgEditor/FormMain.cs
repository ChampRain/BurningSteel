using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary;
using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormMain : Form
    {
        private RolePlayingGame rpg;
        private FormClass classForm;
        private FormArmor armorForm;
        private FormWeapon weaponForm;
        private FormShield shieldForm;

        public FormMain()
        {
            InitializeComponent();

            newGameMenu.Click += new EventHandler(newGameMenu_Click);
            loadGameMenu.Click += new EventHandler(loadGameMenu_Click);
            openGameMenu.Click += new EventHandler(openGameMenu_Click);
            exitGameMenu.Click += new EventHandler(exitGameMenu_Click);

            classMenu.Click += new EventHandler(classMenu_Click);
            weaponMenu.Click += new EventHandler(weaponMenu_Click);
            armorMenu.Click += new EventHandler(armorMenu_Click);
            shieldMenu.Click += new EventHandler(shieldMenu_Click);
        }

        public void newGameMenu_Click(object sender, EventArgs e)
        {
            using (NewGame newGame = new NewGame())
            {
                DialogResult result = newGame.ShowDialog();
                if (result == DialogResult.OK && newGame.RolePlayingGame != null)
                {
                    classMenu.Enabled = true;
                    itemMenu.Enabled = true;
                    rpg = newGame.RolePlayingGame;
                }
            }
        }

        public void loadGameMenu_Click(object sender, EventArgs e)
        {
        }

        public void openGameMenu_Click(object sender, EventArgs e)
        {
        }

        public void exitGameMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void classMenu_Click(object sender, EventArgs e)
        {
            if (classForm == null)
            {
                classForm = new FormClass();
                classForm.MdiParent = this;
            }

            classForm.Show();
            classForm.BringToFront();
        }

        public void weaponMenu_Click(object sender, EventArgs e)
        {
            if (weaponForm == null)
            {
                weaponForm = new FormWeapon();
                weaponForm.MdiParent = this;
            }

            weaponForm.Show();
            weaponForm.BringToFront();
        }

        public void armorMenu_Click(object sender, EventArgs e)
        {
            if (armorForm == null)
            {
                armorForm = new FormArmor();
                armorForm.MdiParent = this;
            }

            armorForm.Show();
            armorForm.BringToFront();
        }

        public void shieldMenu_Click(object sender, EventArgs e)
        {
            if (shieldForm == null)
            {
                shieldForm = new FormShield();
                shieldForm.MdiParent = this;
            }

            shieldForm.Show();
            shieldForm.BringToFront();
        }
    }
}
