using System.Drawing;
using System.Windows.Forms;

namespace Tanki2016_v2
{
    class EnemyTank : PictureBox
    {
        public EnemyTank(string name, Point location)
        {
            Name = name;
            Size = new Size(50, 50);
            Location = location;
            Image = Properties.Resources.enemy_tank_up;
            Enabled = true;
            SizeMode = PictureBoxSizeMode.Normal;
        }

        public int health { get; set; } = 100;
    }
}
