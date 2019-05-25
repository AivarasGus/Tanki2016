using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanki2016_v2
{
    public partial class GameOverScreen : Form
    {

        public GameOverScreen(int gameScore)
        {
            InitializeComponent();
            label2.Text = label2.Text + gameScore;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            GameplayScreen form1 = new GameplayScreen();
            form1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
