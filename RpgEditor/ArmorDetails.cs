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
        private ArmorData armor;

        public ArmorData Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        public ArmorDetails()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form_Load);
            this.FormClosing += new FormClosingEventHandler(Form_Close);
            btnOk.Click += new EventHandler(Ok_Click);
            btnCancel.Click += new EventHandler(Cancel_Click);

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnRemove.Click += new EventHandler(btnRemove_Click);
        }

        public void Form_Close(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        public void Form_Load(object sender, EventArgs e)
        {
            foreach (string s in FormDetails.entityDataManager.EntityData.Keys)
            {
                lbAllClasses.Items.Add(s);
            }

            foreach (ArmorLocation location in Enum.GetValues(typeof(ArmorLocation)))
            {
                cbLocations.Items.Add(location);
            }

            cbLocations.SelectedIndex = 0;

            if (armor != null)
            {
                tbName.Text = armor.name;
                tbType.Text = armor.type;
                mtbPrice.Text = armor.price.ToString();
                nudWeight.Value = (Decimal) armor.weight;
                cbLocations.SelectedIndex = (int) armor.ArmorLocation;
                mtbDefenseVal.Text = armor.defenseValue.ToString();
                mtbDefenseMod.Text = armor.defenseModifier.ToString();

                foreach (string s in armor.allowableClasses)
                {
                    if (lbAllClasses.Items.Contains(s))
                    {
                        lbAllClasses.Items.Remove(s);
                    }

                    lbAllClasses.Items.Add(s);
                }
            }
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbAllClasses.SelectedItem != null)
            {
                lbAllowedClasses.Items.Add(lbAllClasses.SelectedItem);
                lbAllClasses.Items.RemoveAt(lbAllClasses.SelectedIndex);
            }
        }

        public void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbAllowedClasses.SelectedItem != null)
            {
                lbAllClasses.Items.Add(lbAllowedClasses.SelectedItem);
                lbAllowedClasses.Items.RemoveAt(lbAllowedClasses.SelectedIndex);
            }
        }

        public void Ok_Click(object sender, EventArgs e)
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

            weight = (float) nudWeight.Value;

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

            foreach (object o in lbAllowedClasses.Items)
            {
                allowedClasses.Add(o.ToString());
            }

            armor = new ArmorData();
            armor.name = tbName.Text;
            armor.type = tbType.Text;
            armor.price = price;
            armor.weight = weight;
            armor.ArmorLocation = (ArmorLocation) cbLocations.SelectedIndex;
            armor.defenseValue = defVal;
            armor.defenseModifier = defMod;
            armor.allowableClasses = allowedClasses.ToArray();

            this.FormClosing -= new FormClosingEventHandler(Form_Close);
            this.Close();
        }

        public void Cancel_Click(object sender, EventArgs e)
        {
            armor = null;
            this.FormClosing -= new FormClosingEventHandler(Form_Close);
            this.Close();
        }
    }
}
