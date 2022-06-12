using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esports.Classes
{
	[Serializable()]
	public class User
	{
		private String _username;
		private String _password;
		private String _email;
		private String _birthday;
		private String _region;
		private String _gender;
		private String _age;

		public String Username
		{
			get { return _username; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Username field can’t be empty");
					return;
				}
				_username = value;
			}
		}


		public String Password
		{
			get { return _password; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Password field can’t be empty");
					return;
				}
				_password = value;
			}
		}

		public String Email
		{
			get { return _email; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Email field can’t be empty");
					return;
				}
				_email = value;
			}
		}

		public String Birthday
		{
			get { return _birthday; }
			set { _birthday = value; }
		}

		public String Age
		{
			get { return _age; }
			set { _age = value; }
		}

		public String Region
		{
			get { return _region; }
			set { _region = value; }
		}

		public String Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}

		public override String ToString()
		{
			return _username;
		}

		public User() : base()
		{
		}

		public User(String Username, String Age, String Region, String Gender) : base()
		{
			this.Username = Username;
			this.Age = Age;
			this.Region	= Region;
			this.Gender = Gender;
		}

        public User(String Username, String Password, String Email) : base()
		{
			this.Username = Username;
			this.Password = Password;
			this.Email = Email;
		}

		public User(String Username) : base()
		{
			this.Username = Username;
		}
    }
}
