using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTextFunctions;
using System.IO;
using System.Media;

namespace PineapplePainter
{
    public partial class Form1 : Form
    {
        public int PineappleX;
        public int PineappleY;
        public int PineappleSize;
        public Image PineappleImageCurSize = Properties.Resources.Pineapple___1526x890;
        public bool backgroundLoaded;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\PineapplePainter\\");
            SimpleTextFunctions.TextFuncions StringHelper = new SimpleTextFunctions.TextFuncions();
            string Test = ("Hallo" + StringHelper.NL);
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Picture Files | *.png;*.jpg;*.gif;*.bmp";
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            backgroundLoaded = false;
            Image TempMage = Image.FromFile(openFileDialog1.FileName);
            //Max Image size: 1536; 1152
            if (TempMage.Width <= 1536 && TempMage.Height <= 1152)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                backgroundLoaded = true;

            }
            else
            {

                MessageBox.Show("For simplicity reasons, please select a picture that fits into the frame (max-size: 1536x1152). For this application it is crutial that the scale is correct so that the pineapple can be placed correctly! Please choose again!", "Image too big!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private static System.IO.MemoryStream cursorMemoryStream = new System.IO.MemoryStream(Properties.Resources.PineappleCursor);

        private Cursor PineappleCursor = new Cursor(cursorMemoryStream);

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (backgroundLoaded)
            {
                //pictureBox1.Cursor = PineappleCursor;
                var coordinates = pictureBox1.PointToClient(Cursor.Position);
                PineappleX = coordinates.X+1;
                PineappleY = coordinates.Y;
                //pictureBox2.Image = PineappleImageCurSize;
                //pictureBox2.Width = PineappleImageCurSize.Width;
                //pictureBox2.Height = PineappleImageCurSize.Height;
                //pictureBox2.Left = PineappleX;
                //pictureBox2.Top = PineappleY;
                //pictureBox2.Visible = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static FileInfo GetNewestFile(DirectoryInfo directory)
        {
            return directory.GetFiles()
                .Union(directory.GetDirectories().Select(d => GetNewestFile(d)))
                .OrderByDescending(f => (f == null ? DateTime.MinValue : f.LastWriteTime))
                .FirstOrDefault();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null && pictureBox1.Enabled == true)
            {
                //used for getting the right place for the pineapple
                var coordinates = pictureBox1.PointToClient(Cursor.Position);

                PineappleX = coordinates.X;
                PineappleY = coordinates.Y;



                using (Graphics grfx = Graphics.FromImage(pictureBox1.Image))
                {
                    //draws the pineapple!
                    grfx.DrawImage(PineappleImageCurSize, PineappleX, PineappleY);

                    //defines a tempImage
                    Image TempImageSaving = pictureBox1.Image;

                    //saves the
                    string CurTime = DateTime.Now.Ticks.ToString();
                    if (pictureBox1.Enabled == true)
                    {
                        TempImageSaving.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\PineapplePainter\\" + CurTime + "-Temp.png");
                    }


                    //shows the pic!
                    FileInfo newestFile = GetNewestFile(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\PineapplePainter\\"));
                    string newestFilePath = newestFile.FullName.ToString();
                    pictureBox1.Image = Image.FromFile(newestFilePath);


                }

            }
            else
            {
                //do nothing
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PineappleImageCurSize = Properties.Resources.Pineapple___1526x890;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            PineappleImageCurSize = Properties.Resources.Pineapple___90_percent;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            PineappleImageCurSize = Properties.Resources.Pineapple___80_percent;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            PineappleImageCurSize = Properties.Resources.Pineapple___70_percent;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            PineappleImageCurSize = Properties.Resources.Pineapple___60_percent;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            PineappleImageCurSize = Properties.Resources.Pineapple___50_percent;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            PineappleImageCurSize = Properties.Resources.Pineapple___40_percent;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            PineappleImageCurSize = Properties.Resources.Pineapple___30_percent;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            PineappleImageCurSize = Properties.Resources.Pineapple___20_percent;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            PineappleImageCurSize = Properties.Resources.Pineapple___10_percent;
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            PineappleImageCurSize = Properties.Resources.Pineapple___1_percent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Picture Files | *.png;*.jpg;*.gif;*.bmp";
            saveFileDialog1.ShowDialog();
            pictureBox1.Image.Save(saveFileDialog1.FileName);
            MessageBox.Show("Saving Successfull!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
