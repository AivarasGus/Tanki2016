using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tanki2016_v2
{
    class EnemyMovement
    {
        enum Direction
        {
            Right, Left, Up, Down
        };

        private Direction currentState = Direction.Right;
        private static int changeDirection = 3;
        private static int shootingChance = 3;

        Shooter shooter = new Shooter();

        public void moveEnemies(EnemyTank tank, PictureBox gameBorders, List<BrickWall> gameWalls, Player player, List<EnemyTank> enemyTanks, Timer timer1)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            CollisionDetecter detecter = new CollisionDetecter();
            int temp;

            switch (currentState)
            {
                case Direction.Right:
                    if (tank.Location.X + tank.Size.Width + 20 < gameBorders.Bounds.Right 
                        && !detecter.detectCollision(gameWalls, new Rectangle(tank.Location.X + 1, tank.Location.Y, 50, 50), enemyTanks, tank) 
                        && !tank.Bounds.IntersectsWith(new Rectangle(player.Location.X - 1, player.Location.Y, 50, 50)))
                    {
                        //shooting chance
                        if((temp = random.Next(0, 101)) < shootingChance)
                        {
                            Cannon cannon = new Cannon(tank.Location);
                            gameBorders.Controls.Add(cannon);
                            cannon.Location = new Point(tank.Location.X + 51, tank.Location.Y + 20);
                            timer1.Tick += new EventHandler((sender1, e1) => shooter.shootRight(sender1, e1, cannon, gameWalls, enemyTanks, gameBorders, player, true));
                        }
                        if ((temp = random.Next(0, 101)) < changeDirection)
                        {
                            currentState = (Direction)random.Next(0, 4);
                            break;
                        }
                        tank.Image = Properties.Resources.enemy_tank_right;
                        tank.Location = new Point(tank.Location.X + 5, tank.Location.Y);
                        currentState = Direction.Right;
                    }
                    else
                    {
                        currentState = (Direction)random.Next(0, 4);
                    }
                    break;

                case Direction.Left:
                    if (tank.Location.X + 10 > gameBorders.Bounds.Left 
                        && !detecter.detectCollision(gameWalls, new Rectangle(tank.Location.X - 1, tank.Location.Y, 50, 50), enemyTanks, tank) 
                        && !tank.Bounds.IntersectsWith(new Rectangle(player.Location.X + 1, player.Location.Y, 50, 50)))
                    {
                        if ((temp = random.Next(0, 101)) < shootingChance)
                        {
                            Cannon cannon = new Cannon(tank.Location);
                            gameBorders.Controls.Add(cannon);
                            cannon.Location = new Point(tank.Location.X + 51, tank.Location.Y + 20);
                            timer1.Tick += new EventHandler((sender1, e1) => shooter.shootLeft(sender1, e1, cannon, gameWalls, enemyTanks, gameBorders, player, true));
                        }
                        if ((temp = random.Next(0, 101)) < changeDirection)
                        {
                            currentState = (Direction)random.Next(0, 4);
                            break;
                        }
                        tank.Image = Properties.Resources.enemy_tank_left;
                        tank.Location = new Point(tank.Location.X - 5, tank.Location.Y);
                        currentState = Direction.Left;
                    }
                    else
                    {
                        currentState = (Direction)random.Next(0, 4);
                    }
                    break;

                case Direction.Up:
                    if (tank.Location.Y + 75 > gameBorders.Bounds.Top 
                        && !detecter.detectCollision(gameWalls, new Rectangle(tank.Location.X, tank.Location.Y - 1, 50, 50), enemyTanks, tank) 
                        && !tank.Bounds.IntersectsWith(new Rectangle(player.Location.X, player.Location.Y + 1, 50, 50)))
                    {
                        if ((temp = random.Next(0, 101)) < shootingChance)
                        {
                            Cannon cannon = new Cannon(tank.Location);
                            gameBorders.Controls.Add(cannon);
                            cannon.Location = new Point(tank.Location.X + 51, tank.Location.Y + 20);
                            timer1.Tick += new EventHandler((sender1, e1) => shooter.shootUp(sender1, e1, cannon, gameWalls, enemyTanks, gameBorders, player, true));
                        }
                        if ((temp = random.Next(0, 101)) < changeDirection)
                        {
                            currentState = (Direction)random.Next(0, 4);
                            break;
                        }
                        tank.Image = Properties.Resources.enemy_tank_up;
                        tank.Location = new Point(tank.Location.X, tank.Location.Y - 5);
                        currentState = Direction.Up;
                    }
                    else
                    {
                        currentState = (Direction)random.Next(0, 4);
                    }
                    break;

                case Direction.Down:
                    if (tank.Location.Y + tank.Size.Height + 85 < gameBorders.Bounds.Bottom 
                        && !detecter.detectCollision(gameWalls, new Rectangle(tank.Location.X, tank.Location.Y + 1, 50, 50), enemyTanks, tank) 
                        && !tank.Bounds.IntersectsWith(new Rectangle(player.Location.X, player.Location.Y - 1, 50, 50)))
                    {
                        if ((temp = random.Next(0, 101)) < shootingChance)
                        {
                            Cannon cannon = new Cannon(tank.Location);
                            gameBorders.Controls.Add(cannon);
                            cannon.Location = new Point(tank.Location.X + 51, tank.Location.Y + 20);
                            timer1.Tick += new EventHandler((sender1, e1) => shooter.shootDown(sender1, e1, cannon, gameWalls, enemyTanks, gameBorders, player, true));
                        }
                        if ((temp = random.Next(0, 101)) < changeDirection)
                        {
                            currentState = (Direction)random.Next(0, 4);
                            break;
                        }
                        tank.Image = Properties.Resources.enemy_tank_down;
                        tank.Location = new Point(tank.Location.X, tank.Location.Y + 5);
                        currentState = Direction.Down;
                    }
                    else
                    {
                        currentState = (Direction)random.Next(0, 4);
                    }
                    break;

            }
        }
    }
}
