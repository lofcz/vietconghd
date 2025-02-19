
using System.Drawing;
using System.Windows.Forms;

public class CustomCheckBox : CheckBox
{
    public CustomCheckBox()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        this.BackColor = Color.Transparent;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Získáme obdélník, kde se nachází checkbox (bez textu)
        Rectangle checkRect = this.GetScaledCheckRect();

        // Vykreslení pozadí checkboxu - vždy zelené
        using (var brush = new SolidBrush(Color.FromArgb(141, 160, 89)))
        {
            e.Graphics.FillRectangle(brush, checkRect);
        }

        // Vykreslení ohraničení
        using (var pen = new Pen(Color.Black, 1))
        {
            e.Graphics.DrawRectangle(pen, checkRect);
        }

        // Pokud je zaškrtnuto, vykreslíme X
        if (this.Checked)
        {
            using (var pen = new Pen(Color.Black, 1.5f))
            {
                // První čára X
                e.Graphics.DrawLine(pen,
                    checkRect.X + 4,
                    checkRect.Y + 4,
                    checkRect.X + checkRect.Width - 4,
                    checkRect.Y + checkRect.Height - 4);

                // Druhá čára X
                e.Graphics.DrawLine(pen,
                    checkRect.X + checkRect.Width - 4,
                    checkRect.Y + 4,
                    checkRect.X + 4,
                    checkRect.Y + checkRect.Height - 4);
            }
        }
    }

    private Rectangle GetScaledCheckRect()
    {
        Rectangle rect = this.ClientRectangle;

        bool checkAlignLeft = 
            (this.CheckAlign == ContentAlignment.TopLeft) ||
            (this.CheckAlign == ContentAlignment.MiddleLeft) ||
            (this.CheckAlign == ContentAlignment.BottomLeft);

        rect.Width = 16;
        rect.Height = 16;
        rect.Y = (this.ClientRectangle.Height - rect.Height) / 2;
        
        if (!checkAlignLeft)
        {
            rect.X = this.ClientRectangle.Width - rect.Width;
        }

        return rect;
    }
}

