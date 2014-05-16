using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary;
using RpgLibrary.ItemClasses;

namespace RpgEditor
{
    public partial class FormMain : Form
    {
        private RolePlayingGame rpg;
        private FormClass classForm;
        private FormArmor armorForm;
        private FormWeapon weaponForm;
        private FormShield shieldForm;

        public static string classPath = "", gamePath = "", itemPath = "";

        public FormMain()
        {
            InitializeComponent();

            newGameMenu.Click += new EventHandler(newGameMenu_Click);
            loadGameMenu.Click += new EventHandler(loadGameMenu_Click);
            saveGameMenu.Click += new EventHandler(saveGameMenu_Click);
            exitGameMenu.Click += new EventHandler(exitGameMenu_Click);

            classMenu.Click += new EventHandler(classMenu_Click);
            weaponMenu.Click += new EventHandler(weaponMenu_Click);
            armorMenu.Click += new EventHandler(armorMenu_Click);
            shieldMenu.Click += new EventHandler(shieldMenu_Click);
        }

        public void newGameMenu_Click(object sender, EventArgs e)
        {
            using (NewGame newGame = new NewGame())
            {
                DialogResult result = newGame.ShowDialog();
                if (result == DialogResult.OK && newGame.RolePlayingGame != null)
                {
                    FolderBrowserDialog folderdDialog = new FolderBrowserDialog();

                    folderdDialog.Description = "Select folder for your new game";
                    folderdDialog.SelectedPath = Application.StartupPath;
                    
                    DialogResult folderResult = folderdDialog.ShowDialog();

                    if (folderResult == DialogResult.OK)
                    {
                        try
                        {
                            gamePath = Path.Combine(folderdDialog.SelectedPath, "Game");
                            classPath = Path.Combine(gamePath, "Classes");
                            itemPath = Path.Combine(gamePath, "Items");

                            if (Directory.Exists(gamePath))
                            {
                                throw new Exception("Selected directory already exists");
                            }

                            Directory.CreateDirectory(gamePath);
                            Directory.CreateDirectory(classPath);
                            Directory.CreateDirectory(itemPath + @"\Armor");
                            Directory.CreateDirectory(itemPath + @"\Weapon");
                            Directory.CreateDirectory(itemPath + @"\Shield");

                            rpg = newGame.RolePlayingGame;
                            XnaSerializer.Serialize<RolePlayingGame>(gamePath + @"Game.xml", rpg);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            return;
                        }

                        classMenu.Enabled = true;
                        itemMenu.Enabled = true;
                    }   
                }
            }
        }

        public void loadGameMenu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderdDialog = new FolderBrowserDialog();

            folderdDialog.Description = "Select Game Folder";
            folderdDialog.SelectedPath = Application.StartupPath;

            bool tryAgain = false;

            do
            {
                DialogResult result = folderdDialog.ShowDialog();
                DialogResult msgBoxResult;
                
                if (result == DialogResult.OK)
                {
                    if (File.Exists(folderdDialog.SelectedPath + @"\Game\Game.xml"))
                    {
                        try
                        {
                            OpenGame(folderdDialog.SelectedPath);
                            tryAgain = false;
                        }
                        catch (Exception ex)
                        {
                            msgBoxResult = MessageBox.Show(ex.ToString(), "Error Opening String",
                                MessageBoxButtons.RetryCancel);

                            if (msgBoxResult == DialogResult.Retry)
                            {
                                tryAgain = true;
                            }
                            else if (msgBoxResult == DialogResult.Cancel)
                            {
                                tryAgain = false;
                            }
                        }
                    }
                    else
                    {
                        msgBoxResult = MessageBox.Show("Game not found, try again?", "Game does not exist",
                            MessageBoxButtons.RetryCancel);

                        if (msgBoxResult == DialogResult.Retry)
                        {
                            tryAgain = true;
                        }
                        else if (msgBoxResult == DialogResult.Cancel)
                        {
                            tryAgain = false;
                        }
                    }
                }
            } 
            while (tryAgain);
        }

        private void OpenGame(string path)
        {
            gamePath = Path.Combine(path + "Game");
            classPath = Path.Combine(path + "Classes");
            itemPath = Path.Combine(path + "Items");

            rpg = XnaSerializer.Deserialize<RolePlayingGame>(gamePath + @"\Game.xml");

            FormDetails.ReadEntityData();
            FormDetails.ReadItemData();

            PrepareForms();
        }
        
        public void saveGameMenu_Click(object sender, EventArgs e)
        {
            if (rpg != null)
            {
                try
                {
                    XnaSerializer.Serialize<RolePlayingGame>(gamePath + @"Game.xml", rpg);
                    FormDetails.WriteEntityData();
                    FormDetails.WriteItemData();
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.ToString(), "Error saving game");
                }
            }
        }

        public void exitGameMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void PrepareForms()
        {
            if (classForm == null)
            {
                classForm = new FormClass();
                classForm.MdiParent = this;
            }

            classForm.FillListBox();

            if (weaponForm == null)
            {
                weaponForm = new FormWeapon();
                weaponForm.MdiParent = this;
            }

            weaponForm.FillListBox();

            if (armorForm == null)
            {
                armorForm = new FormArmor();
                armorForm.MdiParent = this;
            }

            armorForm.FillListBox();

            if (shieldForm == null)
            {
                shieldForm = new FormShield();
                shieldForm.MdiParent = this;
            }

            shieldForm.FillListBox();

            classMenu.Enabled = true;
            itemMenu.Enabled = true;
        }

        public void classMenu_Click(object sender, EventArgs e)
        {
            if (classForm == null)
            {
                classForm = new FormClass();
                classForm.MdiParent = this;
            }

            classForm.Show();
            classForm.BringToFront();
        }

        public void weaponMenu_Click(object sender, EventArgs e)
        {
            if (weaponForm == null)
            {
                weaponForm = new FormWeapon();
                weaponForm.MdiParent = this;
            }

            weaponForm.Show();
            weaponForm.BringToFront();
        }

        public void armorMenu_Click(object sender, EventArgs e)
        {
            if (armorForm == null)
            {
                armorForm = new FormArmor();
                armorForm.MdiParent = this;
            }

            armorForm.Show();
            armorForm.BringToFront();
        }

        public void shieldMenu_Click(object sender, EventArgs e)
        {
            if (shieldForm == null)
            {
                shieldForm = new FormShield();
                shieldForm.MdiParent = this;
            }

            shieldForm.Show();
            shieldForm.BringToFront();
        }
    }
}
