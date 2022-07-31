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

namespace Lecture_Seri.special_function_screens
{
    public partial class ScreenCaptureScreen : Form
    {
        public ScreenCaptureScreen()
        {
            InitializeComponent();
        }

        private void ScreenCaptureScreen_Load(object sender, EventArgs e)
        {
            string path = Path.Combine(uniSettings.Default.location,uniSettings.Default.uniName);
            var directories = Directory.GetDirectories(path);
            lvlCombo.Items.Clear();
            foreach (var d in directories)
            {
               FileInfo file = new FileInfo(d);
                lvlCombo.Items.Add(file.Name);
              //  MessageBox.Show(path);
            }
            lvlCombo.SelectedIndex = 0;
        }

        private void lvlCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = Path.Combine(uniSettings.Default.location, uniSettings.Default.uniName);
            path = Path.Combine(path, lvlCombo.SelectedItem.ToString());
            var directories = Directory.GetDirectories(path);
            courseNameCombo.Items.Clear();
            if(directories.Length > 0)
            {
                foreach (var d in directories)
                {
                    FileInfo file = new FileInfo(d);
                    courseNameCombo.Items.Add(file.Name);
                      MessageBox.Show(path);
                }
                if(directories.Length > 0)
                courseNameCombo.SelectedIndex = 0;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            screenCaptureBackground.RunWorkerAsync();

        }

        private void screenCaptureBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            ConsoleKey key;
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something, but don't read key here
                }

                // Key is available - read it
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.PrintScreen)
                {
                    MessageBox.Show("captured");
                }
                else if (key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine(ConsoleKey.NumPad1.ToString());
                }

            } while (key != ConsoleKey.Escape);
        }
    }
}
