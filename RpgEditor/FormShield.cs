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
    public partial class FormShield : FormDetails
    {
        public FormShield()
        {
            InitializeComponent();
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            using (ShieldDetails frmShieldDetails = new ShieldDetails())
            {
                frmShieldDetails.ShowDialog();

                if (frmShieldDetails.Shield != null)
                {
                    AddShield(frmShieldDetails.Shield);
                }
            }
        }

        public void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = (string)lbDetails.SelectedItem;
                string[] parts = detail.Split(',');
                string entity = (string)parts[0].Trim();

                ShieldData shield = itemDataManager.ShieldData[entity];
                ShieldData newData = null;

                using (ShieldDetails frmShieldDetails = new ShieldDetails())
                {
                    frmShieldDetails.Shield = shield;
                    frmShieldDetails.ShowDialog();

                    if (frmShieldDetails.Shield == null)
                    {
                        return;
                    }

                    if (frmShieldDetails.Shield.name == entity)
                    {
                        itemDataManager.ShieldData[entity] = frmShieldDetails.Shield;
                        FillListBox();
                        return;
                    }

                    newData = frmShieldDetails.Shield;
                }

                DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?",
                                                        "New Entry", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return;
                }

                if (itemDataManager.ShieldData.ContainsKey(newData.name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry");
                    return;
                }

                lbDetails.Items.Add(newData);
                ItemManager.ShieldData.Add(newData.name, newData);
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
                    itemDataManager.ShieldData.Remove(entity);

                    if (File.Exists(FormMain.itemPath + @"\Shield\" + entity + ".xml"))
                    {
                        File.Delete(FormMain.itemPath + @"\Shield\" + entity + ".xml");
                    }
                }
            }
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.itemDataManager.ShieldData.Keys)
            {
                lbDetails.Items.Add(FormDetails.itemDataManager.ShieldData[s]);
            }
        }

        private void AddShield(ShieldData data)
        {
            if (FormDetails.itemDataManager.ShieldData.ContainsKey(data.name))
            {
                DialogResult result = MessageBox.Show(data.name + "already exists. Overwrite it?",
                                                      "Existing Shield", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return;
                }

                itemDataManager.ShieldData[data.name] = data;
                FillListBox();
                return;
            }

            itemDataManager.ShieldData.Add(data.name, data);
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
