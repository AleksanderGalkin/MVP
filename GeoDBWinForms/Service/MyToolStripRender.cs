using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GeoDBWinForms
{
    class MyToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
            if (!e.Item.Selected)
            {
                Brush backColor = new SolidBrush(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128))))));
                e.Graphics.FillRectangle(backColor, rectangle);
                e.Graphics.DrawRectangle(Pens.Yellow, rectangle);
            }
            else
            {
                Brush hover = new SolidBrush(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))));
                e.Graphics.FillRectangle(hover, rectangle);
                e.Graphics.DrawRectangle(Pens.Yellow, rectangle);
            }
        }
    }
}
