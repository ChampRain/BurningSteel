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
                tbName.Text = armor.Name;
                tbType.Text = armor.Type;
                mtbPrice.Text = armor.Price.ToString();
                nudWeight.Value = (Decimal) armor.Weight;
                cbLocations.SelectedIndex = (int) armor.Location;
                mtbDefenseVal.Text = armor.DefenseValue.ToString();
                mtbDefenseMod.Text = armor.DefenseModifier.ToString();

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
            this.Close();
        }

        public void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
