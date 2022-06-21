namespace Esports.Forms
{
    partial class TeamsForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.PlayerLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GameSelect = new Esports.Components.CustomComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GameLbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.RankLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.EarningsLbl = new System.Windows.Forms.Label();
            this.LossesLbl = new System.Windows.Forms.Label();
            this.TiesLbl = new System.Windows.Forms.Label();
            this.WinsLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TeamProfile = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TeamsList = new System.Windows.Forms.ListView();
            this.rank = new System.Windows.Forms.ColumnHeader();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.Earnings = new System.Windows.Forms.ColumnHeader();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Location = new System.Drawing.Point(22, 102);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(601, 1);
            this.panel2.TabIndex = 45;
            // 
            // PlayerLbl
            // 
            this.PlayerLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerLbl.AutoSize = true;
            this.PlayerLbl.Font = new System.Drawing.Font("Quicksand SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PlayerLbl.Location = new System.Drawing.Point(659, 19);
            this.PlayerLbl.MinimumSize = new System.Drawing.Size(720, 0);
            this.PlayerLbl.Name = "PlayerLbl";
            this.PlayerLbl.Size = new System.Drawing.Size(720, 34);
            this.PlayerLbl.TabIndex = 13;
            this.PlayerLbl.Text = "Teams";
            this.PlayerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Quicksand SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(22, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 34);
            this.label5.TabIndex = 47;
            this.label5.Text = "Game";
            // 
            // GameSelect
            // 
            this.GameSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.GameSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.GameSelect.BackColor = System.Drawing.SystemColors.Control;
            this.GameSelect.BorderColor = System.Drawing.Color.Transparent;
            this.GameSelect.BorderSize = 1;
            this.GameSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.GameSelect.Font = new System.Drawing.Font("Quicksand", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GameSelect.ForeColor = System.Drawing.SystemColors.WindowText;
            this.GameSelect.IconColor = System.Drawing.Color.DodgerBlue;
            this.GameSelect.Items.AddRange(new object[] {
            "Apex Legends",
            "CS:GO",
            "League of Legends",
            "Overwatch",
            "Rocket League",
            "Valorant"});
            this.GameSelect.ListBackColor = System.Drawing.Color.AliceBlue;
            this.GameSelect.ListTextColor = System.Drawing.SystemColors.WindowText;
            this.GameSelect.Location = new System.Drawing.Point(22, 65);
            this.GameSelect.MinimumSize = new System.Drawing.Size(0, 30);
            this.GameSelect.Name = "GameSelect";
            this.GameSelect.Padding = new System.Windows.Forms.Padding(1);
            this.GameSelect.Size = new System.Drawing.Size(588, 38);
            this.GameSelect.TabIndex = 48;
            this.GameSelect.Texts = "";
            this.GameSelect.OnSelectedIndexChanged += new System.EventHandler(this.GameSelect_OnSelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.GameLbl);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.LoginBtn);
            this.panel3.Controls.Add(this.RankLbl);
            this.panel3.Controls.Add(this.NameLbl);
            this.panel3.Controls.Add(this.EarningsLbl);
            this.panel3.Controls.Add(this.LossesLbl);
            this.panel3.Controls.Add(this.TiesLbl);
            this.panel3.Controls.Add(this.WinsLbl);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.TeamProfile);
            this.panel3.Location = new System.Drawing.Point(22, 159);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(615, 609);
            this.panel3.TabIndex = 49;
            // 
            // GameLbl
            // 
            this.GameLbl.AutoSize = true;
            this.GameLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GameLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.GameLbl.Location = new System.Drawing.Point(119, 362);
            this.GameLbl.Name = "GameLbl";
            this.GameLbl.Size = new System.Drawing.Size(68, 30);
            this.GameLbl.TabIndex = 20;
            this.GameLbl.Text = "GAME";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(18, 362);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 30);
            this.label10.TabIndex = 19;
            this.label10.Text = "GAME:";
            // 
            // LoginBtn
            // 
            this.LoginBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoginBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.LoginBtn.FlatAppearance.BorderSize = 0;
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("Quicksand", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoginBtn.ForeColor = System.Drawing.Color.AliceBlue;
            this.LoginBtn.Location = new System.Drawing.Point(106, 474);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(400, 61);
            this.LoginBtn.TabIndex = 16;
            this.LoginBtn.Text = "CHECK DETAILS";
            this.LoginBtn.UseVisualStyleBackColor = false;
            // 
            // RankLbl
            // 
            this.RankLbl.AutoSize = true;
            this.RankLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RankLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.RankLbl.Location = new System.Drawing.Point(334, 39);
            this.RankLbl.Name = "RankLbl";
            this.RankLbl.Size = new System.Drawing.Size(68, 30);
            this.RankLbl.TabIndex = 14;
            this.RankLbl.Text = "RANK";
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.NameLbl.Location = new System.Drawing.Point(336, 108);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(47, 30);
            this.NameLbl.TabIndex = 13;
            this.NameLbl.Text = "IGN";
            // 
            // EarningsLbl
            // 
            this.EarningsLbl.AutoSize = true;
            this.EarningsLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EarningsLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.EarningsLbl.Location = new System.Drawing.Point(336, 179);
            this.EarningsLbl.Name = "EarningsLbl";
            this.EarningsLbl.Size = new System.Drawing.Size(66, 30);
            this.EarningsLbl.TabIndex = 12;
            this.EarningsLbl.Text = "TEAM";
            // 
            // LossesLbl
            // 
            this.LossesLbl.AutoSize = true;
            this.LossesLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LossesLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.LossesLbl.Location = new System.Drawing.Point(119, 320);
            this.LossesLbl.Name = "LossesLbl";
            this.LossesLbl.Size = new System.Drawing.Size(83, 30);
            this.LossesLbl.TabIndex = 10;
            this.LossesLbl.Text = "LOSSES";
            // 
            // TiesLbl
            // 
            this.TiesLbl.AutoSize = true;
            this.TiesLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TiesLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TiesLbl.Location = new System.Drawing.Point(119, 275);
            this.TiesLbl.Name = "TiesLbl";
            this.TiesLbl.Size = new System.Drawing.Size(52, 30);
            this.TiesLbl.TabIndex = 9;
            this.TiesLbl.Text = "TIES";
            // 
            // WinsLbl
            // 
            this.WinsLbl.AutoSize = true;
            this.WinsLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WinsLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.WinsLbl.Location = new System.Drawing.Point(119, 230);
            this.WinsLbl.Name = "WinsLbl";
            this.WinsLbl.Size = new System.Drawing.Size(63, 30);
            this.WinsLbl.TabIndex = 8;
            this.WinsLbl.Text = "WINS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(220, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 30);
            this.label9.TabIndex = 7;
            this.label9.Text = "EARNINGS:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(18, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 30);
            this.label8.TabIndex = 6;
            this.label8.Text = "LOSSES:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(19, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "TIES:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(19, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 30);
            this.label6.TabIndex = 4;
            this.label6.Text = "WINS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(218, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "RANK:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(220, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "NAME:";
            // 
            // TeamProfile
            // 
            this.TeamProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TeamProfile.Location = new System.Drawing.Point(19, 29);
            this.TeamProfile.Name = "TeamProfile";
            this.TeamProfile.Size = new System.Drawing.Size(184, 180);
            this.TeamProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TeamProfile.TabIndex = 0;
            this.TeamProfile.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(56, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 30);
            this.label2.TabIndex = 50;
            this.label2.Text = "Team Details";
            // 
            // TeamsList
            // 
            this.TeamsList.BackColor = System.Drawing.Color.AliceBlue;
            this.TeamsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rank,
            this.name,
            this.Earnings});
            this.TeamsList.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TeamsList.ForeColor = System.Drawing.Color.White;
            this.TeamsList.FullRowSelect = true;
            this.TeamsList.Location = new System.Drawing.Point(659, 69);
            this.TeamsList.MultiSelect = false;
            this.TeamsList.Name = "TeamsList";
            this.TeamsList.OwnerDraw = true;
            this.TeamsList.Size = new System.Drawing.Size(720, 700);
            this.TeamsList.TabIndex = 0;
            this.TeamsList.UseCompatibleStateImageBehavior = false;
            this.TeamsList.View = System.Windows.Forms.View.Details;
            this.TeamsList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.sortByColumn);
            this.TeamsList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.changeBackColor);
            this.TeamsList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.justToCheck);
            this.TeamsList.SelectedIndexChanged += new System.EventHandler(this.PlayerList_SelectedIndexChanged);
            // 
            // rank
            // 
            this.rank.Tag = "";
            this.rank.Text = "Rank";
            this.rank.Width = 239;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 239;
            // 
            // Earnings
            // 
            this.Earnings.Text = "Earnings ($)";
            this.Earnings.Width = 239;
            // 
            // TeamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 768);
            this.Controls.Add(this.TeamsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.GameSelect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PlayerLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "TeamsForm";
            this.Text = "TeamsForm";
            this.Load += new System.EventHandler(this.TeamsForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel panel2;
        private Label PlayerLbl;
        private Label label5;
        private Components.CustomComboBox GameSelect;
        private Panel panel3;
        private Label label2;
        private ListView TeamsList;
        private ColumnHeader rank;
        private ColumnHeader name;
        private ColumnHeader Earnings;
        private Label label1;
        private PictureBox TeamProfile;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label3;
        private Label RankLbl;
        private Label NameLbl;
        private Label EarningsLbl;
        private Label LossesLbl;
        private Label TiesLbl;
        private Label WinsLbl;
        private Button LoginBtn;
        private Label GameLbl;
        private Label label10;
    }
}