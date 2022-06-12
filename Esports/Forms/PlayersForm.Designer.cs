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
            this.RegionSelect = new Esports.Components.CustomComboBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PlayerLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GameSelect = new Esports.Components.CustomComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.PlayerList = new System.Windows.Forms.ListView();
            this.Username1 = new System.Windows.Forms.ColumnHeader();
            this.Age1 = new System.Windows.Forms.ColumnHeader();
            this.Region1 = new System.Windows.Forms.ColumnHeader();
            this.Gender1 = new System.Windows.Forms.ColumnHeader();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegionSelect
            // 
            this.RegionSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.RegionSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.RegionSelect.BackColor = System.Drawing.SystemColors.Control;
            this.RegionSelect.BorderColor = System.Drawing.Color.Transparent;
            this.RegionSelect.BorderSize = 1;
            this.RegionSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.RegionSelect.Font = new System.Drawing.Font("Quicksand", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RegionSelect.ForeColor = System.Drawing.SystemColors.WindowText;
            this.RegionSelect.IconColor = System.Drawing.Color.DodgerBlue;
            this.RegionSelect.Items.AddRange(new object[] {
            "Asia-Pacific North",
            "Asia-Pacific South",
            "Brazil",
            "China",
            "Europe",
            "Korea",
            "Middle East",
            "North Africa",
            "North America",
            "Oceania",
            "South America",
            "Sub-Saharan Africa",
            "Turkey",
            "World"});
            this.RegionSelect.ListBackColor = System.Drawing.Color.AliceBlue;
            this.RegionSelect.ListTextColor = System.Drawing.SystemColors.WindowText;
            this.RegionSelect.Location = new System.Drawing.Point(317, 65);
            this.RegionSelect.MinimumSize = new System.Drawing.Size(0, 30);
            this.RegionSelect.Name = "RegionSelect";
            this.RegionSelect.Padding = new System.Windows.Forms.Padding(1);
            this.RegionSelect.Size = new System.Drawing.Size(283, 38);
            this.RegionSelect.TabIndex = 40;
            this.RegionSelect.Texts = "";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel10.Controls.Add(this.panel1);
            this.panel10.Location = new System.Drawing.Point(317, 102);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(296, 1);
            this.panel10.TabIndex = 43;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 1);
            this.panel1.TabIndex = 44;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Location = new System.Drawing.Point(15, 102);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 1);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Quicksand SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(317, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 34);
            this.label4.TabIndex = 46;
            this.label4.Text = "Region";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Quicksand SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(15, 19);
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
            this.GameSelect.Location = new System.Drawing.Point(15, 65);
            this.GameSelect.MinimumSize = new System.Drawing.Size(0, 30);
            this.GameSelect.Name = "GameSelect";
            this.GameSelect.Padding = new System.Windows.Forms.Padding(1);
            this.GameSelect.Size = new System.Drawing.Size(245, 38);
            this.GameSelect.TabIndex = 48;
            this.GameSelect.Texts = "";
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
            this.Username1,
            this.Age1,
            this.Region1,
            this.Gender1});
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
            // Username1
            // 
            this.Username1.Tag = "Numeric";
            this.Username1.Text = "Username";
            this.Username1.Width = 179;
            // 
            // Age1
            // 
            this.Age1.Text = "Age";
            this.Age1.Width = 179;
            // 
            // Region1
            // 
            this.Region1.Text = "Region";
            this.Region1.Width = 179;
            // 
            // Gender1
            // 
            this.Gender1.Text = "Gender";
            this.Gender1.Width = 179;
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.RegionSelect);
            this.Controls.Add(this.PlayerLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "PlayersForm";
            this.Text = "PlayersForm";
            this.Load += new System.EventHandler(this.PlayersForm_Load);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Components.CustomComboBox RegionSelect;
        private Panel panel10;
        private Panel panel1;
        private Panel panel2;
        private Label PlayerLbl;
        private Label label4;
        private Label label5;
        private Components.CustomComboBox GameSelect;
        private Panel panel3;
        private Label label2;
        private ListView PlayerList;
        private ColumnHeader Username1;
        private ColumnHeader Age1;
        private ColumnHeader Region1;
        private ColumnHeader Gender1;
    }
}