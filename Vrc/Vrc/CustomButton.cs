using System.Drawing;
using System.Windows.Forms;

public class CustomButton : Button
{
    public CustomButton()
    {
        // Nastavení základních vlastností
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 2;
        this.FlatAppearance.BorderColor = Color.Black;
        this.BackColor = ColorTranslator.FromHtml("#8da059");
        
        // Volitelně můžeme přidat další vlastnosti
        this.Font = new Font("Arial", 10F, FontStyle.Bold);
        this.ForeColor = Color.Black;
    }

    // Pokud chceme zabránit změně některých vlastností za běhu
    public sealed override Color BackColor
    {
        get { return base.BackColor; }
        set { base.BackColor = ColorTranslator.FromHtml("#8da059"); }
    }
}