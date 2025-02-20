using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Exception = System.Exception;

namespace Vrc
{
    public class QualityItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public QualityItem(string text, int value)
        {
            Text = text;
            Value = value;
        }
    }

    
    public partial class Form1 : Form
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private Font playFont;
        private Font labelsFont;
        private Font checksFont;

        private IniParser parser;
        private bool ready;
        
        // we need to hold on this and prevent GC from collecting it
        PrivateFontCollection pfc = new PrivateFontCollection();

        private VrcCfg cfg = new VrcCfg();

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

            /*using FileStream fs = new FileStream("files\\disso\\3.cbf", FileMode.Open);
            ulong hash1 = XXHash3.Hash64(fs);
            
            using FileStream fs2 = new FileStream("files\\distra\\4.cbf", FileMode.Open);
            ulong hash2 = XXHash3.Hash64(fs2);

            using FileStream fs3 = new FileStream("files\\enso\\3.cbf", FileMode.Open);
            ulong hash3 = XXHash3.Hash64(fs3);

            using FileStream fs4 = new FileStream("files\\entra\\4.cbf", FileMode.Open);
            ulong hash4 = XXHash3.Hash64(fs4);

            using FileStream fs5 = new FileStream("files\\ranked\\4.cbf", FileMode.Open);
            ulong hash5 = XXHash3.Hash64(fs5);*/

            
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


            PostprocessingQuality.Items.Clear();

            List<QualityItem> items =
            [
                new QualityItem("Extreme", 0),
                new QualityItem("Ultra", 1),
                new QualityItem("Very High", 2),
                new QualityItem("High", 3),
                new QualityItem("Medium", 4),
                new QualityItem("Low", 5),
                new QualityItem("Ultra Low", 6)
            ];

            foreach (QualityItem item in items)
            {
                PostprocessingQuality.Items.Add(item);
            }
            
            PostprocessingQuality.DisplayMember = "Text";
            PostprocessingQuality.ValueMember = "Value";
            
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
            ready = true;
        }

        Exception? TrySetReShadeValue(string section, string key, string value)
        {
            if (!File.Exists("ReShade.ini"))
            {
                MessageBox.Show("Nastavení se nepodařilo uložit, ReShade.ini neexistuje");
                return new Exception("ReShade.ini neexistuje"); 
            }
            
            try
            {
                parser = new IniParser("ReShade.ini");
                parser.DisableIniAutoSave();

                parser.SetValue(section, key, value);
                parser.SaveIni();
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Nastavení se nepodařilo uložit: {e.Message}");
                return e;
            }
        }

        void TryFindGame()
        {
            try
            {
                if (!File.Exists("vrc.json"))
                {
                    File.WriteAllText("vrc.json", "{}");
                }
                
                string data = File.ReadAllText("vrc.json");
                cfg = JsonConvert.DeserializeObject<VrcCfg>(data);
            }
            catch (Exception e)
            {
                
            }

            if (!File.Exists("vietcong.exe"))
            {
                MessageBox.Show("Vietcong Remastered Launcher vložte do složky, ve které je vietcong.exe");
                Close();
                return;
            }

            if (!File.Exists("ReShade.ini"))
            {
                MessageBox.Show("Vietcong Remastered obsahuje soubor ReShade.ini, který nebyl nalezen. Umístěte vietcong_remastered.exe do složky, ve které je vietcong.exe a ReShade.ini");
                Close();
                return;
            }

            try
            {
                parser = new IniParser("ReShade.ini");
                parser.DisableIniAutoSave();

               string showFps = parser.GetValue("OVERLAY", "ShowFPS");
               string presetPath = parser.GetValue("GENERAL", "PresetPath");
               string forceVsync = parser.GetValue("APP", "ForceVsync");

               if (showFps is "1")
               {
                   ShowFps.Checked = true;
                   ShowFps.Invalidate();
               }

               if (forceVsync is "1")
               {
                   ForceVsync.Checked = true;
                   ShowFps.Invalidate();
               }

               if (presetPath is not null)
               {
                   char presetN = presetPath.FirstOrDefault(char.IsDigit);

                   if (presetN is not '\0')
                   {
                       int presetNumber = int.Parse(presetN.ToString());
        
                       for (int i = 0; i < PostprocessingQuality.Items.Count; i++)
                       {
                           QualityItem item = (QualityItem)PostprocessingQuality.Items[i];
                           
                           if (item.Value == presetNumber)
                           {
                               PostprocessingQuality.SelectedIndex = i;
                               break;
                           }
                       }
                   }
               }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Během parsování ReShade.ini nastala neočekávaná chyba: {e.Message}");
                Close();
                return;
            }

            if (File.Exists("dsound.dll"))
            {
                ImprovedSoundCheck.Checked = true;
            }
            
        }
        
        void InitFonts()
        {
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
            if (!ready)
            {
                return;
            }

            QualityItem item = (QualityItem)PostprocessingQuality.SelectedItem;
            TrySetReShadeValue("GENERAL", "PresetPath", $".\\presets\\{item.Value}\\ReShadePreset.ini");
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

        private void ShowFps_CheckedChanged(object sender, EventArgs e)
        {
            if (!ready)
            {
                return;
            }
            
            TrySetReShadeValue("OVERLAY", "ShowFPS", ShowFps.Checked ? "1" : "0");
        }

        private void ForceVsync_CheckedChanged(object sender, EventArgs e)
        {
            if (!ready)
            {
                return;
            }
            
            TrySetReShadeValue("APP", "ForceVsync", ForceVsync.Checked ? "1" : "0");
        }

        private void ImprovedSoundCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!ready)
            {
                return;
            }

            try
            {
                if (ImprovedSoundCheck.Checked)
                {
                    if (!Directory.Exists("files/sfx") || !File.Exists("files/sfx/dsound.dll") || !File.Exists("files/sfx/dsoal-aldrv.dll") || !File.Exists("files/sfx/alsoft.ini"))
                    {
                        MessageBox.Show("Vylepšené audio není možné aktivovat, protože vaše verze Vietcong Remastered neobsahuje potřebné soubory. Aktualizujte na poslední verzi.");
                        ImprovedSoundCheck.Checked = false;
                        return;
                    }

                    File.Copy("files/sfx/dsound.dll", "dsound.dll");
                    File.Copy("files/sfx/dsoal-aldrv.dll", "dsoal-aldrv.dll");
                    File.Copy("files/sfx/alsoft.ini", "alsoft.ini");
                }
                else
                {
                    if (File.Exists("dsound.dll"))
                    {
                        File.Delete("dsound.dll");
                    }

                    if (File.Exists("dsoal-aldrv.dll"))
                    {
                        File.Delete("dsoal-aldrv.dll");
                    }

                    if (File.Exists("alsoft.ini"))
                    {
                        File.Delete("alsoft.ini");
                    }
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show($"Nastavení vylepšených zvuků se nepodařilo uložit: {e2.Message}");
            }
        }
    }
}