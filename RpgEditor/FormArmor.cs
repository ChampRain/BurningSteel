﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        }

        public void btnEdit_Click(object sender, EventArgs e)
        {
        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
        }
    }
}
