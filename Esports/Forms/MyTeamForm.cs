using System.Data;
using System.Data.SqlClient;
using Esports.Classes;
using System.Diagnostics;
using System.Globalization;

namespace Esports.Forms
{

    public partial class MyTeamForm : Form
    {

        private SqlConnection cn;
        private ListViewColumnSorter lvwColumnSorter;
        private string user;
        private string twitter, twitch;

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

        public MyTeamForm()
        {
            InitializeComponent();
            cn = getSGBDConnection();
        }

        public MyTeamForm(string user) : this()
        {
            this.user = user;
            checkStage();
        }

        private void checkStage()
        {

            if (!verifySGBDConnection())
                return;

            // check if ign is already registered to a different user
            SqlCommand cmd2 = new SqlCommand("SELECT dbo.CheckUserHasTeam(@Username)", cn);
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@Username", user);
            Boolean hasTeam = (bool)cmd2.ExecuteScalar();

            if (hasTeam)
            {
                OpenThirdStage();
                cn.Close();
                return;
            }

            // check if ign is already registered to a different user
            SqlCommand cmd1 = new SqlCommand("SELECT dbo.CheckUserHasTeamJoinRequest(@Username)", cn);
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("@Username", user);
            Boolean hasTeamJoinRequest = (bool)cmd1.ExecuteScalar();

            if (hasTeamJoinRequest)
            {
                OpenSecondStage();
                cn.Close();
                return;
            }

            cn.Close();

            OpenFirstStage();

        }

        private void CreateTeamBtn_Click(object sender, EventArgs e)
        {
            if (GameSelect.SelectedIndex == -1
                || string.IsNullOrEmpty(PlayerIGNLbl.Text)
                || string.IsNullOrEmpty(TeamNameLbl.Text))
            {
                MessageBox.Show("Please fill mandatory fields!");
                return;
            }    

            if (!verifySGBDConnection())
                return;

            // check if ign is already registered to a different user
            SqlCommand cmd = new SqlCommand("SELECT dbo.CheckIGNRegistered(@IGN, @Game, @Username)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@IGN", PlayerIGNLbl.Text);
            cmd.Parameters.AddWithValue("@Game", GameSelect.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Username", user);
            Boolean IGNRegistered = (bool)cmd.ExecuteScalar();

            if (IGNRegistered)
            {
                MessageBox.Show("Selected IGN already registered!");
                return;
            }

            // check if the team name is already registered
            SqlCommand cmd4 = new SqlCommand("SELECT dbo.CheckTeamExists(@Team, @Game)", cn);
            cmd4.Parameters.Clear();
            cmd4.Parameters.AddWithValue("@Team", TeamNameLbl.Text);
            cmd4.Parameters.AddWithValue("@Game", GameSelect.SelectedItem.ToString());
            Boolean TeamRegistered = (bool)cmd4.ExecuteScalar();

            if (TeamRegistered)
            {
                MessageBox.Show("Selected Team name already registered!");
                return;
            }

            // check if player already exists
            SqlCommand cmd0 = new SqlCommand("SELECT dbo.CheckPlayerExists(@Username)", cn);
            cmd0.Parameters.Clear();
            cmd0.Parameters.AddWithValue("@Username", user);
            Boolean UserExist = (bool)cmd0.ExecuteScalar();

            // if so, then just create team and update player
            if (UserExist)
            {
                SqlCommand cmd1 = new SqlCommand("EXEC createTeamPlayerExists @TeamName=@team, @TeamLogo=@logo, @IGN=@ign, @Game=@game, @User=@username", cn);
                cmd1.Parameters.Clear();
                cmd1.Parameters.AddWithValue("@ign", PlayerIGNLbl.Text);
                cmd1.Parameters.AddWithValue("@team", TeamNameLbl.Text);
                cmd1.Parameters.AddWithValue("@logo", TeamLogoUrl.Text);
                cmd1.Parameters.AddWithValue("@game", GameSelect.SelectedItem.ToString());
                cmd1.Parameters.AddWithValue("@username", user);

                try
                {
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to update team of player. \n ERROR MESSAGE: \n" + ex.Message);
                }
            }
            // else, then create team and player
            else
            {
                SqlCommand cmd2 = new SqlCommand("EXEC createTeamPlayerDoesNotExist @TeamName=@team, @TeamLogo=@logo, @IGN=@ign, @Game=@game, @User=@username", cn);
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@ign", PlayerIGNLbl.Text);
                cmd2.Parameters.AddWithValue("@team", TeamNameLbl.Text);
                cmd2.Parameters.AddWithValue("@logo", TeamLogoUrl.Text);
                cmd2.Parameters.AddWithValue("@game", GameSelect.SelectedItem.ToString());
                cmd2.Parameters.AddWithValue("@username", user);

                try
                {
                    cmd2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to create team of player. \n ERROR MESSAGE: \n" + ex.Message);
                }
            }

            cn.Close();
            this.FirstStage.Visible = false;
            OpenThirdStage();

        }

        private void OpenThirdStage()
        {
            this.ThirdStage.Visible = true;
            lvwColumnSorter = new ListViewColumnSorter();
            this.MembersList.ListViewItemSorter = lvwColumnSorter;
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            MembersList.GridLines = true;
            LoadBDMembers();
            // Perform the sort with these new sort options.
            this.MembersList.Sort();
            MembersList.Items[0].Selected = true;
            MembersList.Select();
        }

        private void JoinRequestBtn_Click(object sender, EventArgs e)
        {
            if (GameSelectJoin.SelectedIndex == -1
                || string.IsNullOrEmpty(TeamNameJoinLbl.Text))
            {
                MessageBox.Show("Please fill mandatory fields!");
                return;
            }

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT dbo.CheckTeamExists(@Team, @Game)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Team", TeamNameJoinLbl.Text);
            cmd.Parameters.AddWithValue("@Game", GameSelectJoin.SelectedItem.ToString());
            Boolean TeamRegistered = (bool)cmd.ExecuteScalar();

            if (!TeamRegistered)
            {
                MessageBox.Show("Selected team does not exist!");
                return;
            }

            // check if ign is already registered to a different user
            SqlCommand cmd2 = new SqlCommand("SELECT dbo.CheckIGNRegistered(@IGN, @Game, @Username)", cn);
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@IGN", IGNJoinLbl.Text);
            cmd2.Parameters.AddWithValue("@Game", GameSelectJoin.SelectedItem.ToString());
            cmd2.Parameters.AddWithValue("@Username", user);
            Boolean IGNRegistered = (bool)cmd2.ExecuteScalar();

            if (IGNRegistered)
            {
                MessageBox.Show("Selected IGN already registered!");
                return;
            }

            // check if ign is already registered to a different user
            SqlCommand cmd3 = new SqlCommand("SELECT dbo.CheckUserHasTeam(@Username)", cn);
            cmd3.Parameters.Clear();
            cmd3.Parameters.AddWithValue("@Username", user);
            Boolean hasTeam = (bool)cmd2.ExecuteScalar();

            if (hasTeam)
            {
                MessageBox.Show("Brother, u already have a team...");
                return;
            }

            SqlCommand cmd1 = new SqlCommand("EXEC createTeamPlayerJoinRequest @TeamName=@team, @Game=@game, @IGN=@ign, @User=@username", cn);
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("@team", TeamNameJoinLbl.Text);
            cmd1.Parameters.AddWithValue("@ign", IGNJoinLbl.Text);
            cmd1.Parameters.AddWithValue("@game", GameSelectJoin.SelectedItem.ToString());
            cmd1.Parameters.AddWithValue("@username", user);

            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create request. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }

            this.FirstStage.Visible = false;
            OpenSecondStage();
        }

        private void OpenSecondStage()
        {
            this.SecondStage.Visible = true;
            messageLbl.Text = "Your request to join team " + TeamNameJoinLbl.Text + " was successful.\nWaiting for a response";
        }

        private void OpenFirstStage()
        {
            clearFieldsStage1();
            this.FirstStage.Visible = true;
        }

        private void OpenFifthStage()
        {
            this.FifthStage.Visible = true;
            lvwColumnSorter = new ListViewColumnSorter();
            this.RequestsList.ListViewItemSorter = lvwColumnSorter;
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            RequestsList.GridLines = true;
            LoadBDRequests();
            // Perform the sort with these new sort options.
            this.RequestsList.Sort();
            RequestsList.Items[0].Selected = true;
            RequestsList.Select();
        }

        private void LoadBDRequests()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM getTeamRequests(@Username)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Username", user);
            SqlDataReader reader = cmd.ExecuteReader();

            RequestsList.Items.Clear();

            while (reader.Read())
            {
                string username = reader["username"].ToString();
                ListViewItem item = new(username);
                string role = reader["role"].ToString();
                string team = reader["team"].ToString();
                string ign = reader["IGN"].ToString();

                item.SubItems.Add(role);
                item.SubItems.Add(team);
                item.SubItems.Add(ign);

                foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                {
                    sub.ForeColor = System.Drawing.Color.Black;
                    sub.Font = new System.Drawing.Font("Quicksand", 8, System.Drawing.FontStyle.Regular);
                }

                RequestsList.Items.Add(item);

            }

            // Close reader 
            reader.Close();

            cn.Close();
        }

        private void OpenFourthStage()
        {
            this.FourthStage.Visible = true;
            this.EditList.ListViewItemSorter = lvwColumnSorter;
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            EditList.GridLines = true;
            LoadBDEditMembers();
            // Perform the sort with these new sort options.
            this.EditList.Sort();
            EditList.Items[0].Selected = true;
            EditList.Select();

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd1 = new SqlCommand("DELETE FROM TEAM_JOIN_REQUEST WHERE username = @user", cn);
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("@user", user);

            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete join request. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }

            this.SecondStage.Visible=false;
            OpenFirstStage();
        }

        private void clearFieldsStage1()
        {
            GameSelect.SelectedItem = null;
            GameSelectJoin.SelectedItem = null;
            IGNJoinLbl.Text = string.Empty;
            PlayerIGNLbl.Text = string.Empty;
            TeamLogoUrl.Text = string.Empty;
            TeamNameJoinLbl.Text = string.Empty;
            TeamNameLbl.Text = string.Empty;

        }

        private void LoadBDEditMembers()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd0 = new SqlCommand("SELECT dbo.getTeamCaptain(@Username)", cn);
            cmd0.Parameters.Clear();
            cmd0.Parameters.AddWithValue("@Username", user);
            string captain = (string)cmd0.ExecuteScalar();


            SqlCommand cmd = new SqlCommand("SELECT * FROM getTeamMembers(@Username)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Username", user);
            SqlDataReader reader = cmd.ExecuteReader();

            EditList.Items.Clear();

            while (reader.Read())
            {
                string username = reader["username"].ToString();
                ListViewItem item = new(username);
                string role = reader["role"].ToString();

                item.SubItems.Add(role);

                foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                {
                    sub.ForeColor = System.Drawing.Color.Black;
                    sub.Font = new System.Drawing.Font("Quicksand", 8, System.Drawing.FontStyle.Regular);
                }

                EditList.Items.Add(item);

            }

            // Close reader 
            reader.Close();

            cn.Close();
        }




        private void LoadBDMembers()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd0 = new SqlCommand("SELECT dbo.getTeamCaptain(@Username)", cn);
            cmd0.Parameters.Clear();
            cmd0.Parameters.AddWithValue("@Username", user);
            string captain = (string)cmd0.ExecuteScalar();

            SqlCommand cmd9 = new SqlCommand("SELECT dbo.getNotificationsCount(@Username)", cn);
            cmd9.Parameters.Clear();
            cmd9.Parameters.AddWithValue("@Username", user);
            int number = (int)cmd9.ExecuteScalar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM getTeamMembers(@Username)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Username", user);
            SqlDataReader reader = cmd.ExecuteReader();

            MembersList.Items.Clear();

            while (reader.Read())
            {
                string username = reader["username"].ToString();
                ListViewItem item = new(username);
                string role = reader["role"].ToString();

                if (username == user)
                    if (role == "Manager" || username == captain)
                    {
                        editBtn.Visible = true;
                        DeleteTeamBtn.Visible = true;
                        if (number > 0)
                        {
                            notficationNum.Text = (number > 9)? "9+" : number.ToString();
                            notficationNum.Visible = true;
                            notificationIcon.Visible = true;
                        }
                    } 

                item.SubItems.Add(role);

                foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                {
                    sub.ForeColor = System.Drawing.Color.Black;
                    sub.Font = new System.Drawing.Font("Quicksand", 8, System.Drawing.FontStyle.Regular);
                }

                MembersList.Items.Add(item);

            }

            // Close reader 
            reader.Close();

            SqlCommand cmd1 = new SqlCommand("SELECT * FROM getTeamInfoFromUsername(@Username)", cn);
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("@Username", user);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                NameLbl.Text = reader1["name"].ToString();
                RankLbl.Text = reader1["ranking"].ToString();
                EarningsLbl.Text = reader1["earnings"].ToString();
                TiesLbl.Text = reader1["ties"].ToString();

                LossesLbl.Text = reader1["losses"].ToString();
                WinsLbl.Text = reader1["wins"].ToString();
                GameLbl.Text = reader1["game"].ToString();
                string? prof = reader1["logo_url"].ToString();
                try { TeamProfile.Load(prof); }
                catch { TeamProfile.Image = Properties.Resources.notfound; }


            }

            reader1.Close();

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
            this.MembersList.Sort();
        }

        private void TeamDetailsBtn_Click(object sender, EventArgs e)
        {

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            this.ThirdStage.Visible = false;
            OpenFourthStage();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            FourthStage.Visible = false;
            OpenThirdStage();
        }

        private void EditList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (EditList.SelectedIndices.Count > 0)
            {
                string un = EditList.SelectedItems[0].SubItems[0].Text;
                string role = EditList.SelectedItems[0].SubItems[1].Text;

                PlayerPanel.Visible = false;
                StaffPanel.Visible = false;

                if (role == "Player")
                    readPlayer(un);
                else
                    readStaff(un, role);
            }
        }

        private void readStaff(string un, string rl)
        {
            StaffPanel.Visible = true;

            if (rl == "Manager")
            {
                removeBtn.Visible = false;
            }
            else
            {
                removeBtn.Visible = true;
            }

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM getExtendedTeamStaffInfo(@Username)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Username", un);
            SqlDataReader reader = cmd.ExecuteReader();

            UnStaff.Text = EditList.SelectedItems[0].SubItems[0].Text;
            StaffRoleLbl.Text = EditList.SelectedItems[0].SubItems[1].Text;

            while (reader.Read())
            {
                StaffExpLbl.Text = reader["years_experience"].ToString() + " years";
                StaffNameLbl.Text = reader["real_name"].ToString();
                StaffTeamLbl.Text = reader["team"].ToString();

                string? dt = reader["team_join_date"].ToString();

                StaffDateLbl.Text = string.IsNullOrEmpty(dt) ? null : dt.Split(" ")[0];
            }

            reader.Close();

            cn.Close();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            string un = EditList.SelectedItems[0].SubItems[0].Text;
            string role = EditList.SelectedItems[0].SubItems[1].Text;


            if (role == "Player")
                removePlayer(un);
            else
                removeStaff(un);
        }

        private void removePlayer(string un)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd2 = new SqlCommand("EXEC removePlayerFromTeam @Username=@user", cn);
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@user", un);

            try
            {
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to remove player from team. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }

            MessageBox.Show(un + "was removed from the team!");
            EditList.SelectedItems[0].Remove();
            EditList.Items[0].Selected = true;
            EditList.Select();
        }

        private void removeStaff(string un)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd2 = new SqlCommand("EXEC removeStaffFromTeam @Username=@user", cn);
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@user", un);

            try
            {
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to remove staff from team. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }

            MessageBox.Show(un + "was removed from the team!");
            EditList.SelectedItems[0].Remove();
            EditList.Items[0].Selected = true;
            EditList.Select();
        }

        private void FifthStage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void notificationIcon_Click(object sender, EventArgs e)
        {
            ThirdStage.Visible = false;
            OpenFifthStage();
        }

        private void notficationNum_Click(object sender, EventArgs e)
        {
            ThirdStage.Visible = false;
            OpenFifthStage();
        }

        private void RequestsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            IGNREQ.Visible = false;
            IGNReqLbl.Visible = false;

            if (RequestsList.SelectedIndices.Count > 0)
            {
                string un = RequestsList.SelectedItems[0].SubItems[0].Text;
                string role = RequestsList.SelectedItems[0].SubItems[1].Text;
                string team = RequestsList.SelectedItems[0].SubItems[2].Text;
                string? ign = RequestsList.SelectedItems[0].SubItems[3].Text;


                if (role == "Player")
                {
                    IGNREQ.Visible = true;
                    IGNReqLbl.Visible = true;
                }

                UserReqLbl.Text = un;
                RoleReqLbl.Text= role;
                TeamReqLbl.Text = team;
                IGNReqLbl.Text = ign;
            }
        }

        private void ACCEPTREQUEST_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            // check if player already exists
            SqlCommand cmd0 = new SqlCommand("SELECT dbo.CheckPlayerExists(@Username)", cn);
            cmd0.Parameters.Clear();
            cmd0.Parameters.AddWithValue("@Username", UserReqLbl.Text);
            Boolean UserExist = (bool)cmd0.ExecuteScalar();

            // if so, then just create team and update player
            if (UserExist)
            {
                if (RoleReqLbl.Text == "Player") { 
                    SqlCommand cmd1 = new SqlCommand("EXEC acceptTeamPlayerExists @IGN = @ign @User = @username", cn);
                    cmd1.Parameters.Clear();
                    cmd1.Parameters.AddWithValue("@ign", IGNReqLbl.Text);
                    cmd1.Parameters.AddWithValue("@username", UserReqLbl.Text);

                    try
                    {
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Failed to accept request. \n ERROR MESSAGE: \n" + ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("EXEC acceptTeamStaffExists @Role=@role @User=@username", cn);
                    cmd1.Parameters.Clear();
                    cmd1.Parameters.AddWithValue("@role", RoleReqLbl.Text);
                    cmd1.Parameters.AddWithValue("@username", UserReqLbl.Text);

                    try
                    {
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Failed to accept request. \n ERROR MESSAGE: \n" + ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
            }
            // else, then create team and player
            else
            {
                if (RoleReqLbl.Text == "Player")
                {
                    SqlCommand cmd2 = new SqlCommand("EXEC acceptPlayerDoesNotExist @IGN=@ign, @User=@username", cn);
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.AddWithValue("@ign", IGNReqLbl.Text);
                    cmd2.Parameters.AddWithValue("@username", UserReqLbl.Text);

                    try
                    {
                        cmd2.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Failed to accept request. \n ERROR MESSAGE: \n" + ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("EXEC acceptTeamStaffDoesNotExist @Role=@role @User=@username", cn);
                    cmd1.Parameters.Clear();
                    cmd1.Parameters.AddWithValue("@role", RoleReqLbl.Text);
                    cmd1.Parameters.AddWithValue("@username", UserReqLbl.Text);

                    try
                    {
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Failed to accept request. \n ERROR MESSAGE: \n" + ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
            }

            MessageBox.Show(UserReqLbl.Text + " was added to the team!");
            RequestsList.SelectedItems[0].Remove();
            RequestsList.Items[0].Selected = true;
            RequestsList.Select();
        }

        private void GOBACK_Click(object sender, EventArgs e)
        {
            FifthStage.Visible = false;
            OpenThirdStage();
        }

        private void DeleteTeamBtn_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd1 = new SqlCommand("EXEC deleteTeam @Username=@username", cn);
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("@username", user);

            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete team. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }

            this.ThirdStage.Visible = false;
            OpenFirstStage();
        }

        private void readPlayer(string un)
        {
            PlayerPanel.Visible = true;

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM getExtendedPlayerInfo(@Username)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Username", un);
            SqlDataReader reader = cmd.ExecuteReader();

            UsernameLbl.Text = EditList.SelectedItems[0].SubItems[0].Text;

            while (reader.Read())
            {
                TeamLbl.Text = reader["team"].ToString();
                MyPlayerRank.Text = reader["ranking"].ToString();
                PlayerGameLbl.Text = reader["game"].ToString();
                RealNameLbl.Text = reader["real_name"].ToString();
                IGNLbl.Text = reader["IGN"].ToString();

                string? prof = reader["profile_url"].ToString();
                try { MyPlayerPic.Load(prof); }
                catch { MyPlayerPic.Image = Properties.Resources.notfound; }

                twitter = reader["twitter_url"].ToString();
                twitch = reader["twitch_url"].ToString();

                String? country = reader["country"].ToString();

                if (!string.IsNullOrEmpty(country))
                {
                    RegionInfo myRI1 = new RegionInfo(country);
                    country = myRI1.EnglishName;
                }

                CountryLbl.Text = country;

                string? dt = reader["team_join_date"].ToString();

                JoinDateLbl.Text = string.IsNullOrEmpty(dt) ? null : dt.Split(" ")[0];


            }

            reader.Close();

            SqlCommand cmd2 = new SqlCommand("SELECT dbo.checkPlayerIGL(@Username)", cn);
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@Username", UsernameLbl.Text);
            Boolean isIGL = (bool)cmd2.ExecuteScalar();

            if (isIGL)
            {
                IGLStar.Image = Properties.Resources.IGL;
                IGLStar.BringToFront();
                removeBtn.Visible = false;
            }
            else
            {
                IGLStar.Image = null;
                IGLStar.SendToBack();
                removeBtn.Visible=true;
            }

            cn.Close();
        }
    }
}
