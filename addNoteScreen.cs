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
    public partial class addNoteScreen : Form
    {
        public addNoteScreen()
        {
            InitializeComponent();
        }

        private void initScreen()
        {
            lvlComboBox.SelectedIndex = 0;
            idComboBox.SelectedIndex = 0;
        }

        private void addNotes_Load(object sender, EventArgs e)
        {

            initScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
