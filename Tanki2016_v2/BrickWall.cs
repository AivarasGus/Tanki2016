using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanki2016_v2
{
    class BrickWall : PictureBox
    {
        public bool damaged = false;

        public BrickWall(string name, Point location)
        {
            Name = name;
            Size = new Size(50, 50);
            Location = location;
            Image = Properties.Resources.brick_wall;
        }
    }
}
