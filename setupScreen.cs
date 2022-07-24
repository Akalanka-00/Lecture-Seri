using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture_Seri
{
    public partial class setupScreen : Form
    {
        public setupScreen()
        {
            InitializeComponent();
        }

        private void setupScreen_Load(object sender, EventArgs e)
        {
            Console.WriteLine(uniSettings.Default.duration);
           
        }

        private void createFolders()
        {
            string dir = @""+ uniSettings.Default.index;
            // If directory does not exist, create it
            string[] paths = { dir, uniSettings.Default.uniID, "L1S1" };
            if (Directory.Exists(dir))
            {
                

                for(int i = 1; i < 5; i++)
                {
                    paths[2] = "L"+i + "S1";
                    string fullPAth = Path.Combine(paths);
                    Directory.CreateDirectory(fullPAth);

                    paths[2] = "L" + i + "S2";
                    fullPAth = Path.Combine(paths);
                    Directory.CreateDirectory(fullPAth);
                }
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            uniSettings.Default.uniID = uniTxtBox.Text;
            uniSettings.Default.uniName = degreeTxtBox.Text;
            uniSettings.Default.degree= mailTxtBox.Text;
            uniSettings.Default.faculty = pswTxtBox.Text;
            uniSettings.Default.index = pathTxtBox.Text;
            uniSettings.Default.duration = true;
            uniSettings.Default.Save();
            createFolders();

            HomeScreen hs = new HomeScreen();
            hs.Show();
            this.Hide();

           // Console.WriteLine(uniSettings.Default.uni);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker  = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                pathTxtBox.Text = dialog.FileName;
            }
        }

      
    }
}
