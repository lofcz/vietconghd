using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vrc
{
    public partial class Form1 : Form
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private Font playFont;
        private Font labelsFont;
        private Font checksFont;

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }

        public Form1()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;

            mainPanel.Parent = bgPicture;
            bottomPanel.Parent = bgPicture;
            rightPanel.Parent = bgPicture;

            PostprocessingQualityLabel.Parent = mainPanel;
            PostprocessingQuality.Parent = mainPanel;
            ImprovedSoundCheck.Parent = mainPanel;
            ImprovedSoundCheck.Parent = mainPanel;
            ShowFps.Parent = mainPanel;
            ForceVsync.Parent = mainPanel;
            DisableTransVegetation.Parent = mainPanel;
            DisableImprovedSounds.Parent = mainPanel;
            RankedMultiplayer.Parent = mainPanel;
            PlayLabel.Parent = rightPanel;
            ExitCheckbox.Parent = rightPanel;


            InitFonts();


            PostprocessingQualityLabel.Font = labelsFont;
            ImprovedSoundCheck.Font = checksFont;
            ShowFps.Font = checksFont;
            ForceVsync.Font = checksFont;
            DisableTransVegetation.Font = checksFont;
            DisableImprovedSounds.Font = checksFont;
            RankedMultiplayer.Font = checksFont;
            ExitCheckbox.Font = checksFont;

            PlayClassicButton.Font = labelsFont;
            PlayFistAlpha.Font = labelsFont;
            HelpButton.Font = labelsFont;

            PlayLabel.Font = playFont;
            
            TryFindGame();
        }

        void TryFindGame()
        {
            if (!File.Exists("vrc.json"))
            {
                File.WriteAllText("vrc.json", "{}");
            }

            string data = File.ReadAllText("vrc.json");
            
            
        }

        void InitFonts()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();

            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            byte[] font = Properties.Resources.fontItalics;

            int fontLength = font.Length;

            // create a buffer to read in to
            byte[] fontdata = font;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

            FontFamily mainFont = pfc.Families[0];

            int labelsFontSize = 11;
            labelsFont = new Font(mainFont, labelsFontSize, FontStyle.Italic);

            int checksFontSize = 10;
            checksFont = new Font(mainFont, checksFontSize, FontStyle.Italic);
            
            int playFontSize = 12;
            playFont = new Font(mainFont, playFontSize, FontStyle.Italic);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PostprocessingQuality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        
        private void bgPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        
        private void bgPicture_Click(object sender, EventArgs e)
        {

        }

        private void PlayClassicButton_Click(object sender, EventArgs e)
        {
            
        }

        private void PlayLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void ExitCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}