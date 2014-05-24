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
        private ShieldData shield;

        public ShieldData Shield
        {
            get { return shield; }
            set { shield = value; }
        }

        public ShieldDetails()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form_Load);
            this.FormClosing += new FormClosingEventHandler(Form_Close);

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnRemove.Click += new EventHandler(btnRemove_Click);
            btnOk.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        void Form_Load(object sender, EventArgs e)
        {
            foreach (string s in FormDetails.entityDataManager.EntityData.Keys)
            {
                lbAllClasses.Items.Add(s);
            }

            if (shield != null)
            {
                tbName.Text = shield.name;
                tbType.Text = shield.type;
                mtbPrice.Text = shield.price.ToString();
                nudWeight.Value = (decimal) shield.weight;
                mtbDefenseVal.Text = shield.defenseValue.ToString();
                mtbDefenseMod.Text = shield.defenseModifier.ToString();

                foreach (string s in shield.allowableClasses)
                {
                    if (lbAllClasses.Items.Contains(s))
                    {
                        lbAllClasses.Items.Remove(s);
                    }

                    lbSelectedClasses.Items.Add(s);
                }
            }
        }

        public void Form_Close(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbAllClasses.SelectedItem != null)
            {
                lbSelectedClasses.Items.Add(lbAllClasses.SelectedItem);
                lbAllClasses.Items.RemoveAt(lbAllClasses.SelectedIndex);
            }
        }

        public void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbSelectedClasses.SelectedItem != null)
            {
                lbAllClasses.Items.Add(lbSelectedClasses.SelectedItem);
                lbSelectedClasses.Items.RemoveAt(lbSelectedClasses.SelectedIndex);
            }
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            int price = 0, defVal = 0, defMod = 0;
            float weight = 0f;

            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the item");
                return;
            }

            if (!int.TryParse(mtbPrice.Text, out price))
            {
                MessageBox.Show("Price must be a value greater than '1'");
                return;
            }

            weight = (float)nudWeight.Value;

            if (!int.TryParse(mtbDefenseVal.Text, out defVal))
            {
                MessageBox.Show("Defense Value must be greater than '1'");
                return;
            }

            if (!int.TryParse(mtbDefenseMod.Text, out defMod))
            {
                MessageBox.Show("Defense Modifier must be greater than '1'");
                return;
            }

            List<string> allowedClasses = new List<string>();

            foreach (object o in lbSelectedClasses.Items)
            {
                allowedClasses.Add(o.ToString());
            }

            shield = new ShieldData();
            shield.name = tbName.Text;
            shield.type = tbType.Text;
            shield.price = price;
            shield.weight = weight;
            shield.defenseValue = defVal;
            shield.defenseModifier = defMod;
            shield.allowableClasses = allowedClasses.ToArray();

            this.FormClosing -= new FormClosingEventHandler(Form_Close);
            this.Close();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            shield = null;
            this.FormClosing -= new FormClosingEventHandler(Form_Close);
            this.Close();
        }
    }
}
