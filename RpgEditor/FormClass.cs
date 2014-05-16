using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.CharacterClasses;

namespace RpgEditor
{
    public partial class FormClass : FormDetails
    {
        public FormClass()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormEntityData frmEntityData = new FormEntityData())
            {
                frmEntityData.ShowDialog();

                if (frmEntityData.EntityData != null)
                {
                    AddEntity(frmEntityData.EntityData);
                }
            }
        }

        public void btnEdit_Click(object sender, EventArgs e)
        {
        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void AddEntity(EntityData entityData)
        {
            if (FormDetails.entityDataManager.EntityData.ContainsKey(entityData.EntityName))
            {
                DialogResult result =
                    MessageBox.Show(entityData.EntityName + " already exists. Do you want to overwrite it?",
                        "Existing Character Class", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return;
                }

                FormDetails.entityDataManager.EntityData[entityData.EntityName] = entityData;

                FillListBox();
                return;
            }

            lbDetails.Items.Add(entityData.ToString());

            FormDetails.entityDataManager.EntityData.Add(entityData.EntityName, entityData);
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.entityDataManager.EntityData.Keys)
            {
                lbDetails.Items.Add(FormDetails.entityDataManager.EntityData[s]);
            }
        }
    }
}
