using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanki2016_v2
{
    class Cannon : PictureBox
    {
        public Cannon(Point location)
        {
            Location = new Point(Location.X + 20, Location.Y + 20);
            Name = "cannon";
            Size = new Size(16, 16);
            Image = Properties.Resources.cannon_ball;
            Enabled = true;
            Visible = true;
        }
    }
}
