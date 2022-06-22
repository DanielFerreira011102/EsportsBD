﻿using System.Data;
using System.Data.SqlClient;
using Esports.Classes;
using System.Diagnostics;
using System.Globalization;

namespace Esports.Forms
{

    public partial class OrgsForm : Form
    {

        private SqlConnection cn;
        private ListViewColumnSorter lvwColumnSorter;

        private SqlConnection getSGBDConnection()
        {
            //return new SqlConnection("data source= CCWIN8\\SQL2012EXPRESS;integrated security=true;initial catalog=Northwind");
            SqlConnection CN = new SqlConnection("data source=LAPTOP-C8296JRI\\SQLEXPRESS;Database=Esports;Trusted_Connection=True");

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    //MessageBox.Show("Successful connection to database " + CN.Database + " on the " + CN.DataSource + " server", "Connection Test", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FAILED TO OPEN CONNECTION TO DATABASE DUE TO THE FOLLOWING ERROR \r\n" + ex.Message, "Connection Test", MessageBoxButtons.OK);
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();

            return CN;
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        public OrgsForm()
        {
            InitializeComponent();
            cn = getSGBDConnection();

            lvwColumnSorter = new ListViewColumnSorter();
            this.OrgsList.ListViewItemSorter = lvwColumnSorter;

            OrgsList.GridLines = true;
            LoadBDPlayers();        
        }

        private void OrgsForm_Load(object sender, EventArgs e)
        {
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            // Perform the sort with these new sort options.
            this.OrgsList.Sort();

            OrgsList.Items[0].Selected = true;
            OrgsList.Select();
        }

        private void LoadBDPlayers()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT [name], contact FROM ORGANIZATION", cn);
            SqlDataReader reader = cmd.ExecuteReader();

            OrgsList.Items.Clear();

            while (reader.Read())
            {

                ListViewItem item = new(reader["name"].ToString());

                String? contact = reader["contact"].ToString();

                item.SubItems.Add(contact);

                foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                {
                    sub.ForeColor = System.Drawing.Color.Black;
                    sub.Font = new System.Drawing.Font("Quicksand", 8, System.Drawing.FontStyle.Regular);
                }

                OrgsList.Items.Add(item);

            }

            // Close reader 
            reader.Close();

            cn.Close();
        }

        private void sortByColumn(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.OrgsList.Sort();
        }

        private void changeBackColor(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DodgerBlue, e.Bounds);
            e.Graphics.DrawString(e.Header.Text, new Font("Quicksand", 10, FontStyle.Regular),
                Brushes.White, e.Bounds);
            //e.DrawText();

        }

        private void justToCheck(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void PlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!verifySGBDConnection())
                return;

            if (OrgsList.SelectedIndices.Count > 0)
            {
                NameLbl.Text = OrgsList.SelectedItems[0].SubItems[0].Text;
                ContactLbl.Text = OrgsList.SelectedItems[0].SubItems[1].Text;

                SqlCommand cmd = new SqlCommand("SELECT dbo.getOrgLogo(@name)", cn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", NameLbl.Text);
                string? prof = cmd.ExecuteScalar().ToString();

                try { OrgProfile.Load(prof); }
                catch { OrgProfile.Image = Properties.Resources.notfound; }

            }

            cn.Close();

        }

    }
}
