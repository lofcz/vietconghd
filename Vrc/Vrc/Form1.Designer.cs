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
            this.PlayFistAlpha = new System.Windows.Forms.Button();
            this.PlayClassicButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.bottomPanel = new Vrc.GlassyPanel();
            this.mainPanel = new Vrc.GlassyPanel();
            this.PostprocessingQualityLabel = new System.Windows.Forms.Label();
            this.PostprocessingQuality = new System.Windows.Forms.ComboBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.DisableTransVegetation = new System.Windows.Forms.CheckBox();
            this.ForceVsync = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ImprovedSoundCheck = new System.Windows.Forms.CheckBox();
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
            this.rightPanel.Location = new System.Drawing.Point(600, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Opacity = 50;
            this.rightPanel.Size = new System.Drawing.Size(200, 442);
            this.rightPanel.TabIndex = 0;
            // 
            // PlayFistAlpha
            // 
            this.PlayFistAlpha.Location = new System.Drawing.Point(13, 369);
            this.PlayFistAlpha.Name = "PlayFistAlpha";
            this.PlayFistAlpha.Size = new System.Drawing.Size(175, 40);
            this.PlayFistAlpha.TabIndex = 2;
            this.PlayFistAlpha.Text = "Fist Alpha DLC";
            this.PlayFistAlpha.UseVisualStyleBackColor = true;
            // 
            // PlayClassicButton
            // 
            this.PlayClassicButton.Location = new System.Drawing.Point(13, 323);
            this.PlayClassicButton.Name = "PlayClassicButton";
            this.PlayClassicButton.Size = new System.Drawing.Size(175, 40);
            this.PlayClassicButton.TabIndex = 1;
            this.PlayClassicButton.Text = "Vietcong Classic";
            this.PlayClassicButton.UseVisualStyleBackColor = true;
            // 
            // HelpButton
            // 
            this.HelpButton.Location = new System.Drawing.Point(13, 12);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(175, 40);
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
            this.bottomPanel.Size = new System.Drawing.Size(600, 35);
            this.bottomPanel.TabIndex = 1;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BorderPanelStyle = 0;
            this.mainPanel.Controls.Add(this.PostprocessingQualityLabel);
            this.mainPanel.Controls.Add(this.PostprocessingQuality);
            this.mainPanel.Controls.Add(this.checkBox3);
            this.mainPanel.Controls.Add(this.checkBox2);
            this.mainPanel.Controls.Add(this.DisableTransVegetation);
            this.mainPanel.Controls.Add(this.ForceVsync);
            this.mainPanel.Controls.Add(this.checkBox1);
            this.mainPanel.Controls.Add(this.ImprovedSoundCheck);
            this.mainPanel.Location = new System.Drawing.Point(0, 89);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Opacity = 50;
            this.mainPanel.Size = new System.Drawing.Size(600, 320);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // PostprocessingQualityLabel
            // 
            this.PostprocessingQualityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PostprocessingQualityLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PostprocessingQualityLabel.Location = new System.Drawing.Point(27, 22);
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
            this.PostprocessingQuality.Location = new System.Drawing.Point(334, 21);
            this.PostprocessingQuality.Name = "PostprocessingQuality";
            this.PostprocessingQuality.Size = new System.Drawing.Size(150, 24);
            this.PostprocessingQuality.TabIndex = 7;
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.AutoSize = true;
            this.checkBox3.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkBox3.Location = new System.Drawing.Point(386, 266);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(190, 21);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "Ranked multiplayer mode";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkBox2.Location = new System.Drawing.Point(334, 239);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(242, 21);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Disable improved weapon sounds";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // DisableTransVegetation
            // 
            this.DisableTransVegetation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DisableTransVegetation.AutoSize = true;
            this.DisableTransVegetation.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.DisableTransVegetation.Location = new System.Drawing.Point(355, 212);
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
            this.ForceVsync.Location = new System.Drawing.Point(131, 266);
            this.ForceVsync.Name = "ForceVsync";
            this.ForceVsync.Size = new System.Drawing.Size(115, 21);
            this.ForceVsync.TabIndex = 2;
            this.ForceVsync.Text = "Force V-Sync";
            this.ForceVsync.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkBox1.Location = new System.Drawing.Point(152, 239);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 21);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Show FPS";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ImprovedSoundCheck
            // 
            this.ImprovedSoundCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImprovedSoundCheck.AutoSize = true;
            this.ImprovedSoundCheck.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.ImprovedSoundCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ImprovedSoundCheck.Location = new System.Drawing.Point(91, 212);
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

        private System.Windows.Forms.CheckBox ForceVsync;

        private System.Windows.Forms.CheckBox checkBox3;

        private System.Windows.Forms.CheckBox checkBox2;

        private System.Windows.Forms.CheckBox DisableTransVegetation;

        private System.Windows.Forms.CheckBox checkBox1;

        private System.Windows.Forms.CheckBox ImprovedSoundCheck;

        private Vrc.GlassyPanel mainPanel;

        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Button PlayFistAlpha;

        private System.Windows.Forms.Button PlayClassicButton;

        private Vrc.GlassyPanel bottomPanel;

        private Vrc.GlassyPanel rightPanel;

        #endregion
    }
}