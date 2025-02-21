using System.Drawing;
using System.Windows.Forms;

namespace Vrc;

public class CustomButton : Button
{
    public int BorderSize { get; set; }
    
    public CustomButton()
    {
        // Nastavení základních vlastností
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = BorderSize;
        this.FlatAppearance.BorderColor = Color.Black;
        this.BackColor = ColorTranslator.FromHtml("#8da059");
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        this.FlatAppearance.BorderSize = BorderSize;
        base.OnPaint(e);
    }

    // Pokud chceme zabránit změně některých vlastností za běhu
    public sealed override Color BackColor
    {
        get { return base.BackColor; }
        set { base.BackColor = ColorTranslator.FromHtml("#8da059"); }
    }
}