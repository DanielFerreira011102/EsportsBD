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
            this.panel2 = new System.Windows.Forms.Panel();
            this.PlayerLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GameSelect = new Esports.Components.CustomComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.PlayerList = new System.Windows.Forms.ListView();
            this.rank = new System.Windows.Forms.ColumnHeader();
            this.IGN = new System.Windows.Forms.ColumnHeader();
            this.Team = new System.Windows.Forms.ColumnHeader();
            this.Country = new System.Windows.Forms.ColumnHeader();
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
            this.panel3.Location = new System.Drawing.Point(22, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(615, 609);
            this.panel3.TabIndex = 49;
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
    }
}