using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class CustomComboBox : ComboBox
{
    private readonly Color borderColor = Color.Black;
    private readonly Color arrowColor = Color.Black;
    private readonly Color backgroundColor = ColorTranslator.FromHtml("#8da059");  // dark-green background
    // (Optionally) a different border color when focused. For this example we always draw black.
    private readonly Color focusedBorderColor = ColorTranslator.FromHtml("#3c4621");

    private ListBoxNativeWindow listBoxNativeWindow = null;

    public CustomComboBox()
    {
        // Use owner-drawn style for the text portion.
        DrawMode = DrawMode.OwnerDrawFixed;
        DropDownStyle = ComboBoxStyle.DropDownList;

        // Remove the native border styles
        // (We’ll draw our own border.)
        FlatStyle = FlatStyle.Flat;  // Or FlatStyle.Popup – just to reduce native border painting.
        BackColor = backgroundColor;
        ForeColor = Color.Black;

        // This forces the control to use our painting entirely.
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        UpdateStyles();
    }

    // Remove the native border (and the client edge) from the control
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            // Remove WS_BORDER and WS_EX_CLIENTEDGE
            cp.Style &= ~0x00800000;      // WS_BORDER
            cp.ExStyle &= ~0x00000200;    // WS_EX_CLIENTEDGE
            return cp;
        }
    }

    // Ensure we repaint when the selection or focus changes.
    protected override void OnSelectedIndexChanged(EventArgs e)
    {
        base.OnSelectedIndexChanged(e);
        Invalidate();        
    }
    protected override void OnGotFocus(EventArgs e)
    {
        base.OnGotFocus(e);
        Invalidate();
    }
    protected override void OnLostFocus(EventArgs e)
    {
        base.OnLostFocus(e);
        Invalidate();
    }

    // Paint the entire control.
    protected override void OnPaint(PaintEventArgs e)
    {
        // Fill the background.
        e.Graphics.Clear(backgroundColor);
 
        // Draw the selected item text.
        if (SelectedIndex >= 0)
        {
            string text = Items[SelectedIndex].ToString();
            using (SolidBrush brush = new SolidBrush(ForeColor))
            {
                // Leave room for the arrow on the left.
                Rectangle textRect = new Rectangle(30, 0, Width - 30, Height);
                StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(text, Font, brush, textRect, sf);
            }
        }

        // Draw the custom arrow on the left.
        int arrowSize = 8;
        int arrowLeft = 10;
        int arrowTop = (Height - arrowSize) / 2;
        Point[] arrowPoints =
        [
            new Point(arrowLeft - 2, arrowTop),
            new Point(arrowLeft + arrowSize + 2, arrowTop),
            new Point(arrowLeft + arrowSize / 2, arrowTop + arrowSize - 1)
        ];
        using(SolidBrush brush = new SolidBrush(arrowColor))
        {
            e.Graphics.FillPolygon(brush, arrowPoints);
        }
        using(Pen pen = new Pen(arrowColor, 1))
        {
            e.Graphics.DrawLine(pen,
                    arrowLeft - 1,
                    arrowTop + arrowSize + 1,
                    arrowLeft + arrowSize + 1,
                    arrowTop + arrowSize + 1);
        }
  
        // Finally, draw the custom border.
        // (If you prefer to change the border color when focused, you could do an if(Focused))
        using(Pen pen = new Pen(borderColor, 2))
        {
            // We use ClientRectangle.Width-1 etc. to fit inside the client.
            e.Graphics.DrawRectangle(pen, 0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
        }
    }

    // Draw each dropdown item.
    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        if (e.Index < 0)
            return;
 
        // Fill the background.
        using(SolidBrush brush = new SolidBrush(backgroundColor))
        {
            e.Graphics.FillRectangle(brush, e.Bounds);
        }
 
        // If the item is selected (in the opened dropdown), fill it with a different color.
        if (e.State.HasFlag(DrawItemState.Selected) && DroppedDown)
        {
            using(SolidBrush brush = new SolidBrush(focusedBorderColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
        }
 
        // Draw the item text.
        using(SolidBrush brush = new SolidBrush(Color.Black))
        {
            Rectangle textRect = e.Bounds;
            textRect.X += 5;
            StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center };
            e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, brush, textRect, sf);
        }
    }

    // Toggle the dropdown when the control is clicked.
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (!DroppedDown)
            DroppedDown = true;
    }
 
    // When the dropdown is opened, attach our native subclass to the dropdown list.
    protected override void OnDropDown(EventArgs e)
    {
        base.OnDropDown(e);
        AttachListBoxSubclass();
    }
 
    // Detach the native subclass when the dropdown is closed.
    protected override void OnDropDownClosed(EventArgs e)
    {
        if (listBoxNativeWindow != null)
        {
            listBoxNativeWindow.ReleaseHandle();
            listBoxNativeWindow = null;
        }
        base.OnDropDownClosed(e);
        Invalidate();
    }
 
    // Use GetComboBoxInfo to get the dropdown list handle and attach our subclass.
    private void AttachListBoxSubclass()
    {
        COMBOBOXINFO info = new COMBOBOXINFO();
        info.cbSize = Marshal.SizeOf(info);
        if(GetComboBoxInfo(this.Handle, ref info))
        {
            if(info.hwndList != IntPtr.Zero)
            {
                if(listBoxNativeWindow != null)
                {
                    listBoxNativeWindow.ReleaseHandle();
                    listBoxNativeWindow = null;
                }
                listBoxNativeWindow = new ListBoxNativeWindow();
                listBoxNativeWindow.AssignHandle(info.hwndList);
            }
        }
    }
 
    // P/Invoke declaration for GetComboBoxInfo.
    [DllImport("user32.dll")]
    private static extern bool GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO pcbi);
 
    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int Left, Top, Right, Bottom;
    }
 
    [StructLayout(LayoutKind.Sequential)]
    private struct COMBOBOXINFO
    {
        public int cbSize;
        public RECT rcItem;
        public RECT rcButton;
        public int stateButton;
        public IntPtr hwndCombo;
        public IntPtr hwndEdit;
        public IntPtr hwndList;
    }
}

// This class subclasses the native dropdown (ListBox) window so you can also custom-paint its border.
public class ListBoxNativeWindow : NativeWindow
{
    const int WM_NCPAINT = 0x0085;

    [DllImport("user32.dll")]
    private static extern IntPtr GetWindowDC(IntPtr hWnd);
    [DllImport("user32.dll")]
    private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int Left, Top, Right, Bottom;
    }

    protected override void WndProc(ref Message m)
    {
        // Let the control process the message first.
        base.WndProc(ref m);

        // When the nonclient area is painted…
        if (m.Msg == WM_NCPAINT)
        {
            IntPtr hDC = GetWindowDC(m.HWnd);
            if(hDC != IntPtr.Zero)
            {
                try
                {
                    if(GetWindowRect(m.HWnd, out RECT rect))
                    {
                        int width = rect.Right - rect.Left;
                        int height = rect.Bottom - rect.Top;
                        using(Graphics g = Graphics.FromHdc(hDC))
                        {
                            // Draw the dropdown list border in dark green (or any color you choose).
                            Color darkGreen = ColorTranslator.FromHtml("#3c4621");
                            using(Pen pen = new Pen(darkGreen, 2))
                            {
                                g.DrawRectangle(pen, new Rectangle(1, 1, width - 2, height - 2));
                            }
                        }
                    }
                }
                finally
                {
                    ReleaseDC(m.HWnd, hDC);
                }
            }
        }
    }
}