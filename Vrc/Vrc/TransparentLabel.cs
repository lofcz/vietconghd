using System.Windows.Forms;

namespace Vrc
{
    public class TransparentLabel : Label
    {
        public TransparentLabel()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Nevykresluj pozadí, aby zůstalo průhledné
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, ForeColor, BackColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }
    }
}