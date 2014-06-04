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
    public partial class FormKeyDetails : Form
    {
        private KeyData key;

        public KeyData Key
        {
            get { return key; }
            set { key = value; }
        }

        public FormKeyDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form_Load);
            this.FormClosing += new FormClosingEventHandler(Form_Close);

            btnOK.Click += new EventHandler(OK_Click);
            btnCancel.Click += new EventHandler(Cancel_Click);
        }

        public void Form_Load(object sender, EventArgs e)
        {
            if (key != null)
            {
                tbName.Text = key.Name;
                tbType.Text = key.Type;
            }
        }

        public void Form_Close(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        public void OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the item");
                return;
            }

            key = new KeyData();
            key.Name = tbName.Text;
            key.Type = tbType.Text;

            this.FormClosing -= Form_Close;
            this.Close();
        }

        public void Cancel_Click(object sender, EventArgs e)
        {
            key = null;
            this.FormClosing -= Form_Close;
            this.Close();
        }
    }
}
