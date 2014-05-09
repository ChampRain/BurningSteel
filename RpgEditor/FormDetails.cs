using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormDetails : Form
    {
        protected static EntityDataManager entityDataManager;
        protected static ItemManager itemManager;

        public FormDetails()
        {
            InitializeComponent();

            if (entityDataManager == null)
            {
                entityDataManager = new EntityDataManager();
            }

            if (itemManager == null)
            {
                itemManager = new ItemManager();
            }

            this.FormClosing += new FormClosingEventHandler(DetailsForm_Close);
        }

        public void DetailsForm_Close(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false;
                this.Hide();
            }

            if (e.CloseReason == CloseReason.MdiFormClosing)
            {
                e.Cancel = true;
                this.Close();
            }
        }
    }
}
