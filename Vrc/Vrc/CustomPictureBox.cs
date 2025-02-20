using System.Drawing;
using System.Windows.Forms;

namespace Vrc
{
    public class CustomPictureBox : PictureBox
    {
        public CustomPictureBox()
        {

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // Nejprve vykreslíme základní PictureBox
            base.OnPaint(pe);

            // Vytvoříme pero pro kreslení okraje
            using (Pen borderPen = new Pen(Color.Black, 2))
            {
                // Nakreslíme horní čáru
                pe.Graphics.DrawLine(borderPen, 0, 0, this.Width, 0);
            
                // Nakreslíme levou čáru
                pe.Graphics.DrawLine(borderPen, 0, 0, 0, this.Height);
            }
        }
    }

}