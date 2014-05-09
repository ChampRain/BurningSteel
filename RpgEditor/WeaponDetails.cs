using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class WeaponDetails : Form
    {
        private Weapon weapon;

        private Weapon Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }

        public WeaponDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form_Load);
            btnOk.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        void Form_Load(object sender, EventArgs e)
        {

        }

        void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
