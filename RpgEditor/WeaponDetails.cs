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
    public partial class WeaponDetails : Form
    {
        private WeaponData weapon;

        public WeaponData Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }

        public WeaponDetails()
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

            foreach (Hands hand in Enum.GetValues(typeof(Hands)))
            {
                cbHands.Items.Add(hand);
            }

            if (weapon != null)
            {
                tbName.Text = weapon.name;
                tbType.Text = weapon.type;
                mtbPrice.Text = weapon.price.ToString();
                nudWeight.Value = (decimal)weapon.weight;
                mtbAttackVal.Text = weapon.attackValue.ToString();
                mtbAttackMod.Text = weapon.attackModifier.ToString();
                mtbDamageVal.Text = weapon.damageValue.ToString();
                mtbDamageMod.Text = weapon.damageModifier.ToString();

                foreach (string s in weapon.allowableClasses)
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
            int price = 0, attVal = 0, attMod = 0, damVal = 0, damMod = 0;
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

            if (!int.TryParse(mtbAttackVal.Text, out attVal))
            {
                MessageBox.Show("Attack Value must be greater than '1'");
                return;
            }

            if (!int.TryParse(mtbAttackMod.Text, out attMod))
            {
                MessageBox.Show("Attack Modifier must be greater than '1'");
                return;
            }

            if (!int.TryParse(mtbDamageVal.Text, out damVal))
            {
                MessageBox.Show("Damage Value must be greater than '1'");
                return;
            }

            if (!int.TryParse(mtbDamageMod.Text, out damMod))
            {
                MessageBox.Show("Damage Modifier must be greater than '1'");
                return;
            }

            List<string> allowedClasses = new List<string>();

            foreach (object o in lbSelectedClasses.Items)
            {
                allowedClasses.Add(o.ToString());
            }

            weapon = new WeaponData();
            weapon.name = tbName.Text;
            weapon.type = tbType.Text;
            weapon.price = price;
            weapon.weight = weight;
            weapon.attackValue = attVal;
            weapon.attackModifier = attMod;
            weapon.damageValue = damVal;
            weapon.damageModifier = damMod;
            weapon.allowableClasses = allowedClasses.ToArray();

            this.FormClosing -= new FormClosingEventHandler(Form_Close);
            this.Close();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            weapon = null;
            this.FormClosing -= new FormClosingEventHandler(Form_Close);
            this.Close();
        }
    }
}
