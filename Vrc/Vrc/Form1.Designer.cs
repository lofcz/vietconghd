using System.Windows.Forms;

namespace Vrc
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rightPanel = new Vrc.GlassyPanel();
            this.PlayFistAlpha = new CustomButton();
            this.PlayClassicButton = new CustomButton();
            this.HelpButton = new CustomButton();
            this.bottomPanel = new Vrc.GlassyPanel();
            this.mainPanel = new Vrc.GlassyPanel();
            this.PostprocessingQualityLabel = new System.Windows.Forms.Label();
            this.PostprocessingQuality = new System.Windows.Forms.ComboBox();
            this.RankedMultiplayer = new CustomCheckBox();
            this.DisableImprovedSounds = new CustomCheckBox();
            this.DisableTransVegetation = new CustomCheckBox();
            this.ForceVsync = new CustomCheckBox();
            this.ShowFps = new CustomCheckBox();
            this.ImprovedSoundCheck = new CustomCheckBox();
            this.bgPicture = new System.Windows.Forms.PictureBox();
            this.rightPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.Transparent;
            this.rightPanel.BorderPanelStyle = 2;
            this.rightPanel.Controls.Add(this.PlayFistAlpha);
            this.rightPanel.Controls.Add(this.PlayClassicButton);
            this.rightPanel.Controls.Add(this.HelpButton);
            this.rightPanel.Location = new System.Drawing.Point(584, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Opacity = 50;
            this.rightPanel.Size = new System.Drawing.Size(216, 442);
            this.rightPanel.TabIndex = 0;
            // 
            // PlayFistAlpha
            // 
            this.PlayFistAlpha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(160)))), ((int)(((byte)(89)))));
            this.PlayFistAlpha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayFistAlpha.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.PlayFistAlpha.ForeColor = System.Drawing.Color.Black;
            this.PlayFistAlpha.Location = new System.Drawing.Point(13, 369);
            this.PlayFistAlpha.Name = "PlayFistAlpha";
            this.PlayFistAlpha.Size = new System.Drawing.Size(192, 40);
            this.PlayFistAlpha.TabIndex = 2;
            this.PlayFistAlpha.Text = "Fist Alpha DLC";
            this.PlayFistAlpha.UseVisualStyleBackColor = true;
            // 
            // PlayClassicButton
            // 
            this.PlayClassicButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(160)))), ((int)(((byte)(89)))));
            this.PlayClassicButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayClassicButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.PlayClassicButton.ForeColor = System.Drawing.Color.Black;
            this.PlayClassicButton.Location = new System.Drawing.Point(13, 323);
            this.PlayClassicButton.Name = "PlayClassicButton";
            this.PlayClassicButton.Size = new System.Drawing.Size(192, 40);
            this.PlayClassicButton.TabIndex = 1;
            this.PlayClassicButton.Text = "Vietcong Classic";
            this.PlayClassicButton.UseVisualStyleBackColor = true;
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(160)))), ((int)(((byte)(89)))));
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.HelpButton.ForeColor = System.Drawing.Color.Black;
            this.HelpButton.Location = new System.Drawing.Point(13, 12);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(192, 40);
            this.HelpButton.TabIndex = 0;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = true;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanel.BorderPanelStyle = 1;
            this.bottomPanel.Location = new System.Drawing.Point(0, 407);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Opacity = 50;
            this.bottomPanel.Size = new System.Drawing.Size(585, 35);
            this.bottomPanel.TabIndex = 1;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BorderPanelStyle = 0;
            this.mainPanel.Controls.Add(this.PostprocessingQualityLabel);
            this.mainPanel.Controls.Add(this.PostprocessingQuality);
            this.mainPanel.Controls.Add(this.RankedMultiplayer);
            this.mainPanel.Controls.Add(this.DisableImprovedSounds);
            this.mainPanel.Controls.Add(this.DisableTransVegetation);
            this.mainPanel.Controls.Add(this.ForceVsync);
            this.mainPanel.Controls.Add(this.ShowFps);
            this.mainPanel.Controls.Add(this.ImprovedSoundCheck);
            this.mainPanel.Location = new System.Drawing.Point(0, 89);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Opacity = 50;
            this.mainPanel.Size = new System.Drawing.Size(585, 320);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // PostprocessingQualityLabel
            // 
            this.PostprocessingQualityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PostprocessingQualityLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PostprocessingQualityLabel.Location = new System.Drawing.Point(12, 22);
            this.PostprocessingQualityLabel.Name = "PostprocessingQualityLabel";
            this.PostprocessingQualityLabel.Size = new System.Drawing.Size(301, 23);
            this.PostprocessingQualityLabel.TabIndex = 8;
            this.PostprocessingQualityLabel.Text = "Postprocessing quality";
            this.PostprocessingQualityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PostprocessingQuality
            // 
            this.PostprocessingQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PostprocessingQuality.FormattingEnabled = true;
            this.PostprocessingQuality.Items.AddRange(new object[] { "Extreme", "Ultra", "Very High", "High", "Medium", "Low", "Ultra Low" });
            this.PostprocessingQuality.Location = new System.Drawing.Point(319, 21);
            this.PostprocessingQuality.Name = "PostprocessingQuality";
            this.PostprocessingQuality.Size = new System.Drawing.Size(150, 24);
            this.PostprocessingQuality.TabIndex = 7;
            // 
            // RankedMultiplayer
            // 
            this.RankedMultiplayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RankedMultiplayer.AutoSize = true;
            this.RankedMultiplayer.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.RankedMultiplayer.Location = new System.Drawing.Point(371, 266);
            this.RankedMultiplayer.Name = "RankedMultiplayer";
            this.RankedMultiplayer.Size = new System.Drawing.Size(190, 21);
            this.RankedMultiplayer.TabIndex = 5;
            this.RankedMultiplayer.Text = "Ranked multiplayer mode";
            this.RankedMultiplayer.UseVisualStyleBackColor = true;
            this.RankedMultiplayer.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // DisableImprovedSounds
            // 
            this.DisableImprovedSounds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DisableImprovedSounds.AutoSize = true;
            this.DisableImprovedSounds.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.DisableImprovedSounds.Location = new System.Drawing.Point(319, 239);
            this.DisableImprovedSounds.Name = "DisableImprovedSounds";
            this.DisableImprovedSounds.Size = new System.Drawing.Size(242, 21);
            this.DisableImprovedSounds.TabIndex = 4;
            this.DisableImprovedSounds.Text = "Disable improved weapon sounds";
            this.DisableImprovedSounds.UseVisualStyleBackColor = true;
            // 
            // DisableTransVegetation
            // 
            this.DisableTransVegetation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DisableTransVegetation.AutoSize = true;
            this.DisableTransVegetation.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.DisableTransVegetation.Location = new System.Drawing.Point(340, 212);
            this.DisableTransVegetation.Name = "DisableTransVegetation";
            this.DisableTransVegetation.Size = new System.Drawing.Size(221, 21);
            this.DisableTransVegetation.TabIndex = 3;
            this.DisableTransVegetation.Text = "Disable translucent vegetation";
            this.DisableTransVegetation.UseVisualStyleBackColor = true;
            // 
            // ForceVsync
            // 
            this.ForceVsync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ForceVsync.AutoSize = true;
            this.ForceVsync.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.ForceVsync.Location = new System.Drawing.Point(116, 266);
            this.ForceVsync.Name = "ForceVsync";
            this.ForceVsync.Size = new System.Drawing.Size(115, 21);
            this.ForceVsync.TabIndex = 2;
            this.ForceVsync.Text = "Force V-Sync";
            this.ForceVsync.UseVisualStyleBackColor = true;
            // 
            // ShowFps
            // 
            this.ShowFps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowFps.AutoSize = true;
            this.ShowFps.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.ShowFps.Location = new System.Drawing.Point(137, 239);
            this.ShowFps.Name = "ShowFps";
            this.ShowFps.Size = new System.Drawing.Size(94, 21);
            this.ShowFps.TabIndex = 1;
            this.ShowFps.Text = "Show FPS";
            this.ShowFps.UseVisualStyleBackColor = true;
            // 
            // ImprovedSoundCheck
            // 
            this.ImprovedSoundCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImprovedSoundCheck.AutoSize = true;
            this.ImprovedSoundCheck.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.ImprovedSoundCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ImprovedSoundCheck.Location = new System.Drawing.Point(76, 212);
            this.ImprovedSoundCheck.Name = "ImprovedSoundCheck";
            this.ImprovedSoundCheck.Size = new System.Drawing.Size(155, 21);
            this.ImprovedSoundCheck.TabIndex = 0;
            this.ImprovedSoundCheck.Text = "Improved 3D Sound";
            this.ImprovedSoundCheck.UseVisualStyleBackColor = true;
            // 
            // bgPicture
            // 
            this.bgPicture.Image = global::Vrc.Properties.Resources.cc894e4b_cac2_4ff2_8327_4b787907d956;
            this.bgPicture.Location = new System.Drawing.Point(0, 0);
            this.bgPicture.Name = "bgPicture";
            this.bgPicture.Size = new System.Drawing.Size(800, 442);
            this.bgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bgPicture.TabIndex = 3;
            this.bgPicture.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(801, 443);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.bgPicture);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.rightPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgPicture)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox bgPicture;

        private System.Windows.Forms.Label PostprocessingQualityLabel;

        private System.Windows.Forms.ComboBox PostprocessingQuality;

        private CustomCheckBox ForceVsync;

        private CustomCheckBox RankedMultiplayer;

        private CustomCheckBox DisableImprovedSounds;

        private CustomCheckBox DisableTransVegetation;

        private CustomCheckBox ShowFps;

        private CustomCheckBox ImprovedSoundCheck;

        private Vrc.GlassyPanel mainPanel;

        private CustomButton HelpButton;
        private CustomButton PlayFistAlpha;

        private CustomButton PlayClassicButton;

        private Vrc.GlassyPanel bottomPanel;

        private Vrc.GlassyPanel rightPanel;

        #endregion
    }
}