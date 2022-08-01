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
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void addUni()
        {
            UniversityScreen us = new UniversityScreen();
            us.Show();
        }
        private void newCourse()
        {
            newCourseScreen ncs = new newCourseScreen();
            ncs.Show();
        }

        private void newNote()
        {
            addNoteScreen ans = new addNoteScreen();
            ans.Show();
        }

        private void newReference()
        {
            addReferencesScreen arf = new addReferencesScreen();
            arf.Show();
        }

        private void newRecord()
        {
            recordingScreen rs = new recordingScreen();
            rs.Show();
        }

        private void signIn()
        {
            signInScreen sis = new signInScreen();
            sis.Show();
        }

        public Image byteArrayToImage(byte[] source)
        {
            MemoryStream ms = new MemoryStream(source);
            Image ret = Image.FromStream(ms);
            return ret;
        }

        private void screenCapture()
        {
            special_function_screens.ScreenCaptureScreen sc = new special_function_screens.ScreenCaptureScreen();
            sc.Show();
        }

        private void loadAvatar()
        {
            Image img;
            byte[] imageArray;
            String avatarTxt = userSettings.Default.Avatar;
           if(avatarTxt != "")
            {
                imageArray = Convert.FromBase64String(avatarTxt);
                img = byteArrayToImage(imageArray);
                avatarShape.Image = img;
            }
            else
            {
                
            }
          

        }

        private void loadCourses()
        {
            string path = Path.Combine(uniSettings.Default.location, uniSettings.Default.uniName);
            path = Path.Combine(path, lvlComboBox.SelectedItem.ToString());
            var directories = Directory.GetDirectories(path);
            courseListView.Items.Clear();
            foreach (var d in directories)
            {
                FileInfo file = new FileInfo(d);
                courseListView.Items.Add(file.Name);
                //  MessageBox.Show(path);
            }
          //  courseListView.SelectedIndex = 0;


            
        }

        private void loadItems()
        {
          // string MyString = ;
         /*  char[] MyChar = { '{', '}' };
            string NewString = MyString.TrimStart(MyChar);
            NewString = MyString.TrimEnd(MyChar);
         */
            string path = Path.Combine(uniSettings.Default.location, uniSettings.Default.uniName);
            path = Path.Combine(path, lvlComboBox.SelectedItem.ToString());
            path = Path.Combine(path, courseListView.SelectedItems[0].Text);
            path = Path.Combine(path, materialSelectBox.SelectedItem.ToString());
           // MessageBox.Show(path);
            var directories = Directory.GetFiles(path);
            itemListView.Items.Clear();
            foreach (var d in directories)
            {
                FileInfo file = new FileInfo(d);
                itemListView.Items.Add(file.Name);
                //  MessageBox.Show(path);
            }
            //  itemListView
        }



        private void newLectureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lectureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newCourse();
        }

        private void notesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newNote();
        }

        private void lectureReferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newReference();
        }

        private void recordingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newRecord();
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            lvlComboBox.SelectedIndex = 0;
            materialSelectBox.SelectedIndex = 0;
            loadAvatar();

            if (userSettings.Default.access == false)
            {
                signIn();
            }
            loadCourses();
        }

        private void SignInToolBtn_Click(object sender, EventArgs e)
        {
            signIn();
        }

        private void exitToolBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HomeScreen_Activated(object sender, EventArgs e)
        {
            loadAvatar();
        }

        private void addUniversityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addUni();
        }

        private void avatarShape_Click(object sender, EventArgs e)
        {
            userSettings.Default.access = false;
            userSettings.Default.Save();
        }

        private void screenCapturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            screenCapture();
        }

        private void lvlComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCourses();
        }

        private void courseListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadItems();
        }

        private void materialSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(courseListView.SelectedItems.Count > 0)
            loadItems();
        }
    }
}
