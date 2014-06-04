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
    public partial class FormKey : FormDetails
    {
        public FormKey()
        {
            InitializeComponent();
 
            btnAdd.Click += new EventHandler(Add_Click);
            btnEdit.Click += new EventHandler(Edit_Click);
            btnDelete.Click += new EventHandler(Delete_Click);
        }

        public void Add_Click(object sender, EventArgs e)
        {
            using (FormKeyDetails frmKeyDetails = new FormKeyDetails())
            {
                frmKeyDetails.ShowDialog();

                if (frmKeyDetails.Key != null)
                {
                    AddKey(frmKeyDetails.Key);
                }
            }
        }

        public void Edit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = Convert.ToString(lbDetails.SelectedItem);
                string[] parts = detail.Split(',');
                string entity = parts[0];

                KeyData data = itemDataManager.KeyData[entity];
                KeyData key = null;

                using (FormKeyDetails frmKeyDetails = new FormKeyDetails())
                {
                    frmKeyDetails.Key = data;
                    frmKeyDetails.ShowDialog();

                    if (frmKeyDetails == null)
                    {
                        return;
                    }

                    if (frmKeyDetails.Key.Name == entity)
                    {
                        itemDataManager.KeyData[entity] = frmKeyDetails.Key;
                        FillListBox();
                        return;
                    }

                    key = frmKeyDetails.Key;
                }

                DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?",
                    "New Entry", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return;
                }

                if (itemDataManager.KeyData.ContainsKey(key.Name))
                {
                    MessageBox.Show("Entry already exists. Do you want to overwrite?", "Existing Entry",
                        MessageBoxButtons.YesNo);

                    return;
                }

                lbDetails.Items.Add(key);
                itemDataManager.KeyData.Add(key.Name, key);
            }
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                string detail = Convert.ToString(lbDetails.SelectedItem);
                string[] parts = detail.Split(',');
                string entity = parts[0];

                DialogResult results = MessageBox.Show("Are you sure you want to delete " + entity + "?",
                    "Delete Item", MessageBoxButtons.YesNo);

                if (results == DialogResult.Yes)
                {
                    lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
                    itemDataManager.KeyData.Remove(entity);

                    if (File.Exists(FormMain.itemPath + @"\Key\" + entity + ".xml"))
                    {
                        File.Delete(FormMain.itemPath + @"\Key\" + entity + ".xml");
                    }
                }
            }
        }

        public void AddKey(KeyData key)
        {
            if (FormDetails.itemDataManager.KeyData.ContainsKey(key.Name))
            {
                DialogResult result = MessageBox.Show(key.Name + " already exists, do you want to overwrite?",
                    "Existing Key", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return;
                }

                itemDataManager.KeyData[key.Name] = key;
                FillListBox();

                return;
            }

            itemDataManager.KeyData.Add(key.Name, key);
            lbDetails.Items.Add(key);
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.itemDataManager.KeyData.Keys)
            {
                lbDetails.Items.Add(FormDetails.itemDataManager.KeyData[s]);
            }
        }
    }
}
