using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vrc
{
    public class CustomPanel : Panel
    {
        public CustomPanel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        
        const int WS_EX_TRANSPARENT = 0x20;  

        int opacity = 50;

        public int BorderPanelStyle
        {
            get;
            set;
        }
        
        public int Opacity
        {
            get
            {
                return opacity;
            }
            set
            {
                if (value < 0 || value > 100) throw new ArgumentException("Value must be between 0 and 100");
                opacity = value;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;

                return cp;
            }
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var b = new SolidBrush(Color.FromArgb(202, Color.FromArgb(255, 62, 73, 33))))
            {
                e.Graphics.FillRectangle(b, ClientRectangle);
            }
            
            using (var p = new Pen(Color.Black, 1))
            {
                // Výpočet souřadnic pro jednotlivé hrany
                int x = ClientRectangle.X + 1;
                int y = ClientRectangle.Y + 1;
                int right = ClientRectangle.Right - 1;
                int bottom = ClientRectangle.Bottom - 1;

                // Horní hrana
                if (BorderPanelStyle != 1)
                {
                    e.Graphics.DrawLine(p, x, y, right, y);
                }

                // Levá hrana
                e.Graphics.DrawLine(p, x, y, x, bottom);

                // Pravá hrana
                if (BorderPanelStyle is 2)
                {
                    e.Graphics.DrawLine(p, right, y, right, bottom);   
                }

                // Spodní hrana
                e.Graphics.DrawLine(p, x, bottom, right, bottom);
            }

            base.OnPaint(e);
        }
    }
}