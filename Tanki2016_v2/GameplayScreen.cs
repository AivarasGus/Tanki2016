using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tanki2016_v2
{
    public partial class GameplayScreen : Form
    {
        public GameplayScreen()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(tank_KeyDown);
        }
        [Flags]
        public enum Direction
        {
            Right = 70, Left = 10, Up = 75, Down = 135
        };

        Direction currentDirection = Direction.Up;


        StartScreen startScreen = new StartScreen();
        Player player = new Player();

        int lives = 3;
        int currentScore = 0;


        string gameWallsCoordinates = @"C:\Users\Bendras\Desktop\Tanki2016_v2_images\level1_brick_coordinates.txt";
        string enemyTankCoordinates = @"C:\Users\Bendras\Desktop\Tanki2016_v2_images\level1_enemy_coordinates.txt";

        List<Point> coordinates = new List<Point>();
        List<BrickWall> gameWalls = new List<BrickWall>();
        List<EnemyTank> enemyTanks = new List<EnemyTank>();
        List<PictureBox> playerLives = new List<PictureBox>();

        EnemyMovement enemyMovement = new EnemyMovement();
        EnemyMovement enemyMovement1 = new EnemyMovement();
        EnemyMovement enemyMovement2 = new EnemyMovement();
        EnemyMovement enemyMovement3 = new EnemyMovement();


        Random random = new Random();

        Shooter shooter = new Shooter();
        GameFileReader fileReader = new GameFileReader();
        TankSpawner tankSpawner = new TankSpawner();
        CollisionDetecter detecter = new CollisionDetecter();

        bool navigateHorizontally(Direction direction, Player player, int bounds)
        {
            if(player.Location.X + (int)direction <= bounds)
            {
                return false;
            }
            if(direction == Direction.Left)
            {
                if (detecter.detectCollision(gameWalls, new Rectangle(player.Location.X - 1, player.Location.Y, 50, 50), enemyTanks))
                {
                    return false;
                }
            }
            else if(direction == Direction.Right)
            {
                if (detecter.detectCollision(gameWalls, new Rectangle(player.Location.X + 1, player.Location.Y, 50, 50), enemyTanks))
                {
                    return false;
                }
            }
            return true;
        }

        bool navigateVertically(Direction direction, Player player, int bounds)
        {
            if (player.Location.Y + (int)direction <= bounds)
            {
                return false;
            }
            if (direction == Direction.Up)
            {
                if (detecter.detectCollision(gameWalls, new Rectangle(player.Location.X, player.Location.Y - 1, 50, 50), enemyTanks))
                {
                    return false;
                }
            }
            else if (direction == Direction.Down)
            {
                if (detecter.detectCollision(gameWalls, new Rectangle(player.Location.X, player.Location.Y + 1, 50, 50), enemyTanks))
                {
                    return false;
                }
            }
            return true;
        }

        private void tank_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player.Image = Properties.Resources.tank_left;
                    currentDirection = Direction.Left;
                    if(navigateHorizontally(currentDirection, player, gameBorders.Bounds.Left))
                    {
                        player.Location = new Point(player.Location.X - 5, player.Location.Y);
                        break;
                    }
                    break;
                case Keys.Right:
                    player.Image = Properties.Resources.tank_right;
                    currentDirection = Direction.Right;
                    if (navigateHorizontally(currentDirection, player, gameBorders.Bounds.Right))
                    {
                        player.Location = new Point(player.Location.X + 5, player.Location.Y);
                        break;
                    }
                    break;
                case Keys.Up:
                    player.Image = Properties.Resources.tank_up;
                    currentDirection = Direction.Up;
                    if(navigateVertically(currentDirection, player, gameBorders.Bounds.Top))
                    {
                        player.Location = new Point(player.Location.X, player.Location.Y - 5);
                        break;
                    }
                    break;
                case Keys.Down:
                    player.Image = Properties.Resources.tank_down;
                    currentDirection = Direction.Down;
                    if(navigateVertically(currentDirection, player, gameBorders.Bounds.Bottom))
                    {
                        player.Location = new Point(player.Location.X, player.Location.Y + 5);
                        break;
                    }
                    break;
                case Keys.Space:
                    Cannon cannon = new Cannon(player.Location);
                    gameBorders.Controls.Add(cannon);
                    cannon.Location = new Point(player.Location.X + 20, player.Location.Y + 20);
                    switch (currentDirection)
                    {
                        case Direction.Right:
                            timer1.Tick += new EventHandler((sender1, e1) => shooter.shootRight(sender, e, cannon, gameWalls, enemyTanks, gameBorders, player, false));
                            break;
                        case Direction.Left:
                            timer1.Tick += new EventHandler((sender1, e1) => shooter.shootLeft(sender, e, cannon, gameWalls, enemyTanks, gameBorders, player, false));
                            break;
                        case Direction.Up:
                            timer1.Tick += new EventHandler((sender1, e1) => shooter.shootUp(sender, e, cannon, gameWalls, enemyTanks, gameBorders, player, false));
                            break;
                        case Direction.Down:
                            timer1.Tick += new EventHandler((sender1, e1) => shooter.shootDown(sender, e, cannon, gameWalls, enemyTanks, gameBorders, player, false));
                            break;
                    }                    
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Current Score tracking
            label1.Text = "Current Score: " + currentScore;
            //Checking for gameover conditions
            if (lives == 0)
            {
                GameOverScreen gameOver = new GameOverScreen(currentScore);
                gameOver.Show();
                this.Close();
            }

            //Health bar tracking
            if (player.health < 0)
            {
                progressBar1.Value = 0;
            }
            else
            {
                progressBar1.Value = player.health;
            }
            
            //keeping track of lives
            if (progressBar1.Value <= 0 && lives != 0)
            {
                playerLives.ElementAt(lives - 1).Hide();
                player.health = 100;
                --lives;
            }
            //checking if any tanks dead
            foreach(EnemyTank element in enemyTanks)
            {
                if(element.health <= 0)
                {
                    currentScore += 100;
                    element.health = 100;
                    tankSpawner.respawnEnemyTank(coordinates, enemyTanks, element);
                }
            }

            enemyMovement3.moveEnemies(enemyTanks.ElementAt(0), gameBorders, gameWalls, player, enemyTanks, timer1);
            enemyMovement1.moveEnemies(enemyTanks.ElementAt(1), gameBorders, gameWalls, player, enemyTanks, timer1);
            enemyMovement2.moveEnemies(enemyTanks.ElementAt(2), gameBorders, gameWalls, player, enemyTanks, timer1);
            enemyMovement.moveEnemies(enemyTanks.ElementAt(3), gameBorders, gameWalls, player, enemyTanks, timer1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            playerLives.Add(life1);
            playerLives.Add(life2);
            playerLives.Add(life3);

            progressBar1.Value = player.health;
            
            int nr = 0;
            BrickWall temp;
            EnemyTank tempTank;
            coordinates = fileReader.readCoordinates(gameWallsCoordinates);
            foreach(Point element in coordinates)
            {
                gameBorders.Controls.Add(temp = new BrickWall("brick" + nr, element));
                gameWalls.Add(temp);
                nr++;
            }

            coordinates.Clear();
            nr = 0;

            coordinates = fileReader.readCoordinates(enemyTankCoordinates);
            foreach (Point element in coordinates)
            {
                gameBorders.Controls.Add(tempTank = new EnemyTank("enemyTank" + nr, element));
                enemyTanks.Add(tempTank);
                nr++;
            }
            gameBorders.Controls.Add(player);
            player.Location = new Point(350, 200);
        }

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    // Confirm user wants to close
        //    switch (MessageBox.Show(this, "Are you sure you want to exit?", "Closing", MessageBoxButtons.YesNo))
        //    {
        //        case DialogResult.No:
        //            e.Cancel = true;
        //            break;
        //        case DialogResult.Yes:
        //            e.Cancel = false;
        //            Application.Exit();
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
}
