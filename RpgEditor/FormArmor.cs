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
    public partial class FormArmor : FormDetails
    {
        public FormArmor()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            using (ArmorDetails frmArmorDetails = new ArmorDetails())
            {
                frmArmorDetails.ShowDialog();

                if (frmArmorDetails.Armor != null)
                {
                    AddArmor(frmArmorDetails.Armor);
                }
            }
        }

        public void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = Convert.ToString(lbDetails.SelectedItem);
                string[] parts = detail.Split(',');
                string entity = (string)parts[0].Trim();

                ArmorData armor = itemDataManager.ArmorData[entity];
                ArmorData newData = null;

                using (ArmorDetails frmArmorDetails = new ArmorDetails())
                {
                    frmArmorDetails.Armor = armor;
                    frmArmorDetails.ShowDialog();

                    if (frmArmorDetails.Armor == null)
                    {
                        return;
                    }

                    if (frmArmorDetails.Armor.name == entity)
                    {
                        itemDataManager.ArmorData[entity] = frmArmorDetails.Armor;
                        FillListBox();
                        return;
                    }

                    newData = frmArmorDetails.Armor;
                }

                DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?", 
                                                        "New Entry", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return;
                }

                if (itemDataManager.ArmorData.ContainsKey(newData.name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry");
                    return;
                }

                lbDetails.Items.Add(newData);
                ItemManager.ArmorData.Add(newData.name, newData);
            }
        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = Convert.ToString(lbDetails.SelectedItem);
                string[] parts = detail.Split(',');
                string entity = parts[0].Trim();

                DialogResult result = MessageBox.Show("Are you sure you want to delete " +
                                        entity + "?", "Delete", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    itemDataManager.ArmorData.Remove(entity);

                    if (File.Exists(FormMain.itemPath + @"\Armor\" + entity + ".xml"))
                    {
                        File.Delete(FormMain.itemPath + @"\Armor\" + entity + ".xml");
                    }
                }
            }
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.itemDataManager.ArmorData.Keys)
            {
                lbDetails.Items.Add(FormDetails.itemDataManager.ArmorData[s]);
            }
        }

        private void AddArmor(ArmorData data)
        {
            if (FormDetails.itemDataManager.ArmorData.ContainsKey(data.name))
            {
                DialogResult result = MessageBox.Show(data.name + "already exists. Overwrite it?",
                                                      "Existing Armor", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return;
                }

                itemDataManager.ArmorData[data.name] = data;
                FillListBox();
                return;
            }
           
            itemDataManager.ArmorData.Add(data.name, data);
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
