using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using Esports.Classes;
using System.Diagnostics;

namespace Esports.Forms
{
    public partial class LoginOrRegistForm : Form
    {
        private SqlConnection cn;

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

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public LoginOrRegistForm()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            this.ControlBox = false;
            cn = getSGBDConnection();
        }

        private void LoginOrRegistForm_Load(object sender, EventArgs e)
        {
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void miniBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameLog.Text;
            string password = PasswordLog.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password are required!");
                return;
            }
                

            if (CheckUserMatchPassword(username, password))
            {
                MainForm MenuForm = new(username, getUserRegion(username), "LOG");
                MenuForm.Show();
                Hide();
                MessageBox.Show("Login successful!");
            }
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            User u = SaveUser();
            if (u != null)
            {
                MainForm MenuForm = new(u.Username, u.Region, "REG");
                MenuForm.Show();
                Hide();
            }
        }

        private User? SaveUser()
        {
            User user = new User();
            try
            {
                // Obrigatório
                user.Username = UsernameReg.Text;
                user.Password = PasswordReg.Text;
                user.Email = EmailReg.Text;
    
                user.Birthday = BirthdayReg.Format == DateTimePickerFormat.Long? BirthdayReg.Value.ToString("yyyy-MM-dd") : null;
                user.Region = RegionReg.SelectedIndex != -1? RegionReg.SelectedItem.ToString() : "World";
                user.Gender = GenderReg.SelectedIndex != -1? GenderReg.SelectedItem.ToString()?.Substring(0,1).ToUpper() : null;

                if (user.Gender != null && (user.Gender != "F" && user.Gender != "M"))
                {
                    MessageBox.Show("Invalid input for field gender!");
                    return null;
                }

                if (!IsValidEmail(user.Email))
                {
                    MessageBox.Show("Invalid input for field email!");
                    return null;
                }

                Debug.WriteLine(user.Username);
                Debug.WriteLine(user.Password);
                Debug.WriteLine(user.Email);
                Debug.WriteLine(user.Birthday);
                Debug.WriteLine(user.Region);
                Debug.WriteLine(user.Gender);

                if (!checkUserExists(user.Username, user.Email))
                    return null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            InsertUser(user);
            return user;
        }

        private void InsertUser(User U)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT [USER] (username, password, email, join_date, " + "birthday, region, gender) " + "VALUES (@Username, @Password, @Email, @JoinDate, " + "@Birthday, @Region, @Gender) ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Username", U.Username);
            cmd.Parameters.AddWithValue("@Password", U.Password);
            cmd.Parameters.AddWithValue("@Email", U.Email);
            cmd.Parameters.AddWithValue("@JoinDate", DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Birthday", !string.IsNullOrEmpty(U.Birthday) ? U.Birthday : DBNull.Value);
            cmd.Parameters.AddWithValue("@Region", U.Region);
            cmd.Parameters.AddWithValue("@Gender", !string.IsNullOrEmpty(U.Gender) ? U.Gender : DBNull.Value);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to insert user in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private bool checkUserExists(String username, String email)
        {
            if (!verifySGBDConnection())
                return false;

            SqlCommand cmd = new SqlCommand("SELECT dbo.CheckUserExists(@Username, @Email)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Email", email);
            Boolean UserExist = (bool)cmd.ExecuteScalar();

            if (UserExist)
            {
                MessageBox.Show("Username or email already taken!");
                return false;
            }

            return true;
        }

        private bool CheckUserMatchPassword(String username, String password)
        {
            if (!verifySGBDConnection())
                return false;

            SqlCommand cmd = new SqlCommand("SELECT dbo.CheckUserMatchPassword(@Username, @Password)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            Boolean UserExist = (bool)cmd.ExecuteScalar();

            if (!UserExist)
            {
                MessageBox.Show("Wrong username or password!");
                return false;
            }

            return true;
        }

        private String getUserRegion(String username)
        {
            if (!verifySGBDConnection())
                return "World";

            SqlCommand cmd = new SqlCommand("SELECT region FROM [USER] WHERE username = @Username", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Username", username);

            return (string)cmd.ExecuteScalar();
        }

        private void BirthdayReg_ValueChanged(object sender, EventArgs e)
        {
            BirthdayReg.Format = System.Windows.Forms.DateTimePickerFormat.Long;
        }

        private void EyeCloseLog_Click(object sender, EventArgs e)
        {
            if (PasswordLog.PasswordChar == '*')
            {
                EyeOpenLog.BringToFront();
                PasswordLog.PasswordChar = '\0';
            }
        }

        private void EyeOpenLog_Click(object sender, EventArgs e)
        {
            if (PasswordLog.PasswordChar != '*')
            {
                EyeCloseLog.BringToFront();
                PasswordLog.PasswordChar = '*';
            }
        }

        private void EyeOpenReg_Click(object sender, EventArgs e)
        {
            if (PasswordReg.PasswordChar != '*')
            {
                EyeCloseReg.BringToFront();
                PasswordReg.PasswordChar = '*';
            }
        }

        private void EyeCloseReg_Click(object sender, EventArgs e)
        {
            if (PasswordReg.PasswordChar == '*')
            {
                EyeOpenReg.BringToFront();
                PasswordReg.PasswordChar = '\0';
            }
        }

        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
