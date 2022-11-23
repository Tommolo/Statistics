using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_PolarCoordinates_C
{
    class EditableRectangle
    {
        public Rectangle r;
        PictureBox p;
        Form f;

        public EditableRectangle(int X, int Y, int Width, int Heigth, PictureBox pb, Form fo)
        {
            r = new Rectangle(X, Y, Width, Heigth);
            p = pb;
            f = fo;

            pb.MouseUp += new MouseEventHandler(editableRect_Up);
            pb.MouseDown += new MouseEventHandler(editableRect_Down);
            pb.MouseMove += new MouseEventHandler(editableRect_Move);

            f.MouseWheel += new MouseEventHandler(editableRect_Zoom);
        }

        int x_down;
        int y_down;

        int x_mouse;
        int y_mouse;

        int r_width;
        int r_height;

        bool drag = false;
        bool resizing = false;

        double ScaleFact = 0.1d;

        int hoverX;
        int hoverY;

        private void editableRect_Down(object sender, MouseEventArgs e)
        {
            if (r.Contains(e.X, e.Y))
            {
                x_mouse = e.X;
                y_mouse = e.Y;

                x_down = r.X;
                y_down = r.Y;

                r_width = r.Width;
                r_height = r.Height;

                if (e.Button == MouseButtons.Left)
                {
                    drag = true;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    resizing = true;
                }
            }
        }

        private void editableRect_Up(object sender, MouseEventArgs e)
        {
            drag = false;
            resizing = false;
        }

        private void editableRect_Move(object sender, MouseEventArgs e)
        {
            hoverX = e.X;
            hoverY = e.Y;

            int delta_x = e.X - x_mouse;
            int delta_y = e.Y - y_mouse;

            if (drag)
            {
                r.X = x_down + delta_x;
                r.Y = y_down + delta_y;
            }
            else if (resizing)
            {
                r.Width = r_width + delta_x;
                r.Height = r_height + delta_y;
            }
        }

        private void editableRect_Zoom(object sender, MouseEventArgs e)
        {

            int pictx = hoverX;
            int picty = hoverY;

            if (r.Contains(pictx, picty))
            {
                x_down = r.X;
                y_down = r.Y;

                r.Width = r.Width + (int)(e.Delta*ScaleFact);
                r.Height = r.Height + (int)(e.Delta*ScaleFact);

                r.X = x_down - (int)((e.Delta * ScaleFact)/2);
                r.Y = y_down - (int)((e.Delta * ScaleFact)/2);
            }
        }
    }
}
