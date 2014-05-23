using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormDetails : Form
    {
        public static EntityDataManager entityDataManager;
        public static ItemDataManager itemDataManager;

        public EntityDataManager EntityManager
        {
            get { return entityDataManager; }
            private set { entityDataManager = value; }
        }

        public ItemDataManager ItemManager
        {
            get { return itemDataManager; }
            private set { itemDataManager = value; }
        }

        public FormDetails()
        {
            InitializeComponent();

            if (FormDetails.entityDataManager == null)
            {
                entityDataManager = new EntityDataManager();
            }

            if (FormDetails.itemDataManager == null)
            {
                itemDataManager = new ItemDataManager();
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

        public static void WriteEntityData()
        {
            foreach (string s in entityDataManager.EntityData.Keys)
            {
                XnaSerializer.Serialize<EntityData>(FormMain.classPath + @"\" + s + ".xml", entityDataManager.EntityData[s]);
            }
        }

        public static void WriteItemData()
        {
            foreach (string s in itemDataManager.WeaponData.Keys)
            {
                XnaSerializer.Serialize<WeaponData>(FormMain.itemPath + @"\Weapon\" + s + ".xml", itemDataManager.WeaponData[s]);
            }
            foreach (string s in itemDataManager.ArmorData.Keys)
            {
                XnaSerializer.Serialize<ArmorData>(FormMain.itemPath + @"\Armor\" + s + ".xml", itemDataManager.ArmorData[s]);
            }
            foreach (string s in itemDataManager.ShieldData.Keys)
            {
                XnaSerializer.Serialize<ShieldData>(FormMain.itemPath + @"\Shield\" + s + ".xml", itemDataManager.ShieldData[s]);
            }
        }

        public static void ReadEntityData()
        {
            entityDataManager = new EntityDataManager();

            string[] fileNames = Directory.GetFiles(FormMain.classPath + ".xml");

            foreach (string s in fileNames)
            {
                EntityData entityData = XnaSerializer.Deserialize<EntityData>(s);
                entityDataManager.EntityData.Add(entityData.EntityName, entityData);
            }
        }

        public static void ReadItemData()
        {
            itemDataManager = new ItemDataManager();

            string[] weaponNames = Directory.GetFiles(Path.Combine(FormMain.itemPath,"Weapon", ".xml"));
            string[] armorNames = Directory.GetFiles(Path.Combine(FormMain.itemPath, "Armor", ".xml"));
            string[] shieldNames = Directory.GetFiles(Path.Combine(FormMain.itemPath, "Shield", ".xml"));

            foreach (string s in weaponNames)
            {
                WeaponData weaponData = XnaSerializer.Deserialize<WeaponData>(s);
                itemDataManager.WeaponData.Add(weaponData.name, weaponData);
            }

            foreach (string s in armorNames)
            {
                ArmorData armorData = XnaSerializer.Deserialize<ArmorData>(s);
                itemDataManager.ArmorData.Add(armorData.name, armorData);
            }

            foreach (string s in shieldNames)
            {
                ShieldData shieldData = XnaSerializer.Deserialize<ShieldData>(s);
                itemDataManager.ShieldData.Add(shieldData.name, shieldData);
            }
        }
    }
}
