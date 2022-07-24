using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture_Seri
{
    public partial class signInScreen : Form
    {
        public signInScreen()
        {
            InitializeComponent();
        }

        bool signin = true;
		Bitmap image;
		String basae64Text = "";
		MySqlConnection conn;
		MySqlCommand cmd;
		public static string[] Names = new string[]
	{
	"Afghanistan",
	"Albania",
	"Algeria",
	"American Samoa",
	"Andorra",
	"Angola",
	"Anguilla",
	"Antarctica",
	"Antigua and Barbuda",
	"Argentina",
	"Armenia",
	"Aruba",
	"Australia",
	"Austria",
	"Azerbaijan",
	"Bahamas",
	"Bahrain",
	"Bangladesh",
	"Barbados",
	"Belarus",
	"Belgium",
	"Belize",
	"Benin",
	"Bermuda",
	"Bhutan",
	"Bolivia",
	"Bosnia and Herzegovina",
	"Botswana",
	"Bouvet Island",
	"Brazil",
	"British Indian Ocean Territory",
	"Brunei Darussalam",
	"Bulgaria",
	"Burkina Faso",
	"Burundi",
	"Cambodia",
	"Cameroon",
	"Canada",
	"Cape Verde",
	"Cayman Islands",
	"Central African Republic",
	"Chad",
	"Chile",
	"China",
	"Christmas Island",
	"Cocos (Keeling) Islands",
	"Colombia",
	"Comoros",
	"Congo",
	"Congo, the Democratic Republic of the",
	"Cook Islands",
	"Costa Rica",
	"Cote D'Ivoire",
	"Croatia",
	"Cuba",
	"Cyprus",
	"Czech Republic",
	"Denmark",
	"Djibouti",
	"Dominica",
	"Dominican Republic",
	"Ecuador",
	"Egypt",
	"El Salvador",
	"Equatorial Guinea",
	"Eritrea",
	"Estonia",
	"Ethiopia",
	"Falkland Islands (Malvinas)",
	"Faroe Islands",
	"Fiji",
	"Finland",
	"France",
	"French Guiana",
	"French Polynesia",
	"French Southern Territories",
	"Gabon",
	"Gambia",
	"Georgia",
	"Germany",
	"Ghana",
	"Gibraltar",
	"Greece",
	"Greenland",
	"Grenada",
	"Guadeloupe",
	"Guam",
	"Guatemala",
	"Guinea",
	"Guinea-Bissau",
	"Guyana",
	"Haiti",
	"Heard Island and Mcdonald Islands",
	"Holy See (Vatican City State)",
	"Honduras",
	"Hong Kong",
	"Hungary",
	"Iceland",
	"India",
	"Indonesia",
	"Iran, Islamic Republic of",
	"Iraq",
	"Ireland",
	"Israel",
	"Italy",
	"Jamaica",
	"Japan",
	"Jordan",
	"Kazakhstan",
	"Kenya",
	"Kiribati",
	"Korea, Democratic People's Republic of",
	"Korea, Republic of",
	"Kuwait",
	"Kyrgyzstan",
	"Lao People's Democratic Republic",
	"Latvia",
	"Lebanon",
	"Lesotho",
	"Liberia",
	"Libyan Arab Jamahiriya",
	"Liechtenstein",
	"Lithuania",
	"Luxembourg",
	"Macao",
	"Macedonia, the Former Yugoslav Republic of",
	"Madagascar",
	"Malawi",
	"Malaysia",
	"Maldives",
	"Mali",
	"Malta",
	"Marshall Islands",
	"Martinique",
	"Mauritania",
	"Mauritius",
	"Mayotte",
	"Mexico",
	"Micronesia, Federated States of",
	"Moldova, Republic of",
	"Monaco",
	"Mongolia",
	"Montserrat",
	"Morocco",
	"Mozambique",
	"Myanmar",
	"Namibia",
	"Nauru",
	"Nepal",
	"Netherlands",
	"Netherlands Antilles",
	"New Caledonia",
	"New Zealand",
	"Nicaragua",
	"Niger",
	"Nigeria",
	"Niue",
	"Norfolk Island",
	"Northern Mariana Islands",
	"Norway",
	"Oman",
	"Pakistan",
	"Palau",
	"Palestinian Territory, Occupied",
	"Panama",
	"Papua New Guinea",
	"Paraguay",
	"Peru",
	"Philippines",
	"Pitcairn",
	"Poland",
	"Portugal",
	"Puerto Rico",
	"Qatar",
	"Reunion",
	"Romania",
	"Russian Federation",
	"Rwanda",
	"Saint Helena",
	"Saint Kitts and Nevis",
	"Saint Lucia",
	"Saint Pierre and Miquelon",
	"Saint Vincent and the Grenadines",
	"Samoa",
	"San Marino",
	"Sao Tome and Principe",
	"Saudi Arabia",
	"Senegal",
	"Serbia and Montenegro",
	"Seychelles",
	"Sierra Leone",
	"Singapore",
	"Slovakia",
	"Slovenia",
	"Solomon Islands",
	"Somalia",
	"South Africa",
	"South Georgia and the South Sandwich Islands",
	"Spain",
	"Sri Lanka",
	"Sudan",
	"Suriname",
	"Svalbard and Jan Mayen",
	"Swaziland",
	"Sweden",
	"Switzerland",
	"Syrian Arab Republic",
	"Taiwan, Province of China",
	"Tajikistan",
	"Tanzania, United Republic of",
	"Thailand",
	"Timor-Leste",
	"Togo",
	"Tokelau",
	"Tonga",
	"Trinidad and Tobago",
	"Tunisia",
	"Turkey",
	"Turkmenistan",
	"Turks and Caicos Islands",
	"Tuvalu",
	"Uganda",
	"Ukraine",
	"United Arab Emirates",
	"United Kingdom",
	"United States",
	"United States Minor Outlying Islands",
	"Uruguay",
	"Uzbekistan",
	"Vanuatu",
	"Venezuela",
	"Viet Nam",
	"Virgin Islands, British",
	"Virgin Islands, US",
	"Wallis and Futuna",
	"Western Sahara",
	"Yemen",
	"Zambia",
	"Zimbabwe",
	};


		private void sqlConn()
		{
			string server = "localhost";
			string database = "lecture_seri";
			string username = "root";
			string password = "pass@123";
			string port = "3306";

			string conString = "SERVER=" + server + ";" +"PORT="+ port + ";"+ "DATABASE=" + database + ";" + "USER=" + username + ";" + "PASSWORD=" + password+";";

			conn = new MySqlConnection(conString);
			conn.Open();
		}
		private bool signupValidation()
		{
			bool valid = false;
            if (signUpUsernameTxt.Text.Length>0)
            {
				string query = "select user_name from UserInfo where user_name = '" + signUpUsernameTxt.Text+"';";
				cmd = new MySqlCommand(query,conn);
				MySqlDataReader reader = cmd.ExecuteReader();
				int count=0;
				while (reader.Read())
                {
					count++;
                }
				if (count == 0) { 
					valid = true;
					
				}
                else
                {
					MessageBox.Show("Usesrname is already exist");
				}
				reader.Close();

            }

			return valid;


		}

		private void logging()
        {
			string query = "select * from UserInfo where user_name = '" + signinUsernameTxt.Text + "' AND psw ='"+signInPswTxt.Text+"';";
			cmd = new MySqlCommand(query, conn);
			MySqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{

				userSettings.Default.id = reader[0].ToString();
				userSettings.Default.Username = reader[1].ToString();
				userSettings.Default.Password = reader[2].ToString();
				userSettings.Default.Avatar = reader[3].ToString();
				userSettings.Default.country = reader[4].ToString();
				userSettings.Default.mail = reader[5].ToString();

				MessageBox.Show("Logged In");
			}
			MessageBox.Show(query);
			HomeScreen hs = new HomeScreen();
			this.Close();
		}

		private string userID()
        {
			return "C0002";
        }

		private void saveSignUpSqlData()
        {
			string query = "Insert Into UserInfo (user_id, user_name, psw , avatar, country, email)" +
				"values ('" + userID() + "', '" + signUpUsernameTxt.Text + "', '" + signUpPswTxt.Text + "', '" + basae64Text + "', '" + countryCombo.SelectedItem.ToString() + "', '" + signUpMailTxt.Text + "')";

			cmd = new MySqlCommand(query, conn);
			cmd.ExecuteNonQuery();
			MessageBox.Show("Usesrname added");
			conn.Close();
		}

		private void label4_Click(object sender, EventArgs e)
        {
            if (signin)
            {
                signin = false;
                label4.Text = "Sign Up";
                label3.Text = "New User";
                label1.Text = "Sign In";
                movingPanel.Width = 568;
            }
            else
            {
                signin = true;
                label4.Text = "Sign In";
                label3.Text = "Already have an Account   ";
                label1.Text = "Sign Up";
                movingPanel.Width = 0;
            }

        }

        private void signInScreen_Load(object sender, EventArgs e)
        {
			sqlConn();

			movingPanel.Width = 0;
			countryCombo.SelectedIndex = 0;
			hideWarnings();

		}

		private void setAvatar()
        {
			OpenFileDialog open = new OpenFileDialog();
			// image filters  
			open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
			if (open.ShowDialog() == DialogResult.OK)
			{
				// display image in picture box  
				avatar.Image = new Bitmap(open.FileName);
				// image file path  
				image = new Bitmap(open.FileName);
				byte[] imageArray = System.IO.File.ReadAllBytes(open.FileName);
				basae64Text = Convert.ToBase64String(imageArray);

			}
		}

		private void saveData()
        {
			userSettings.Default.Avatar = basae64Text;
			userSettings.Default.Username = signUpUsernameTxt.Text;
			userSettings.Default.Password = signUpPswTxt.Text;
			userSettings.Default.country = countryCombo.SelectedItem.ToString();
			userSettings.Default.mail = signUpMailTxt.Text;
			userSettings.Default.access = true;

			userSettings.Default.Save();
        }
      

        private void addAvatarBtn_Click_1(object sender, EventArgs e)
        {
			setAvatar();
		}

        private void signupBtn_Click(object sender, EventArgs e)
        {
            if (signupValidation()==true)
            {
				saveData();
				saveSignUpSqlData();
				HomeScreen hs = new HomeScreen();
				this.Close();
			}
			
        }

		private void hideWarnings()
        {
			warningSignupUsername.Visible = false;
			warningSignupPsw.Visible = false;
			warningSignupPsw2.Visible = false;
			warningSignupCountry.Visible = false;
			warningSignupEmail.Visible = false;

			warningSigninUsername.Visible = false;
			warningSigninPsw.Visible=false;

		}

        private void removeAvatarBtn_Click(object sender, EventArgs e)
        {
			avatar.Image = Lecture_Seri.Properties.Resources.avatar;

		}

        private void signInBtn_Click(object sender, EventArgs e)
        {
			logging();

		}
    }
}
