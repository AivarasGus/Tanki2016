using System.Drawing;
using System.Windows.Forms;

namespace Tanki2016_v2
{
    class Player : PictureBox
    {
        public Player()
        {
            Name = "player";
            Image = Properties.Resources.tank_up;
            Size = new Size(50, 50);
            Location = new Point(350, 200);
        }

        public int health { get; set; } = 100;

    }
}
