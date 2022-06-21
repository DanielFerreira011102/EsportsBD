namespace Esports.Forms
{
    partial class PlayersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.PlayerLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GameSelect = new Esports.Components.CustomComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PlayerProfile = new System.Windows.Forms.PictureBox();
            this.IGLStar = new System.Windows.Forms.PictureBox();
            this.JoinDateLbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Twitter = new System.Windows.Forms.PictureBox();
            this.Twitch = new System.Windows.Forms.PictureBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.RankLbl = new System.Windows.Forms.Label();
            this.IGNLbl = new System.Windows.Forms.Label();
            this.TeamLbl = new System.Windows.Forms.Label();
            this.CountryLbl = new System.Windows.Forms.Label();
            this.GameLbl = new System.Windows.Forms.Label();
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.RealNameLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PlayerList = new System.Windows.Forms.ListView();
            this.rank = new System.Windows.Forms.ColumnHeader();
            this.IGN = new System.Windows.Forms.ColumnHeader();
            this.Team = new System.Windows.Forms.ColumnHeader();
            this.Country = new System.Windows.Forms.ColumnHeader();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IGLStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Twitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Twitch)).BeginInit();
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
            this.PlayerLbl.Text = "Players";
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
            this.panel3.Controls.Add(this.PlayerProfile);
            this.panel3.Controls.Add(this.IGLStar);
            this.panel3.Controls.Add(this.JoinDateLbl);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.Twitter);
            this.panel3.Controls.Add(this.Twitch);
            this.panel3.Controls.Add(this.LoginBtn);
            this.panel3.Controls.Add(this.RankLbl);
            this.panel3.Controls.Add(this.IGNLbl);
            this.panel3.Controls.Add(this.TeamLbl);
            this.panel3.Controls.Add(this.CountryLbl);
            this.panel3.Controls.Add(this.GameLbl);
            this.panel3.Controls.Add(this.UsernameLbl);
            this.panel3.Controls.Add(this.RealNameLbl);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(22, 159);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(615, 609);
            this.panel3.TabIndex = 49;
            // 
            // PlayerProfile
            // 
            this.PlayerProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayerProfile.Location = new System.Drawing.Point(19, 29);
            this.PlayerProfile.Name = "PlayerProfile";
            this.PlayerProfile.Size = new System.Drawing.Size(173, 180);
            this.PlayerProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayerProfile.TabIndex = 0;
            this.PlayerProfile.TabStop = false;
            // 
            // IGLStar
            // 
            this.IGLStar.BackColor = System.Drawing.Color.Transparent;
            this.IGLStar.Location = new System.Drawing.Point(12, 22);
            this.IGLStar.Name = "IGLStar";
            this.IGLStar.Size = new System.Drawing.Size(45, 45);
            this.IGLStar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IGLStar.TabIndex = 21;
            this.IGLStar.TabStop = false;
            this.IGLStar.MouseHover += new System.EventHandler(this.ShowTooltipIGL);
            // 
            // JoinDateLbl
            // 
            this.JoinDateLbl.AutoSize = true;
            this.JoinDateLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.JoinDateLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.JoinDateLbl.Location = new System.Drawing.Point(162, 362);
            this.JoinDateLbl.Name = "JoinDateLbl";
            this.JoinDateLbl.Size = new System.Drawing.Size(62, 30);
            this.JoinDateLbl.TabIndex = 20;
            this.JoinDateLbl.Text = "DATE";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(18, 362);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 30);
            this.label10.TabIndex = 19;
            this.label10.Text = "JOINED:";
            // 
            // Twitter
            // 
            this.Twitter.Image = ((System.Drawing.Image)(resources.GetObject("Twitter.Image")));
            this.Twitter.Location = new System.Drawing.Point(223, 413);
            this.Twitter.Name = "Twitter";
            this.Twitter.Size = new System.Drawing.Size(70, 70);
            this.Twitter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Twitter.TabIndex = 18;
            this.Twitter.TabStop = false;
            this.Twitter.Click += new System.EventHandler(this.Twitter_Click);
            // 
            // Twitch
            // 
            this.Twitch.Image = ((System.Drawing.Image)(resources.GetObject("Twitch.Image")));
            this.Twitch.Location = new System.Drawing.Point(316, 413);
            this.Twitch.Name = "Twitch";
            this.Twitch.Size = new System.Drawing.Size(70, 70);
            this.Twitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Twitch.TabIndex = 17;
            this.Twitch.TabStop = false;
            this.Twitch.Click += new System.EventHandler(this.Twitch_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoginBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.LoginBtn.FlatAppearance.BorderSize = 0;
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("Quicksand", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoginBtn.ForeColor = System.Drawing.Color.AliceBlue;
            this.LoginBtn.Location = new System.Drawing.Point(107, 516);
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
            this.RankLbl.Location = new System.Drawing.Point(330, 39);
            this.RankLbl.Name = "RankLbl";
            this.RankLbl.Size = new System.Drawing.Size(68, 30);
            this.RankLbl.TabIndex = 14;
            this.RankLbl.Text = "RANK";
            // 
            // IGNLbl
            // 
            this.IGNLbl.AutoSize = true;
            this.IGNLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IGNLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.IGNLbl.Location = new System.Drawing.Point(330, 83);
            this.IGNLbl.Name = "IGNLbl";
            this.IGNLbl.Size = new System.Drawing.Size(47, 30);
            this.IGNLbl.TabIndex = 13;
            this.IGNLbl.Text = "IGN";
            // 
            // TeamLbl
            // 
            this.TeamLbl.AutoSize = true;
            this.TeamLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TeamLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TeamLbl.Location = new System.Drawing.Point(330, 127);
            this.TeamLbl.Name = "TeamLbl";
            this.TeamLbl.Size = new System.Drawing.Size(66, 30);
            this.TeamLbl.TabIndex = 12;
            this.TeamLbl.Text = "TEAM";
            // 
            // CountryLbl
            // 
            this.CountryLbl.AutoSize = true;
            this.CountryLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CountryLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.CountryLbl.Location = new System.Drawing.Point(330, 169);
            this.CountryLbl.Name = "CountryLbl";
            this.CountryLbl.Size = new System.Drawing.Size(122, 30);
            this.CountryLbl.TabIndex = 11;
            this.CountryLbl.Text = "REAL NAME";
            // 
            // GameLbl
            // 
            this.GameLbl.AutoSize = true;
            this.GameLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GameLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.GameLbl.Location = new System.Drawing.Point(162, 320);
            this.GameLbl.Name = "GameLbl";
            this.GameLbl.Size = new System.Drawing.Size(68, 30);
            this.GameLbl.TabIndex = 10;
            this.GameLbl.Text = "GAME";
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsernameLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.UsernameLbl.Location = new System.Drawing.Point(162, 275);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(118, 30);
            this.UsernameLbl.TabIndex = 9;
            this.UsernameLbl.Text = "USERNAME";
            // 
            // RealNameLbl
            // 
            this.RealNameLbl.AutoSize = true;
            this.RealNameLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RealNameLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.RealNameLbl.Location = new System.Drawing.Point(162, 230);
            this.RealNameLbl.Name = "RealNameLbl";
            this.RealNameLbl.Size = new System.Drawing.Size(122, 30);
            this.RealNameLbl.TabIndex = 8;
            this.RealNameLbl.Text = "REAL NAME";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(207, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 30);
            this.label9.TabIndex = 7;
            this.label9.Text = "TEAM:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(18, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 30);
            this.label8.TabIndex = 6;
            this.label8.Text = "GAME:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(19, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "USERNAME:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(19, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 30);
            this.label6.TabIndex = 4;
            this.label6.Text = "REAL NAME:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(207, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "COUNTRY:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(207, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "RANK:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(207, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "IGN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(56, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 30);
            this.label2.TabIndex = 50;
            this.label2.Text = "Player Details";
            // 
            // PlayerList
            // 
            this.PlayerList.BackColor = System.Drawing.Color.AliceBlue;
            this.PlayerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rank,
            this.IGN,
            this.Team,
            this.Country});
            this.PlayerList.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayerList.ForeColor = System.Drawing.Color.White;
            this.PlayerList.FullRowSelect = true;
            this.PlayerList.Location = new System.Drawing.Point(659, 69);
            this.PlayerList.MultiSelect = false;
            this.PlayerList.Name = "PlayerList";
            this.PlayerList.OwnerDraw = true;
            this.PlayerList.Size = new System.Drawing.Size(720, 700);
            this.PlayerList.TabIndex = 0;
            this.PlayerList.UseCompatibleStateImageBehavior = false;
            this.PlayerList.View = System.Windows.Forms.View.Details;
            this.PlayerList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.sortByColumn);
            this.PlayerList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.changeBackColor);
            this.PlayerList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.justToCheck);
            this.PlayerList.SelectedIndexChanged += new System.EventHandler(this.PlayerList_SelectedIndexChanged);
            // 
            // rank
            // 
            this.rank.Tag = "";
            this.rank.Text = "Rank";
            this.rank.Width = 179;
            // 
            // IGN
            // 
            this.IGN.Text = "IGN";
            this.IGN.Width = 179;
            // 
            // Team
            // 
            this.Team.Text = "Team";
            this.Team.Width = 179;
            // 
            // Country
            // 
            this.Country.Text = "Country";
            this.Country.Width = 179;
            // 
            // PlayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 768);
            this.Controls.Add(this.PlayerList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.GameSelect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PlayerLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "PlayersForm";
            this.Text = "PlayersForm";
            this.Load += new System.EventHandler(this.PlayersForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IGLStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Twitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Twitch)).EndInit();
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
        private ListView PlayerList;
        private ColumnHeader rank;
        private ColumnHeader IGN;
        private ColumnHeader Team;
        private ColumnHeader Country;
        private Label label1;
        private PictureBox PlayerProfile;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label RankLbl;
        private Label IGNLbl;
        private Label TeamLbl;
        private Label CountryLbl;
        private Label GameLbl;
        private Label UsernameLbl;
        private Label RealNameLbl;
        private Button LoginBtn;
        private PictureBox Twitter;
        private PictureBox Twitch;
        private Label JoinDateLbl;
        private Label label10;
        private PictureBox IGLStar;
    }
}