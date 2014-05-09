namespace RpgEditor
{
    partial class WeaponDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbAllClasses = new System.Windows.Forms.ListBox();
            this.lbSelectedClasses = new System.Windows.Forms.ListBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbType = new System.Windows.Forms.TextBox();
            this.mtbPrice = new System.Windows.Forms.MaskedTextBox();
            this.mtbAttackVal = new System.Windows.Forms.MaskedTextBox();
            this.mtbAttackMod = new System.Windows.Forms.MaskedTextBox();
            this.mtbDamageVal = new System.Windows.Forms.MaskedTextBox();
            this.mtbDamageMod = new System.Windows.Forms.MaskedTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.cbHands = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Weight:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hands:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Attack Value:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Attack Modifier:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Damage Value:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Damage Modifier:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(469, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Allowed Classes:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(242, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Character Classes:";
            // 
            // lbAllClasses
            // 
            this.lbAllClasses.FormattingEnabled = true;
            this.lbAllClasses.Location = new System.Drawing.Point(245, 49);
            this.lbAllClasses.Name = "lbAllClasses";
            this.lbAllClasses.Size = new System.Drawing.Size(120, 147);
            this.lbAllClasses.TabIndex = 11;
            // 
            // lbSelectedClasses
            // 
            this.lbSelectedClasses.FormattingEnabled = true;
            this.lbSelectedClasses.Location = new System.Drawing.Point(472, 49);
            this.lbSelectedClasses.Name = "lbSelectedClasses";
            this.lbSelectedClasses.Size = new System.Drawing.Size(120, 147);
            this.lbSelectedClasses.TabIndex = 12;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(120, 31);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 13;
            // 
            // tbType
            // 
            this.tbType.Location = new System.Drawing.Point(120, 56);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(100, 20);
            this.tbType.TabIndex = 14;
            // 
            // mtbPrice
            // 
            this.mtbPrice.Location = new System.Drawing.Point(120, 79);
            this.mtbPrice.Mask = "00000";
            this.mtbPrice.Name = "mtbPrice";
            this.mtbPrice.Size = new System.Drawing.Size(100, 20);
            this.mtbPrice.TabIndex = 15;
            // 
            // mtbAttackVal
            // 
            this.mtbAttackVal.Location = new System.Drawing.Point(120, 151);
            this.mtbAttackVal.Mask = "000";
            this.mtbAttackVal.Name = "mtbAttackVal";
            this.mtbAttackVal.Size = new System.Drawing.Size(100, 20);
            this.mtbAttackVal.TabIndex = 16;
            // 
            // mtbAttackMod
            // 
            this.mtbAttackMod.Location = new System.Drawing.Point(120, 175);
            this.mtbAttackMod.Mask = "000";
            this.mtbAttackMod.Name = "mtbAttackMod";
            this.mtbAttackMod.Size = new System.Drawing.Size(100, 20);
            this.mtbAttackMod.TabIndex = 17;
            // 
            // mtbDamageVal
            // 
            this.mtbDamageVal.Location = new System.Drawing.Point(120, 199);
            this.mtbDamageVal.Mask = "000";
            this.mtbDamageVal.Name = "mtbDamageVal";
            this.mtbDamageVal.Size = new System.Drawing.Size(100, 20);
            this.mtbDamageVal.TabIndex = 18;
            // 
            // mtbDamageMod
            // 
            this.mtbDamageMod.Location = new System.Drawing.Point(120, 223);
            this.mtbDamageMod.Mask = "000";
            this.mtbDamageMod.Name = "mtbDamageMod";
            this.mtbDamageMod.Size = new System.Drawing.Size(100, 20);
            this.mtbDamageMod.TabIndex = 19;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(381, 93);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(381, 134);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 22;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(306, 213);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(105, 23);
            this.btnOk.TabIndex = 23;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(426, 213);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // nudWeight
            // 
            this.nudWeight.Location = new System.Drawing.Point(120, 103);
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(100, 20);
            this.nudWeight.TabIndex = 25;
            // 
            // cbHands
            // 
            this.cbHands.FormattingEnabled = true;
            this.cbHands.Location = new System.Drawing.Point(120, 127);
            this.cbHands.Name = "cbHands";
            this.cbHands.Size = new System.Drawing.Size(100, 21);
            this.cbHands.TabIndex = 26;
            // 
            // WeaponDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 257);
            this.Controls.Add(this.cbHands);
            this.Controls.Add(this.nudWeight);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.mtbDamageMod);
            this.Controls.Add(this.mtbDamageVal);
            this.Controls.Add(this.mtbAttackMod);
            this.Controls.Add(this.mtbAttackVal);
            this.Controls.Add(this.mtbPrice);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbSelectedClasses);
            this.Controls.Add(this.lbAllClasses);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WeaponDetails";
            this.Text = "WeaponDetails";
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lbAllClasses;
        private System.Windows.Forms.ListBox lbSelectedClasses;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.MaskedTextBox mtbPrice;
        private System.Windows.Forms.MaskedTextBox mtbAttackVal;
        private System.Windows.Forms.MaskedTextBox mtbAttackMod;
        private System.Windows.Forms.MaskedTextBox mtbDamageVal;
        private System.Windows.Forms.MaskedTextBox mtbDamageMod;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.ComboBox cbHands;
    }
}