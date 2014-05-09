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
    public partial class ArmorDetails : Form
    {
        private Armor armor;

        public Armor Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        public ArmorDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form_Load);
            btnOk.Click += new EventHandler(Ok_Click);
            btnCancel.Click += new EventHandler(Cancel_Click);
        }

        public void Form_Load(object sender, EventArgs e)
        {
        }

        public void Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
