using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vrc
{
    public partial class Form1 : Form
    {
        private Font labelsFont;
        private Font checksFont;
        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp=base.CreateParams;
                cp.ExStyle|=0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }
        
        public Form1()
        {
            InitializeComponent();

            mainPanel.Parent = bgPicture;
            bottomPanel.Parent = bgPicture;
            rightPanel.Parent = bgPicture;
            
            PostprocessingQualityLabel.Parent = mainPanel;
            ImprovedSoundCheck.Parent = mainPanel;

            
            
            InitFonts();


            PostprocessingQualityLabel.Font = labelsFont;
            ImprovedSoundCheck.Font = checksFont;
            ShowFps.Font = checksFont;
            ForceVsync.Font = checksFont;
            DisableTransVegetation.Font = checksFont;
            DisableImprovedSounds.Font = checksFont;
            RankedMultiplayer.Font = checksFont;

            PlayClassicButton.Font = labelsFont;
            PlayFistAlpha.Font = labelsFont;
            HelpButton.Font = labelsFont;
        }

        void InitFonts()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            FontFamily mainFont;
            
            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            var font = Properties.Resources.fontItalics;
            
            int fontLength = font.Length;

            // create a buffer to read in to
            byte[] fontdata = font;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

            mainFont = pfc.Families[0];
            
            int labelsFontSize = 11;
            labelsFont = new Font(mainFont, labelsFontSize, FontStyle.Italic);
            
            int checksFontSize = 10;
            checksFont = new Font(mainFont, checksFontSize, FontStyle.Italic);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}