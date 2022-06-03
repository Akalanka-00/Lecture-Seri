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
    public partial class newCourseScreen : Form
    {
        public newCourseScreen()
        {
            InitializeComponent();
        }

        private void createFolders()
        {
            string dir = @"" + uniSettings.Default.localPath;
            // If directory does not exist, create it
            string[] paths = { dir, uniSettings.Default.uni, lvlComboBox.SelectedItem.ToString(),idTxtBox.Text+"-"+nameTxtBox.Text,"type" };
            string[] materials = { "Screen Captures", "Recordings", "Assignments", "Lecture Materials" };
            foreach (string path in paths)
            {
                Console.WriteLine(path);
            }
            if (Directory.Exists(dir))
            {


                for (int i = 0; i < 4; i++)
                {
                    paths[4] =materials[i];
                    string fullPAth = Path.Combine(paths);
                    Directory.CreateDirectory(fullPAth);
                   
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void newCourseScreen_Load(object sender, EventArgs e)
        {
            lvlComboBox.SelectedIndex = 0;
            gpaComboBox.SelectedIndex = 0;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            createFolders();
        }
    }
}
