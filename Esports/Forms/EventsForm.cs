using System.Data;
using System.Data.SqlClient;
using Esports.Classes;
using System.Diagnostics;
using System.Globalization;

namespace Esports.Forms
{

    public partial class EventsForm : Form
    {

        private SqlConnection cn;
        private ListViewColumnSorter lvwColumnSorter;

        private SqlConnection getSGBDConnection()
        {
            //return new SqlConnection("data source= CCWIN8\\SQL2012EXPRESS;integrated security=true;initial catalog=Northwind");
            SqlConnection CN = new SqlConnection("data source=mednat.ieeta.pt\\SQLSERVER,8101; initial catalog=p5g5;User id=p5g5;password=@Aveiro123");

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

        public EventsForm()
        {
            InitializeComponent();
            cn = getSGBDConnection();

            lvwColumnSorter = new ListViewColumnSorter();
            this.EventsList.ListViewItemSorter = lvwColumnSorter;

            EventsList.GridLines = true;
            GameSelect.SelectedItem = "CS:GO";
            LoadBDPlayers();
        }

        private void EventsForm_Load(object sender, EventArgs e)
        {
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            // Perform the sort with these new sort options.
            this.EventsList.Sort();

            EventsList.Items[0].Selected = true;
            EventsList.Select();
        }

        private void LoadBDPlayers()
        {
            if (!verifySGBDConnection())
                return;

            if (GameSelect.SelectedIndex == -1)
                GameSelect.SelectedItem = "CS:GO";

            SqlCommand cmd = new SqlCommand("SELECT * FROM getGameEventData(@Game)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@GAME", GameSelect.SelectedItem);
            SqlDataReader reader = cmd.ExecuteReader();

            EventsList.Items.Clear();

            while (reader.Read())
            {

                ListViewItem item = new(reader["name"].ToString());

                String? format = reader["format"].ToString();
                String? region = reader["region"].ToString();
                String? prize = reader["prize_pool"].ToString();

                item.SubItems.Add(format);
                item.SubItems.Add(region);
                item.SubItems.Add(prize);

                foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                {
                    sub.ForeColor = System.Drawing.Color.Black;
                    sub.Font = new System.Drawing.Font("Quicksand", 8, System.Drawing.FontStyle.Regular);
                }

                EventsList.Items.Add(item);

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
            this.EventsList.Sort();
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

        private void GameSelect_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBDPlayers();
            EventsList.Items[0].Selected = true;
            EventsList.Select();
        }

        private void PlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!verifySGBDConnection())
                return;

            if (EventsList.SelectedIndices.Count > 0)
            {
                NameLbl.Text = EventsList.SelectedItems[0].SubItems[0].Text;
                GameLbl.Text = GameSelect.SelectedItem.ToString();
                FormatLbl.Text = EventsList.SelectedItems[0].SubItems[1].Text;
                RegionLbl.Text = EventsList.SelectedItems[0].SubItems[2].Text;
                PrizeLbl.Text = '$' + EventsList.SelectedItems[0].SubItems[3].Text;

                SqlCommand cmd = new SqlCommand("SELECT * FROM getEventInfo(@Name)", cn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", NameLbl.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    OrgLbl.Text = reader["organization"].ToString();
                    StatusLbl.Text = reader["status"].ToString();
                    StartLbl.Text = reader["start_date"].ToString();
                    EndLbl.Text = reader["end_date"].ToString();
                    NumTeamsLbl.Text = reader["number_teams"].ToString();
                }

                reader.Close();

                SqlCommand cmd2 = new SqlCommand("SELECT dbo.getWinner(@Name)", cn);
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@name", NameLbl.Text);
                WinnerLbl.Text = cmd.ExecuteScalar().ToString();

            }

            cn.Close();

        }

    }
}
