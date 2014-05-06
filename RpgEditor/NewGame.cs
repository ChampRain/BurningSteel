using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary;

namespace RpgEditor
{
    public partial class NewGame : Form
    {
        private RolePlayingGame rpg;

        public RolePlayingGame RolePlayingGame
        {
            get { return rpg; }
        }

        public NewGame()
        {
            InitializeComponent();
            btnOk.Click += new EventHandler(btnOk_Click);
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbDescription.Text))
            {
                MessageBox.Show("You must enter a name and a description", "Error");
                return;
            }

            rpg = new RolePlayingGame(tbName.Text, tbDescription.Text);

            this.Close();
        }
    }
}
