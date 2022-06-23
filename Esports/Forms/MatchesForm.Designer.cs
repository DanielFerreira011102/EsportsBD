namespace Esports.Forms
{
    partial class MatchesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchesForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.PlayerLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GameSelect = new Esports.Components.CustomComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.leftWin = new System.Windows.Forms.PictureBox();
            this.rightWin = new System.Windows.Forms.PictureBox();
            this.team2Img = new System.Windows.Forms.PictureBox();
            this.team1Img = new System.Windows.Forms.PictureBox();
            this.team2Name = new System.Windows.Forms.Label();
            this.team1Name = new System.Windows.Forms.Label();
            this.OrgLbl = new System.Windows.Forms.Label();
            this.GameLbl = new System.Windows.Forms.Label();
            this.BestOfLbl = new System.Windows.Forms.Label();
            this.TourLbl = new System.Windows.Forms.Label();
            this.team2Score = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.DateLbl = new System.Windows.Forms.Label();
            this.TiesLbl = new System.Windows.Forms.Label();
            this.team1Score = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.StatusImg = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TeamsList = new System.Windows.Forms.ListView();
            this.Date = new System.Windows.Forms.ColumnHeader();
            this.Tournament = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.team2Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.team1Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusImg)).BeginInit();
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
            this.PlayerLbl.Text = "Matches";
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
            this.panel3.Controls.Add(this.leftWin);
            this.panel3.Controls.Add(this.rightWin);
            this.panel3.Controls.Add(this.team2Img);
            this.panel3.Controls.Add(this.team1Img);
            this.panel3.Controls.Add(this.team2Name);
            this.panel3.Controls.Add(this.team1Name);
            this.panel3.Controls.Add(this.OrgLbl);
            this.panel3.Controls.Add(this.GameLbl);
            this.panel3.Controls.Add(this.BestOfLbl);
            this.panel3.Controls.Add(this.TourLbl);
            this.panel3.Controls.Add(this.team2Score);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.LoginBtn);
            this.panel3.Controls.Add(this.DateLbl);
            this.panel3.Controls.Add(this.TiesLbl);
            this.panel3.Controls.Add(this.team1Score);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.StatusLbl);
            this.panel3.Controls.Add(this.StatusImg);
            this.panel3.Location = new System.Drawing.Point(22, 159);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(615, 609);
            this.panel3.TabIndex = 49;
            // 
            // leftWin
            // 
            this.leftWin.Image = ((System.Drawing.Image)(resources.GetObject("leftWin.Image")));
            this.leftWin.Location = new System.Drawing.Point(18, 27);
            this.leftWin.Name = "leftWin";
            this.leftWin.Size = new System.Drawing.Size(50, 50);
            this.leftWin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.leftWin.TabIndex = 28;
            this.leftWin.TabStop = false;
            this.leftWin.Visible = false;
            // 
            // rightWin
            // 
            this.rightWin.Image = ((System.Drawing.Image)(resources.GetObject("rightWin.Image")));
            this.rightWin.Location = new System.Drawing.Point(429, 27);
            this.rightWin.Name = "rightWin";
            this.rightWin.Size = new System.Drawing.Size(50, 50);
            this.rightWin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rightWin.TabIndex = 29;
            this.rightWin.TabStop = false;
            this.rightWin.Visible = false;
            // 
            // team2Img
            // 
            this.team2Img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.team2Img.Location = new System.Drawing.Point(435, 29);
            this.team2Img.Name = "team2Img";
            this.team2Img.Size = new System.Drawing.Size(152, 147);
            this.team2Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.team2Img.TabIndex = 21;
            this.team2Img.TabStop = false;
            // 
            // team1Img
            // 
            this.team1Img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.team1Img.Location = new System.Drawing.Point(25, 32);
            this.team1Img.Name = "team1Img";
            this.team1Img.Size = new System.Drawing.Size(152, 147);
            this.team1Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.team1Img.TabIndex = 0;
            this.team1Img.TabStop = false;
            // 
            // team2Name
            // 
            this.team2Name.AutoSize = true;
            this.team2Name.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.team2Name.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.team2Name.Location = new System.Drawing.Point(367, 179);
            this.team2Name.MinimumSize = new System.Drawing.Size(220, 0);
            this.team2Name.Name = "team2Name";
            this.team2Name.Size = new System.Drawing.Size(220, 30);
            this.team2Name.TabIndex = 23;
            this.team2Name.Text = "TEAM2";
            this.team2Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // team1Name
            // 
            this.team1Name.AutoSize = true;
            this.team1Name.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.team1Name.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.team1Name.Location = new System.Drawing.Point(25, 182);
            this.team1Name.MinimumSize = new System.Drawing.Size(220, 0);
            this.team1Name.Name = "team1Name";
            this.team1Name.Size = new System.Drawing.Size(220, 30);
            this.team1Name.TabIndex = 22;
            this.team1Name.Text = "TEAM1";
            this.team1Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OrgLbl
            // 
            this.OrgLbl.AutoSize = true;
            this.OrgLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OrgLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.OrgLbl.Location = new System.Drawing.Point(197, 242);
            this.OrgLbl.Name = "OrgLbl";
            this.OrgLbl.Size = new System.Drawing.Size(160, 30);
            this.OrgLbl.TabIndex = 30;
            this.OrgLbl.Text = "ORGANIZATION";
            // 
            // GameLbl
            // 
            this.GameLbl.AutoSize = true;
            this.GameLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GameLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.GameLbl.Location = new System.Drawing.Point(197, 374);
            this.GameLbl.Name = "GameLbl";
            this.GameLbl.Size = new System.Drawing.Size(68, 30);
            this.GameLbl.TabIndex = 20;
            this.GameLbl.Text = "GAME";
            // 
            // BestOfLbl
            // 
            this.BestOfLbl.AutoSize = true;
            this.BestOfLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BestOfLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BestOfLbl.Location = new System.Drawing.Point(207, 133);
            this.BestOfLbl.MinimumSize = new System.Drawing.Size(200, 0);
            this.BestOfLbl.Name = "BestOfLbl";
            this.BestOfLbl.Size = new System.Drawing.Size(200, 30);
            this.BestOfLbl.TabIndex = 25;
            this.BestOfLbl.Text = "BO?";
            this.BestOfLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TourLbl
            // 
            this.TourLbl.AutoSize = true;
            this.TourLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TourLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TourLbl.Location = new System.Drawing.Point(197, 287);
            this.TourLbl.Name = "TourLbl";
            this.TourLbl.Size = new System.Drawing.Size(150, 30);
            this.TourLbl.TabIndex = 31;
            this.TourLbl.Text = "TOURNAMENT";
            // 
            // team2Score
            // 
            this.team2Score.AutoSize = true;
            this.team2Score.Font = new System.Drawing.Font("Quicksand Medium", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.team2Score.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.team2Score.Location = new System.Drawing.Point(364, 68);
            this.team2Score.Name = "team2Score";
            this.team2Score.Size = new System.Drawing.Size(59, 70);
            this.team2Score.TabIndex = 24;
            this.team2Score.Text = "0";
            this.team2Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(18, 374);
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
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // DateLbl
            // 
            this.DateLbl.AutoSize = true;
            this.DateLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DateLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.DateLbl.Location = new System.Drawing.Point(197, 332);
            this.DateLbl.Name = "DateLbl";
            this.DateLbl.Size = new System.Drawing.Size(62, 30);
            this.DateLbl.TabIndex = 10;
            this.DateLbl.Text = "DATE";
            // 
            // TiesLbl
            // 
            this.TiesLbl.AutoSize = true;
            this.TiesLbl.Font = new System.Drawing.Font("Quicksand Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TiesLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TiesLbl.Location = new System.Drawing.Point(288, 77);
            this.TiesLbl.Name = "TiesLbl";
            this.TiesLbl.Size = new System.Drawing.Size(41, 59);
            this.TiesLbl.TabIndex = 9;
            this.TiesLbl.Text = "-";
            // 
            // team1Score
            // 
            this.team1Score.AutoSize = true;
            this.team1Score.Font = new System.Drawing.Font("Quicksand Medium", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.team1Score.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.team1Score.Location = new System.Drawing.Point(196, 68);
            this.team1Score.Name = "team1Score";
            this.team1Score.Size = new System.Drawing.Size(59, 70);
            this.team1Score.TabIndex = 8;
            this.team1Score.Text = "0";
            this.team1Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(18, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 30);
            this.label8.TabIndex = 6;
            this.label8.Text = "DATE:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(19, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "TOURNAMENT:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(19, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 30);
            this.label6.TabIndex = 4;
            this.label6.Text = "ORGANIZATION:";
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatusLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.StatusLbl.Location = new System.Drawing.Point(207, 47);
            this.StatusLbl.MinimumSize = new System.Drawing.Size(200, 0);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(200, 30);
            this.StatusLbl.TabIndex = 26;
            this.StatusLbl.Text = "STATUS";
            this.StatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusImg
            // 
            this.StatusImg.Location = new System.Drawing.Point(246, -1);
            this.StatusImg.Name = "StatusImg";
            this.StatusImg.Size = new System.Drawing.Size(125, 92);
            this.StatusImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StatusImg.TabIndex = 27;
            this.StatusImg.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(56, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 30);
            this.label2.TabIndex = 50;
            this.label2.Text = "Match Details";
            // 
            // TeamsList
            // 
            this.TeamsList.BackColor = System.Drawing.Color.AliceBlue;
            this.TeamsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Tournament,
            this.Status,
            this.id});
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
            // Date
            // 
            this.Date.Tag = "";
            this.Date.Text = "Date";
            this.Date.Width = 169;
            // 
            // Tournament
            // 
            this.Tournament.Text = "Tournament";
            this.Tournament.Width = 379;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 169;
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 0;
            // 
            // MatchesForm
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
            this.Name = "MatchesForm";
            this.Text = "MatchesForm";
            this.Load += new System.EventHandler(this.MatchesForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.team2Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.team1Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusImg)).EndInit();
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
        private ColumnHeader Date;
        private ColumnHeader Tournament;
        private ColumnHeader Status;
        private PictureBox team1Img;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label DateLbl;
        private Label TiesLbl;
        private Label team1Score;
        private Button LoginBtn;
        private Label GameLbl;
        private Label label10;
        private Label team2Name;
        private Label team1Name;
        private PictureBox team2Img;
        private Label team2Score;
        private Label StatusLbl;
        private Label BestOfLbl;
        private PictureBox StatusImg;
        private PictureBox leftWin;
        private PictureBox rightWin;
        private Label TourLbl;
        private Label OrgLbl;
        private ColumnHeader id;
    }
}