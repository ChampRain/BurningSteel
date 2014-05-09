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
    public partial class ShieldDetails : Form
    {
        private Shield shield;

        private Shield Sheild
        {
            get { return shield; }
            set { shield = value; }
        }

        public ShieldDetails()
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
