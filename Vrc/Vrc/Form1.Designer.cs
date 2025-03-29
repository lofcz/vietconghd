using System.Drawing;
using System.Windows.Forms;
using Vrc.Properties;

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
            this.mainPanel = new Vrc.CustomPanel();
            this.PostprocessingQualityLabel = new System.Windows.Forms.Label();
            this.PostprocessingQuality = new Vrc.CustomComboBox();
            this.RankedMultiplayer = new Vrc.CustomCheckBox();
            this.DisableImprovedSounds = new Vrc.CustomCheckBox();
            this.DisableTransVegetation = new Vrc.CustomCheckBox();
            this.RunWindowed = new Vrc.CustomCheckBox();
            this.ShowFps = new Vrc.CustomCheckBox();
            this.ImprovedSoundCheck = new Vrc.CustomCheckBox();
            this.bottomPanel = new Vrc.CustomPanel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.rightPanel = new Vrc.CustomPanel();
            this.DiscordImg = new System.Windows.Forms.PictureBox();
            this.ExitCheckbox = new Vrc.CustomCheckBox();
            this.PlayLabel = new System.Windows.Forms.Label();
            this.PlayFistAlpha = new Vrc.CustomButton();
            this.PlayClassicButton = new Vrc.CustomButton();
            this.HelpButton = new Vrc.CustomButton();
            this.bgPicture = new Vrc.CustomPictureBox();
            this.mainPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiscordImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgPicture)).BeginInit();
            this.SuspendLayout();
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
            this.mainPanel.Controls.Add(this.RunWindowed);
            this.mainPanel.Controls.Add(this.ShowFps);
            this.mainPanel.Controls.Add(this.ImprovedSoundCheck);
            this.mainPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.mainPanel.Location = new System.Drawing.Point(0, 89);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Opacity = 50;
            this.mainPanel.Size = new System.Drawing.Size(585, 317);
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
            this.PostprocessingQuality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(160)))), ((int)(((byte)(89)))));
            this.PostprocessingQuality.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PostprocessingQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PostprocessingQuality.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PostprocessingQuality.ForeColor = System.Drawing.Color.Black;
            this.PostprocessingQuality.FormattingEnabled = true;
            this.PostprocessingQuality.Items.AddRange(new object[] {
            "Extreme",
            "Ultra",
            "Very High",
            "High",
            "Medium",
            "Low",
            "Ultra Low"});
            this.PostprocessingQuality.Location = new System.Drawing.Point(319, 21);
            this.PostprocessingQuality.Name = "PostprocessingQuality";
            this.PostprocessingQuality.Size = new System.Drawing.Size(150, 23);
            this.PostprocessingQuality.TabIndex = 7;
            this.PostprocessingQuality.SelectedIndexChanged += new System.EventHandler(this.PostprocessingQuality_SelectedIndexChanged);
            // 
            // RankedMultiplayer
            // 
            this.RankedMultiplayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RankedMultiplayer.AutoSize = true;
            this.RankedMultiplayer.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.RankedMultiplayer.Location = new System.Drawing.Point(378, 281);
            this.RankedMultiplayer.Name = "RankedMultiplayer";
            this.RankedMultiplayer.Size = new System.Drawing.Size(183, 20);
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
            this.DisableImprovedSounds.Location = new System.Drawing.Point(327, 254);
            this.DisableImprovedSounds.Name = "DisableImprovedSounds";
            this.DisableImprovedSounds.Size = new System.Drawing.Size(234, 20);
            this.DisableImprovedSounds.TabIndex = 4;
            this.DisableImprovedSounds.Text = "Disable improved weapon sounds";
            this.DisableImprovedSounds.UseVisualStyleBackColor = true;
            this.DisableImprovedSounds.CheckedChanged += new System.EventHandler(this.DisableImprovedSounds_CheckedChanged);
            // 
            // DisableTransVegetation
            // 
            this.DisableTransVegetation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DisableTransVegetation.AutoSize = true;
            this.DisableTransVegetation.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.DisableTransVegetation.Location = new System.Drawing.Point(352, 227);
            this.DisableTransVegetation.Name = "DisableTransVegetation";
            this.DisableTransVegetation.Size = new System.Drawing.Size(209, 20);
            this.DisableTransVegetation.TabIndex = 2;
            this.DisableTransVegetation.Text = "Disable translucent vegetation";
            this.DisableTransVegetation.UseVisualStyleBackColor = true;
            this.DisableTransVegetation.CheckedChanged += new System.EventHandler(this.DisableTransVegetation_CheckedChanged);
            // 
            // RunWindowed
            // 
            this.RunWindowed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RunWindowed.AutoSize = true;
            this.RunWindowed.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.RunWindowed.Location = new System.Drawing.Point(121, 281);
            this.RunWindowed.Name = "RunWindowed";
            this.RunWindowed.Size = new System.Drawing.Size(110, 20);
            this.RunWindowed.TabIndex = 2;
            this.RunWindowed.Text = "Force V-Sync";
            this.RunWindowed.UseVisualStyleBackColor = true;
            this.RunWindowed.CheckedChanged += new System.EventHandler(this.ForceRunWindowed_CheckedChanged);
            // 
            // ShowFps
            // 
            this.ShowFps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowFps.AutoSize = true;
            this.ShowFps.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.ShowFps.Location = new System.Drawing.Point(140, 254);
            this.ShowFps.Name = "ShowFps";
            this.ShowFps.Size = new System.Drawing.Size(91, 20);
            this.ShowFps.TabIndex = 1;
            this.ShowFps.Text = "Show FPS";
            this.ShowFps.UseVisualStyleBackColor = true;
            this.ShowFps.CheckedChanged += new System.EventHandler(this.ShowFps_CheckedChanged);
            // 
            // ImprovedSoundCheck
            // 
            this.ImprovedSoundCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImprovedSoundCheck.AutoSize = true;
            this.ImprovedSoundCheck.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.ImprovedSoundCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ImprovedSoundCheck.Location = new System.Drawing.Point(83, 227);
            this.ImprovedSoundCheck.Name = "ImprovedSoundCheck";
            this.ImprovedSoundCheck.Size = new System.Drawing.Size(148, 20);
            this.ImprovedSoundCheck.TabIndex = 0;
            this.ImprovedSoundCheck.Text = "Improved 3D Sound";
            this.ImprovedSoundCheck.UseVisualStyleBackColor = true;
            this.ImprovedSoundCheck.CheckedChanged += new System.EventHandler(this.ImprovedSoundCheck_CheckedChanged);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanel.BorderPanelStyle = 1;
            this.bottomPanel.Controls.Add(this.StatusLabel);
            this.bottomPanel.Location = new System.Drawing.Point(0, 406);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Opacity = 50;
            this.bottomPanel.Size = new System.Drawing.Size(585, 35);
            this.bottomPanel.TabIndex = 1;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.StatusLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StatusLabel.Location = new System.Drawing.Point(12, 5);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(565, 23);
            this.StatusLabel.TabIndex = 10;
            this.StatusLabel.Text = "STATUS BAR";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.Transparent;
            this.rightPanel.BorderPanelStyle = 2;
            this.rightPanel.Controls.Add(this.DiscordImg);
            this.rightPanel.Controls.Add(this.ExitCheckbox);
            this.rightPanel.Controls.Add(this.PlayLabel);
            this.rightPanel.Controls.Add(this.PlayFistAlpha);
            this.rightPanel.Controls.Add(this.PlayClassicButton);
            this.rightPanel.Controls.Add(this.HelpButton);
            this.rightPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(583, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Opacity = 50;
            this.rightPanel.Size = new System.Drawing.Size(216, 441);
            this.rightPanel.TabIndex = 0;
            // 
            // DiscordImg
            // 
            this.DiscordImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscordImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DiscordImg.Image = global::Vrc.Properties.Resources.discord;
            this.DiscordImg.Location = new System.Drawing.Point(121, 91);
            this.DiscordImg.Name = "DiscordImg";
            this.DiscordImg.Size = new System.Drawing.Size(64, 64);
            this.DiscordImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.DiscordImg.TabIndex = 10;
            this.DiscordImg.TabStop = false;
            this.DiscordImg.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ExitCheckbox
            // 
            this.ExitCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitCheckbox.AutoSize = true;
            this.ExitCheckbox.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.ExitCheckbox.Checked = true;
            this.ExitCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ExitCheckbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ExitCheckbox.Location = new System.Drawing.Point(154, 12);
            this.ExitCheckbox.Name = "ExitCheckbox";
            this.ExitCheckbox.Size = new System.Drawing.Size(50, 20);
            this.ExitCheckbox.TabIndex = 9;
            this.ExitCheckbox.Text = "Exit";
            this.ExitCheckbox.UseVisualStyleBackColor = true;
            this.ExitCheckbox.CheckedChanged += new System.EventHandler(this.ExitCheckbox_CheckedChanged);
            // 
            // PlayLabel
            // 
            this.PlayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PlayLabel.Location = new System.Drawing.Point(13, 310);
            this.PlayLabel.Name = "PlayLabel";
            this.PlayLabel.Size = new System.Drawing.Size(192, 23);
            this.PlayLabel.TabIndex = 9;
            this.PlayLabel.Text = "Play";
            this.PlayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PlayLabel.Click += new System.EventHandler(this.PlayLabel_Click);
            // 
            // PlayFistAlpha
            // 
            this.PlayFistAlpha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(160)))), ((int)(((byte)(89)))));
            this.PlayFistAlpha.BorderSize = 2;
            this.PlayFistAlpha.FlatAppearance.BorderSize = 2;
            this.PlayFistAlpha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayFistAlpha.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.PlayFistAlpha.ForeColor = System.Drawing.Color.Black;
            this.PlayFistAlpha.Location = new System.Drawing.Point(13, 390);
            this.PlayFistAlpha.Name = "PlayFistAlpha";
            this.PlayFistAlpha.Size = new System.Drawing.Size(192, 40);
            this.PlayFistAlpha.TabIndex = 2;
            this.PlayFistAlpha.Text = "Fist Alpha DLC";
            this.PlayFistAlpha.UseVisualStyleBackColor = true;
            this.PlayFistAlpha.Click += new System.EventHandler(this.PlayFistAlpha_Click);
            // 
            // PlayClassicButton
            // 
            this.PlayClassicButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(160)))), ((int)(((byte)(89)))));
            this.PlayClassicButton.BorderSize = 2;
            this.PlayClassicButton.FlatAppearance.BorderSize = 2;
            this.PlayClassicButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayClassicButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.PlayClassicButton.ForeColor = System.Drawing.Color.Black;
            this.PlayClassicButton.Location = new System.Drawing.Point(13, 343);
            this.PlayClassicButton.Name = "PlayClassicButton";
            this.PlayClassicButton.Size = new System.Drawing.Size(192, 40);
            this.PlayClassicButton.TabIndex = 1;
            this.PlayClassicButton.Text = "Vietcong Classic";
            this.PlayClassicButton.UseVisualStyleBackColor = true;
            this.PlayClassicButton.Click += new System.EventHandler(this.PlayClassicButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(160)))), ((int)(((byte)(89)))));
            this.HelpButton.BorderSize = 1;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.HelpButton.ForeColor = System.Drawing.Color.Black;
            this.HelpButton.Location = new System.Drawing.Point(13, 45);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(192, 40);
            this.HelpButton.TabIndex = 0;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // bgPicture
            // 
            // this.bgPicture.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.bgPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgPicture.Image = global::Vrc.Properties.Resources.cc894e4b_cac2_4ff2_8327_4b787907d956;
            this.bgPicture.Location = new System.Drawing.Point(0, 0);
            this.bgPicture.Name = "bgPicture";
            this.bgPicture.Size = new System.Drawing.Size(799, 441);
            this.bgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bgPicture.TabIndex = 3;
            this.bgPicture.TabStop = false;
            this.bgPicture.Click += new System.EventHandler(this.bgPicture_Click);
            this.bgPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bgPicture_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 441);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.bgPicture);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vietcong HD Remaster";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiscordImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgPicture)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label StatusLabel;

        private CustomCheckBox ExitCheckbox;

        private System.Windows.Forms.Label PlayLabel;

        private CustomPictureBox bgPicture;

        private System.Windows.Forms.Label PostprocessingQualityLabel;

        private CustomComboBox PostprocessingQuality;

        private Vrc.CustomCheckBox RunWindowed;

        private Vrc.CustomCheckBox RankedMultiplayer;

        private Vrc.CustomCheckBox DisableImprovedSounds;

        private Vrc.CustomCheckBox DisableTransVegetation;

        private Vrc.CustomCheckBox ShowFps;

        private Vrc.CustomCheckBox ImprovedSoundCheck;

        private Vrc.CustomPanel mainPanel;

        private CustomButton HelpButton;
        private CustomButton PlayFistAlpha;

        private CustomButton PlayClassicButton;

        private Vrc.CustomPanel bottomPanel;

        private Vrc.CustomPanel rightPanel;

        #endregion

        private System.Windows.Forms.PictureBox DiscordImg;
    }
}