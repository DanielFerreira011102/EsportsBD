namespace Esports.Forms
{
    partial class EventsForm
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
            this.PlayerLbl = new System.Windows.Forms.Label();
            this.EventsList = new System.Windows.Forms.ListView();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.format = new System.Windows.Forms.ColumnHeader();
            this.Region = new System.Windows.Forms.ColumnHeader();
            this.Prize = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GameLbl = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.WinnerLbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.OrgLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EventDetailsBtn = new System.Windows.Forms.Button();
            this.NumTeamsLbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.FormatLbl = new System.Windows.Forms.Label();
            this.RegionLbl = new System.Windows.Forms.Label();
            this.PrizeLbl = new System.Windows.Forms.Label();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.EndLbl = new System.Windows.Forms.Label();
            this.StartLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GameSelect = new Esports.Components.CustomComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.PlayerLbl.Text = "Events";
            this.PlayerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventsList
            // 
            this.EventsList.BackColor = System.Drawing.Color.AliceBlue;
            this.EventsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.format,
            this.Region,
            this.Prize});
            this.EventsList.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EventsList.ForeColor = System.Drawing.Color.White;
            this.EventsList.FullRowSelect = true;
            this.EventsList.Location = new System.Drawing.Point(659, 69);
            this.EventsList.MultiSelect = false;
            this.EventsList.Name = "EventsList";
            this.EventsList.OwnerDraw = true;
            this.EventsList.Size = new System.Drawing.Size(720, 700);
            this.EventsList.TabIndex = 0;
            this.EventsList.UseCompatibleStateImageBehavior = false;
            this.EventsList.View = System.Windows.Forms.View.Details;
            this.EventsList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.sortByColumn);
            this.EventsList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.changeBackColor);
            this.EventsList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.justToCheck);
            this.EventsList.SelectedIndexChanged += new System.EventHandler(this.PlayerList_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Tag = "";
            this.name.Text = "Name";
            this.name.Width = 299;
            // 
            // format
            // 
            this.format.Text = "Format";
            this.format.Width = 149;
            // 
            // Region
            // 
            this.Region.Text = "Region";
            this.Region.Width = 159;
            // 
            // Prize
            // 
            this.Prize.Text = "Prize pool";
            this.Prize.Width = 88;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(42, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 30);
            this.label2.TabIndex = 54;
            this.label2.Text = "Event Details";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.GameLbl);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.WinnerLbl);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.OrgLbl);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.EventDetailsBtn);
            this.panel3.Controls.Add(this.NumTeamsLbl);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.NameLbl);
            this.panel3.Controls.Add(this.FormatLbl);
            this.panel3.Controls.Add(this.RegionLbl);
            this.panel3.Controls.Add(this.PrizeLbl);
            this.panel3.Controls.Add(this.StatusLbl);
            this.panel3.Controls.Add(this.EndLbl);
            this.panel3.Controls.Add(this.StartLbl);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lbl3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(21, 146);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(615, 623);
            this.panel3.TabIndex = 53;
            // 
            // GameLbl
            // 
            this.GameLbl.AutoSize = true;
            this.GameLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GameLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.GameLbl.Location = new System.Drawing.Point(202, 72);
            this.GameLbl.Name = "GameLbl";
            this.GameLbl.Size = new System.Drawing.Size(68, 30);
            this.GameLbl.TabIndex = 61;
            this.GameLbl.Text = "GAME";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(20, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 30);
            this.label14.TabIndex = 60;
            this.label14.Text = "GAME:";
            // 
            // WinnerLbl
            // 
            this.WinnerLbl.AutoSize = true;
            this.WinnerLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WinnerLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.WinnerLbl.Location = new System.Drawing.Point(201, 464);
            this.WinnerLbl.Name = "WinnerLbl";
            this.WinnerLbl.Size = new System.Drawing.Size(91, 30);
            this.WinnerLbl.TabIndex = 59;
            this.WinnerLbl.Text = "WINNER";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(20, 464);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 30);
            this.label11.TabIndex = 58;
            this.label11.Text = "WINNER:";
            // 
            // OrgLbl
            // 
            this.OrgLbl.AutoSize = true;
            this.OrgLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OrgLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.OrgLbl.Location = new System.Drawing.Point(201, 27);
            this.OrgLbl.Name = "OrgLbl";
            this.OrgLbl.Size = new System.Drawing.Size(55, 30);
            this.OrgLbl.TabIndex = 57;
            this.OrgLbl.Text = "ORG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(20, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 30);
            this.label3.TabIndex = 56;
            this.label3.Text = "ORGANIZATION:";
            // 
            // EventDetailsBtn
            // 
            this.EventDetailsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EventDetailsBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.EventDetailsBtn.FlatAppearance.BorderSize = 0;
            this.EventDetailsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EventDetailsBtn.Font = new System.Drawing.Font("Quicksand", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EventDetailsBtn.ForeColor = System.Drawing.Color.AliceBlue;
            this.EventDetailsBtn.Location = new System.Drawing.Point(103, 527);
            this.EventDetailsBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EventDetailsBtn.Name = "EventDetailsBtn";
            this.EventDetailsBtn.Size = new System.Drawing.Size(400, 61);
            this.EventDetailsBtn.TabIndex = 55;
            this.EventDetailsBtn.Text = "CHECK DETAILS";
            this.EventDetailsBtn.UseVisualStyleBackColor = false;
            // 
            // NumTeamsLbl
            // 
            this.NumTeamsLbl.AutoSize = true;
            this.NumTeamsLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumTeamsLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.NumTeamsLbl.Location = new System.Drawing.Point(202, 421);
            this.NumTeamsLbl.Name = "NumTeamsLbl";
            this.NumTeamsLbl.Size = new System.Drawing.Size(196, 30);
            this.NumTeamsLbl.TabIndex = 20;
            this.NumTeamsLbl.Text = "NUMBER OF TEAMS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(19, 421);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 30);
            this.label10.TabIndex = 19;
            this.label10.Text = "TEAMS:";
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.NameLbl.Location = new System.Drawing.Point(202, 115);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(69, 30);
            this.NameLbl.TabIndex = 14;
            this.NameLbl.Text = "NAME";
            // 
            // FormatLbl
            // 
            this.FormatLbl.AutoSize = true;
            this.FormatLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormatLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.FormatLbl.Location = new System.Drawing.Point(202, 159);
            this.FormatLbl.Name = "FormatLbl";
            this.FormatLbl.Size = new System.Drawing.Size(93, 30);
            this.FormatLbl.TabIndex = 13;
            this.FormatLbl.Text = "FORMAT";
            // 
            // RegionLbl
            // 
            this.RegionLbl.AutoSize = true;
            this.RegionLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RegionLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.RegionLbl.Location = new System.Drawing.Point(202, 203);
            this.RegionLbl.Name = "RegionLbl";
            this.RegionLbl.Size = new System.Drawing.Size(86, 30);
            this.RegionLbl.TabIndex = 12;
            this.RegionLbl.Text = "REGION";
            // 
            // PrizeLbl
            // 
            this.PrizeLbl.AutoSize = true;
            this.PrizeLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PrizeLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.PrizeLbl.Location = new System.Drawing.Point(202, 247);
            this.PrizeLbl.Name = "PrizeLbl";
            this.PrizeLbl.Size = new System.Drawing.Size(67, 30);
            this.PrizeLbl.TabIndex = 11;
            this.PrizeLbl.Text = "PRIZE";
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatusLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.StatusLbl.Location = new System.Drawing.Point(201, 377);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(84, 30);
            this.StatusLbl.TabIndex = 10;
            this.StatusLbl.Text = "STATUS";
            // 
            // EndLbl
            // 
            this.EndLbl.AutoSize = true;
            this.EndLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EndLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.EndLbl.Location = new System.Drawing.Point(201, 334);
            this.EndLbl.Name = "EndLbl";
            this.EndLbl.Size = new System.Drawing.Size(53, 30);
            this.EndLbl.TabIndex = 9;
            this.EndLbl.Text = "END";
            // 
            // StartLbl
            // 
            this.StartLbl.AutoSize = true;
            this.StartLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.StartLbl.Location = new System.Drawing.Point(202, 291);
            this.StartLbl.Name = "StartLbl";
            this.StartLbl.Size = new System.Drawing.Size(73, 30);
            this.StartLbl.TabIndex = 8;
            this.StartLbl.Text = "START";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(20, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 30);
            this.label9.TabIndex = 7;
            this.label9.Text = "REGION:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(19, 377);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 30);
            this.label8.TabIndex = 6;
            this.label8.Text = "STATUS:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(20, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "END:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(20, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 30);
            this.label6.TabIndex = 4;
            this.label6.Text = "START:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(20, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "PRIZE POOL:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl3.Location = new System.Drawing.Point(20, 115);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(73, 30);
            this.lbl3.TabIndex = 2;
            this.lbl3.Text = "NAME:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(20, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "FORMAT:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Location = new System.Drawing.Point(21, 106);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(601, 1);
            this.panel2.TabIndex = 51;
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
            this.GameSelect.Location = new System.Drawing.Point(21, 69);
            this.GameSelect.MinimumSize = new System.Drawing.Size(0, 30);
            this.GameSelect.Name = "GameSelect";
            this.GameSelect.Padding = new System.Windows.Forms.Padding(1);
            this.GameSelect.Size = new System.Drawing.Size(588, 38);
            this.GameSelect.TabIndex = 52;
            this.GameSelect.Texts = "";
            this.GameSelect.OnSelectedIndexChanged += new System.EventHandler(this.GameSelect_OnSelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Quicksand SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(21, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 34);
            this.label5.TabIndex = 56;
            this.label5.Text = "Game";
            // 
            // EventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 768);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.GameSelect);
            this.Controls.Add(this.EventsList);
            this.Controls.Add(this.PlayerLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "EventsForm";
            this.Text = "EventsForm";
            this.Load += new System.EventHandler(this.EventsForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label PlayerLbl;
        private ListView EventsList;
        private ColumnHeader name;
        private ColumnHeader format;
        private ColumnHeader Region;
        private ColumnHeader Prize;
        private Label label2;
        private Panel panel3;
        private Label NumTeamsLbl;
        private Label label10;
        private Label NameLbl;
        private Label FormatLbl;
        private Label RegionLbl;
        private Label PrizeLbl;
        private Label StatusLbl;
        private Label EndLbl;
        private Label StartLbl;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label lbl3;
        private Label label1;
        private Panel panel2;
        private Components.CustomComboBox GameSelect;
        private Button EventDetailsBtn;
        private Label label5;
        private Label OrgLbl;
        private Label label3;
        private Label GameLbl;
        private Label label14;
        private Label WinnerLbl;
        private Label label11;
    }
}