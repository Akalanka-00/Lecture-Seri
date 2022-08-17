using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;

namespace Lecture_Seri.Services
{
    public partial class CaptureScreen : Form
    {
        public CaptureScreen()
        {
            InitializeComponent();
        }

        private void captureBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            takeScreenCapture();
            this.Show();
        }

        private void takeScreenCapture()
        {
            DateTime now = DateTime.Now;
            string fimeName = $"IMG_{now:yyyyMMdd_HHmmssms}";
           // MessageBox.Show(fimeName);

            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                               Screen.PrimaryScreen.Bounds.Height,
                               PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);

            // Save the screenshot to the specified path that the user has chosen.
            bmpScreenshot.Save("E:\\Study\\UOM\\Lectures\\L2S1\\IN2310 - Operating Systems\\20220817\\" + fimeName+".png", ImageFormat.Png);
        }

        
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
