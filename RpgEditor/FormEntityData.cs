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
    public partial class FormEntityData : Form
    {
        private EntityData entityData = null;

        public EntityData EntityData
        {
            get { return entityData; }
            set { entityData = value; }
        }

        public FormEntityData()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormEntityData_Load);
            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        public void FormEntityData_Load(object sender, EventArgs e)
        {
            if (entityData != null)
            {
                tbName.Text = entityData.EntityName;
                mtbStrength.Text = entityData.Strength.ToString();
                mtbDexterity.Text = entityData.Dexterity.ToString();
                mtbCunning.Text = entityData.Cunning.ToString();
                mtbConstitution.Text = entityData.Constitution.ToString();
                mtbWillpower.Text = entityData.Willpower.ToString();
                mtbMagic.Text = entityData.Magic.ToString();
                tbHealthFormula.Text = entityData.HealthFormula;
                tbStaminaFormula.Text = entityData.StaminaFormula;
                tbManaFormula.Text = entityData.MagicFormula;
            }
        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbHealthFormula.Text) ||
                string.IsNullOrEmpty(tbStaminaFormula.Text) || string.IsNullOrEmpty(tbManaFormula.Text))
            {
                MessageBox.Show("Name, Health Formula, Stamina Formula and Mana Formula must have values", "Empty Fields");

                return;
            }

            int str = 0;
            int dex = 0;
            int cun = 0;
            int will = 0;
            int mag = 0;
            int con = 0;

            if (!int.TryParse(mtbStrength.Text, out str))
            {
                MessageBox.Show("Strength must be numeric");
                return;
            }
            if (!int.TryParse(mtbDexterity.Text, out dex))
            {
                MessageBox.Show("Dexterity must be numeric");
                return;
            }
            if (!int.TryParse(mtbCunning.Text, out cun))
            {
                MessageBox.Show("Cunning must be numeric");
                return;
            }
            if (!int.TryParse(mtbWillpower.Text, out will))
            {
                MessageBox.Show("Willpower must be numeric");
                return;
            }
            if (!int.TryParse(mtbMagic.Text, out mag))
            {
                MessageBox.Show("Magic must be numeric");
                return;
            }
            if (!int.TryParse(mtbConstitution.Text, out con))
            {
                MessageBox.Show("Constitution must be numeric");
                return;
            }

            entityData = new EntityData(tbName.Text, str, dex, cun, will, con, mag, 
                tbHealthFormula.Text, tbStaminaFormula.Text, tbManaFormula.Text);

            this.Close();
        }

        public void btnCancel_Click(object sender, EventArgs e)
        {
            entityData = null;
            this.Close();
        }
    }
}
