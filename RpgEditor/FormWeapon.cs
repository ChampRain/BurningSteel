using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.ItemClasses;

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
            using (WeaponDetails frmWeaponDetails = new WeaponDetails())
            {
                frmWeaponDetails.ShowDialog();

                if (frmWeaponDetails.Weapon != null)
                {
                    AddWeapon(frmWeaponDetails.Weapon);
                }
            }
        }

        public void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = lbDetails.SelectedItem.ToString();
                string[] parts = detail.Split(',');
                string entity = (string)parts[0].Trim();

                WeaponData weapon = itemDataManager.WeaponData[entity];
                WeaponData newData = null;

                using (WeaponDetails frmWeaponDetails = new WeaponDetails())
                {
                    frmWeaponDetails.Weapon = weapon;
                    frmWeaponDetails.ShowDialog();

                    if (frmWeaponDetails.Weapon == null)
                    {
                        return;
                    }

                    if (frmWeaponDetails.Weapon.name == entity)
                    {
                        itemDataManager.WeaponData[entity] = frmWeaponDetails.Weapon;
                        FillListBox();
                        return;
                    }

                    newData = frmWeaponDetails.Weapon;
                }

                DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?",
                                                        "New Entry", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return;
                }

                if (itemDataManager.WeaponData.ContainsKey(newData.name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry");
                    return;
                }

                lbDetails.Items.Add(newData);
                ItemManager.WeaponData.Add(newData.name, newData);
            }
        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem;
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                DialogResult result = MessageBox.Show("Are you sure you want to delete " +
                                        entity + "?", "Delete", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    itemDataManager.WeaponData.Remove(entity);

                    if (File.Exists(FormMain.itemPath + @"\Weapon\" + entity + ".xml"))
                    {
                        File.Delete(FormMain.itemPath + @"\Weapon\" + entity + ".xml");
                    }
                }
            }
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.itemDataManager.WeaponData.Keys)
            {
                lbDetails.Items.Add(FormDetails.itemDataManager.WeaponData[s]);
            }
        }

        private void AddWeapon(WeaponData data)
        {
            if (FormDetails.itemDataManager.WeaponData.ContainsKey(data.name))
            {
                DialogResult result = MessageBox.Show(data.name + "already exists. Overwrite it?",
                                                      "Existing Weapon", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return;
                }

                itemDataManager.WeaponData[data.name] = data;
                FillListBox();
                return;
            }

            itemDataManager.WeaponData.Add(data.name, data);
            lbDetails.Items.Add(data);
        }

        private void Form_Close(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }
    }
}
