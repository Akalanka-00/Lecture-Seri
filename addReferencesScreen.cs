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
    public partial class addReferencesScreen : Form
    {
        public addReferencesScreen()
        {
            InitializeComponent();
        }

        private void initScreen()
        {
            lvlComboBox.SelectedIndex = 0;
            idComboBox.SelectedIndex = 0;
        }

        private void addReferencesScreen_Load(object sender, EventArgs e)
        {
            initScreen();
        }
    }
}
