using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Newtonsoft.Json;
using Vrc.Properties;
using Exception = System.Exception;

namespace Vrc
{
    class Radhash
    {
        /// <summary>
        /// 3.cbf
        /// </summary>
        public long Disso { get; set; } = 103;
        /// <summary>
        /// 4.cbf
        /// </summary>
        public long Distra { get; set; } = 130060386;
        /// <summary>
        /// 3.cbf
        /// </summary>
        public long Enso { get; set; } = 10080368;
        /// <summary>
        /// 4.cbf
        /// </summary>
        public long Entra { get; set; } = 134767500;
        /// <summary>
        /// 4.cbf
        /// </summary>
        public long Ranked { get; set; } = 344468;
    }

    class ActiveRadhash
    {
        public long Cbf3 { get; set; }
        public long Cbf4 { get; set; }
    }
    
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
            // Icon = Resources.AppIcon;
            
            // local config
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

            if (cfg.Culture is not null)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(cfg.Culture);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(cfg.Culture);
                }
                catch (CultureNotFoundException ex)
                {
                    MessageBox.Show(string.Format(Resources.Culture, ex.Message));
                }
            }
            
            // localization
            PostprocessingQualityLabel.Text = Resources.PostprocessingQuality;
            ImprovedSoundCheck.Text = Resources.Improved3dSound;
            ShowFps.Text = Resources.ShowFps;
            ForceVsync.Text = Resources.ForceVSync;
            DisableTransVegetation.Text = Resources.DisableTranslucentVegetation;
            DisableImprovedSounds.Text = Resources.DisableImprovedWeaponsSound;
            RankedMultiplayer.Text = Resources.RankedMode;
            ExitCheckbox.Text = Resources.Exit;
            HelpButton.Text = Resources.Help;
            PlayLabel.Text = Resources.Play;
            PlayClassicButton.Text = Resources.VietcongClassic;
            PlayFistAlpha.Text = Resources.FistAlpha;
            
            StatusLabel.Text = Resources.UiSynchronizing;
            StatusLabel.Invalidate();
            
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
                new QualityItem(Resources.Extreme, 0),
                new QualityItem(Resources.Ultra, 1),
                new QualityItem(Resources.VeryHigh, 2),
                new QualityItem(Resources.High, 3),
                new QualityItem(Resources.Medium, 4),
                new QualityItem(Resources.Low, 5),
                new QualityItem(Resources.UltraLow, 6)
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
            StatusLabel.Font = labelsFont;

            PlayClassicButton.Font = labelsFont;
            PlayFistAlpha.Font = labelsFont;
            HelpButton.Font = labelsFont;

            PlayLabel.Font = playFont;
            
            TryFindGame();
            _ = GetHashes();
        }

        async Task GetHashes()
        {
            Radhash radhash = new Radhash();
            
            // attempt to fetch current hashes online
            try
            {
                string upstreamRadhash = await "https://raw.githubusercontent.com/lofcz/VietcongRemasteredLauncher/refs/heads/master/Vrc/Vrc/RADHASH.json".GetStringAsync();

                if (upstreamRadhash.Length > 0)
                {
                    radhash = JsonConvert.DeserializeObject<Radhash>(upstreamRadhash);
                }
            }
            catch (Exception e)
            {
                
            }

            // read length of local files if available
            try
            {
                if (File.Exists("files\\disso\\3.cbf"))
                {
                    FileInfo info1 = new FileInfo("files\\disso\\3.cbf");
                    radhash.Disso = info1.Length;
                }

                if (File.Exists("files\\distra\\4.cbf"))
                {
                    FileInfo info2 = new FileInfo("files\\distra\\4.cbf");
                    radhash.Distra = info2.Length;
                }

                if (File.Exists("files\\enso\\3.cbf"))
                {
                    FileInfo info3 = new FileInfo("files\\enso\\3.cbf");
                    radhash.Enso = info3.Length;
                }

                if (File.Exists("files\\entra\\4.cbf"))
                {
                    FileInfo info4 = new FileInfo("files\\entra\\4.cbf");
                    radhash.Entra = info4.Length;
                }

                if (File.Exists("files\\ranked\\4.cbf"))
                {
                    FileInfo info5 = new FileInfo("files\\ranked\\4.cbf");
                    radhash.Ranked = info5.Length;
                }
            }
            catch (Exception e)
            {
                
            }
            
            List<string> filesToHash = ["3.cbf", "4.cbf"];
            ActiveRadhash active = new ActiveRadhash();
            
            Parallel.ForEach(filesToHash, file =>
            {
                if (!File.Exists(file))
                {
                    return;
                }
                
                FileInfo info = new FileInfo(file);
                long hash = info.Length;

                if (file is "3.cbf")
                {
                    active.Cbf3 = hash;
                }
                else
                {
                    active.Cbf4 = hash;
                }
            });

            if (active.Cbf3 == radhash.Disso)
            {
                DisableImprovedSounds.Checked = true;
            }
            else if (active.Cbf3 == radhash.Enso || true)
            {
                DisableImprovedSounds.Checked = false;
            }
            
    
            if (active.Cbf4 == radhash.Ranked)
            {
                RankedMultiplayer.Checked = true;
                DisableTransVegetation.Checked = true;
                DisableTransVegetation.Enabled = false;
            }
            else if (active.Cbf4 == radhash.Entra)
            {
                RankedMultiplayer.Checked = false;
                DisableTransVegetation.Checked = true;
            }
            else
            {
                RankedMultiplayer.Checked = false;
                DisableTransVegetation.Checked = false;
            }

            DisableTransVegetation.Invalidate();
            RankedMultiplayer.Invalidate();
            DisableImprovedSounds.Invalidate();

            Invoke(() =>
            {
                StatusLabel.Text = string.Empty;
                StatusLabel.Invalidate();
                ready = true;
                Invalidate();
            });
        }

        Exception? TrySetReShadeValue(string section, string key, string value)
        {
            if (!File.Exists("ReShade.ini"))
            {
                MessageBox.Show(Resources.SettingsError1);
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
                MessageBox.Show(string.Format(Resources.SettingsErrorGeneric, e.Message));
                return e;
            }
        }

        void TryFindGame()
        {
            if (!File.Exists("vietcong.exe"))
            {
                MessageBox.Show(Resources.ReShadeError2);
                Close();
                return;
            }

            if (!File.Exists("ReShade.ini"))
            {
                MessageBox.Show(Resources.ReShadeError1);
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
                MessageBox.Show(string.Format(Resources.ReShadeErrorGeneric, e.Message));
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
            if (!File.Exists("vietcong.exe"))
            {
                MessageBox.Show(Resources.VietcongExeMissing);
                return;
            }

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "vietcong.exe",
                UseShellExecute = true,
                Arguments = "-addon classic"
            };
            
            using Process _ = Process.Start(psi);
            Close();
        }
        
        private void PlayFistAlpha_Click(object sender, EventArgs e)
        {
            if (!File.Exists("vietcong.exe"))
            {
                MessageBox.Show(Resources.VietcongExeMissing);
                return;
            }

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "vietcong.exe",
                UseShellExecute = true,
                Arguments = "-addon fistalpha"
            };
            
            using Process _ = Process.Start(psi);
            Close();
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
                        MessageBox.Show(Resources.AudioError1);
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
                MessageBox.Show(string.Format(Resources.AudioErrorGeneric, e2.Message));
            }
        }

        private void DisableTransVegetation_CheckedChanged(object sender, EventArgs e)
        {
            if (!ready)
            {
                return;
            }

            try
            {
                if (DisableTransVegetation.Checked)
                {
                    if (File.Exists("files/entra/4.cbf"))
                    {
                        File.Copy("files/entra/4.cbf", "4.cbf", true);
                    }
                    else
                    {
                        MessageBox.Show(Resources.VegetationError1);
                    }
                }
                else
                {
                    if (File.Exists("files/distra/4.cbf"))
                    {
                        File.Copy("files/distra/4.cbf", "4.cbf", true);
                    }
                    else
                    {
                        MessageBox.Show(Resources.VegetationError2);
                    }
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(string.Format(Resources.AudioErrorGeneric, e2.Message));
            }
        }

        private void DisableImprovedSounds_CheckedChanged(object sender, EventArgs e)
        {
            if (!ready)
            {
                return;
            }

            try
            {
                if (DisableImprovedSounds.Checked)
                {
                    if (File.Exists("files/disso/3.cbf"))
                    {
                        File.Copy("files/disso/3.cbf", "3.cbf", true);
                    }
                    else
                    {
                        MessageBox.Show(Resources.WeaponsAudioError1);
                    }
                }
                else
                {
                    if (File.Exists("files/enso/3.cbf"))
                    {
                        File.Copy("files/enso/3.cbf", "3.cbf", true);
                    }
                    else
                    {
                        MessageBox.Show(Resources.WeaponsAudioError2);
                    }
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(string.Format(Resources.WeaponsAudioErrorGeneric, e2.Message));
            }
        }
        
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (RankedMultiplayer.Checked)
                {
                    DisableTransVegetation.Checked = true;
                    DisableTransVegetation.Enabled = false;
                    DisableTransVegetation.Invalidate();

                    if (File.Exists("files/ranked/4.cbf"))
                    {
                        File.Copy("files/ranked/4.cbf", "4.cbf", true);
                    }
                    else
                    {
                        MessageBox.Show(Resources.RankedError1);
                    }
                }
                else
                {
                    DisableTransVegetation.Checked = true;
                    DisableTransVegetation.Enabled = true;
                    DisableTransVegetation.Invalidate();
                    
                    if (File.Exists("files/entra/4.cbf"))
                    {
                        File.Copy("files/entra/4.cbf", "4.cbf", true);
                    }
                    else
                    {
                        MessageBox.Show(Resources.RankedError2);
                    }
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(string.Format(Resources.RankedErrorgeneric, e2.Message));
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            if (File.Exists("navod.pdf"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "navod.pdf",
                    UseShellExecute = true
                };
            
                using Process _ = Process.Start(psi);
                return;
            }
            
            if (File.Exists("help.pdf"))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "help.pdf",
                    UseShellExecute = true
                };
            
                using Process _ = Process.Start(psi);
                return;
            }

            MessageBox.Show(Resources.HelpError);
        }
    }
}