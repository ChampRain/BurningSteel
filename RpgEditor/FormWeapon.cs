using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RpgEditor
{
    public partial class FormWeapon : FormDetails
    {
        public FormWeapon()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
        }

        public void btnEdit_Click(object sender, EventArgs e)
        {
        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.itemDataManager.WeaponData.Keys)
            {
                lbDetails.Items.Add(FormDetails.itemDataManager.WeaponData[s]);
            }
        }
    }
}
