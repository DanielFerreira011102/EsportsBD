namespace Esports.Forms
{
    partial class OrgsForm
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
            this.OrgsList = new System.Windows.Forms.ListView();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.contact = new System.Windows.Forms.ColumnHeader();
            this.OrgProfile = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ContactLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.DetailsBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OrgProfile)).BeginInit();
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
            this.PlayerLbl.Text = "Organizations";
            this.PlayerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OrgsList
            // 
            this.OrgsList.BackColor = System.Drawing.Color.AliceBlue;
            this.OrgsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.contact});
            this.OrgsList.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OrgsList.ForeColor = System.Drawing.Color.White;
            this.OrgsList.FullRowSelect = true;
            this.OrgsList.Location = new System.Drawing.Point(659, 69);
            this.OrgsList.Name = "OrgsList";
            this.OrgsList.OwnerDraw = true;
            this.OrgsList.Size = new System.Drawing.Size(720, 700);
            this.OrgsList.TabIndex = 0;
            this.OrgsList.UseCompatibleStateImageBehavior = false;
            this.OrgsList.View = System.Windows.Forms.View.Details;
            this.OrgsList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.sortByColumn);
            this.OrgsList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.changeBackColor);
            this.OrgsList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.justToCheck);
            this.OrgsList.SelectedIndexChanged += new System.EventHandler(this.PlayerList_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Tag = "";
            this.name.Text = "Name";
            this.name.Width = 359;
            // 
            // contact
            // 
            this.contact.Text = "Contact";
            this.contact.Width = 359;
            // 
            // OrgProfile
            // 
            this.OrgProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OrgProfile.Location = new System.Drawing.Point(160, 30);
            this.OrgProfile.Name = "OrgProfile";
            this.OrgProfile.Size = new System.Drawing.Size(291, 271);
            this.OrgProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OrgProfile.TabIndex = 0;
            this.OrgProfile.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(33, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "NAME:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(33, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 30);
            this.label9.TabIndex = 7;
            this.label9.Text = "CONTACT:";
            // 
            // ContactLbl
            // 
            this.ContactLbl.AutoSize = true;
            this.ContactLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ContactLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ContactLbl.Location = new System.Drawing.Point(149, 386);
            this.ContactLbl.MaximumSize = new System.Drawing.Size(440, 0);
            this.ContactLbl.Name = "ContactLbl";
            this.ContactLbl.Size = new System.Drawing.Size(105, 30);
            this.ContactLbl.TabIndex = 12;
            this.ContactLbl.Text = "CONTACT";
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.NameLbl.Location = new System.Drawing.Point(149, 328);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(69, 30);
            this.NameLbl.TabIndex = 14;
            this.NameLbl.Text = "NAME";
            // 
            // DetailsBtn
            // 
            this.DetailsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DetailsBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.DetailsBtn.FlatAppearance.BorderSize = 0;
            this.DetailsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DetailsBtn.Font = new System.Drawing.Font("Quicksand", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DetailsBtn.ForeColor = System.Drawing.Color.AliceBlue;
            this.DetailsBtn.Location = new System.Drawing.Point(109, 554);
            this.DetailsBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DetailsBtn.Name = "DetailsBtn";
            this.DetailsBtn.Size = new System.Drawing.Size(400, 61);
            this.DetailsBtn.TabIndex = 16;
            this.DetailsBtn.Text = "CHECK DETAILS";
            this.DetailsBtn.UseVisualStyleBackColor = false;
            this.DetailsBtn.Click += new System.EventHandler(this.DetailsBtn_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.DetailsBtn);
            this.panel3.Controls.Add(this.NameLbl);
            this.panel3.Controls.Add(this.ContactLbl);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.OrgProfile);
            this.panel3.Location = new System.Drawing.Point(13, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(615, 700);
            this.panel3.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(47, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 30);
            this.label2.TabIndex = 50;
            this.label2.Text = "Organization Details";
            // 
            // OrgsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 768);
            this.Controls.Add(this.OrgsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PlayerLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "OrgsForm";
            this.Text = "OrgsForm";
            this.Load += new System.EventHandler(this.OrgsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrgProfile)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label PlayerLbl;
        private ListView OrgsList;
        private ColumnHeader name;
        private ColumnHeader contact;
        private PictureBox OrgProfile;
        private Label label3;
        private Label label9;
        private Label ContactLbl;
        private Label NameLbl;
        private Button DetailsBtn;
        private Panel panel3;
        private Label label2;
    }
}