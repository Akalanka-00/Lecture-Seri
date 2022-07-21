using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void label4_Click(object sender, EventArgs e)
        {
            if (signin)
            {
                signin = false;
                label4.Text = "Sign Up";
                label3.Text = "New User";
                label1.Text = "Sign In";
            }
            else
            {
                signin = true;
                label4.Text = "Sign In";
                label3.Text = "Already have an Account   ";
                label1.Text = "Sign Up";
            }

        }
    }
}
