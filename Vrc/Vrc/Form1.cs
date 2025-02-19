using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vrc
{
    public partial class Form1 : Form
    {
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
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}