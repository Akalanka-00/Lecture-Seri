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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loadedPanel.Width += 30;

            if (loadedPanel.Width % 20 == 0)
            {
                if (loadingLabel.Text == "Loading...")
                {
                    loadingLabel.Text = "Loading.";
                }
                else if (loadingLabel.Text == "Loading.")
                {
                    loadingLabel.Text = "Loading..";
                }
                else if (loadingLabel.Text == "Loading..")
                {
                    loadingLabel.Text = "Loading...";
                }
                // Thread.Sleep(1000);
            }


            if (loadedPanel.Width >= 800)
            {
                timer1.Stop();
             

               
                    HomeScreen hs = new HomeScreen();
                    hs.Show();
                

                this.Hide();
            }
         

         
        }
    }
}
