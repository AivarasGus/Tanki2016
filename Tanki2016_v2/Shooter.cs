using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tanki2016_v2
{
    class Shooter
    {
        CollisionDetecter detecter = new CollisionDetecter();

        public void shootRight(object sender, EventArgs e, PictureBox cannon, List<BrickWall> gameWalls, List<EnemyTank> enemyTanks, PictureBox gameBorders, Player player, bool isEnemy)
        {
            if (!detecter.detectWallCollisionWithCannon(gameWalls, cannon))
            {
                cannon.Location = new Point(cannon.Location.X + 10, cannon.Location.Y);
                switch (isEnemy)
                {
                    case true:
                        if(detecter.detectPlayerCollisionWithCannon(player, cannon.Bounds))
                        {
                            gameBorders.Controls.Remove(cannon);
                            cannon.Dispose();
                            return;
                        }
                        break;
                    case false:
                        if (detecter.detectEnemyCollisionWithCannon(enemyTanks, cannon.Bounds))
                        {
                            gameBorders.Controls.Remove(cannon);
                            cannon.Dispose();
                            return;
                        }
                        break;
                }
                
            }
            else
            {
                gameBorders.Controls.Remove(cannon);
                cannon.Dispose();
                return;
            }
        }

        public void shootLeft(object sender, EventArgs e, PictureBox cannon, List<BrickWall> gameWalls, List<EnemyTank> enemyTanks, PictureBox gameBorders, Player player, bool isEnemy)
        {
            if (!detecter.detectWallCollisionWithCannon(gameWalls, cannon))
            {
                cannon.Location = new Point(cannon.Location.X - 10, cannon.Location.Y);
                switch (isEnemy)
                {
                    case true:
                        if (detecter.detectPlayerCollisionWithCannon(player, cannon.Bounds))
                        {
                            gameBorders.Controls.Remove(cannon);
                            cannon.Dispose();
                            return;
                        }
                        break;
                    case false:
                        if (detecter.detectEnemyCollisionWithCannon(enemyTanks, cannon.Bounds))
                        {
                            gameBorders.Controls.Remove(cannon);
                            cannon.Dispose();
                            return;
                        }
                        break;
                }
            }
            else
            {
                gameBorders.Controls.Remove(cannon);
                cannon.Dispose();
                return;
            }
        }

        public void shootUp(object sender, EventArgs e, PictureBox cannon, List<BrickWall> gameWalls, List<EnemyTank> enemyTanks, PictureBox gameBorders, Player player, bool isEnemy)
        {
            if (!detecter.detectWallCollisionWithCannon(gameWalls, cannon))
            {
                cannon.Location = new Point(cannon.Location.X, cannon.Location.Y - 10);
                switch (isEnemy)
                {
                    case true:
                        if (detecter.detectPlayerCollisionWithCannon(player, cannon.Bounds))
                        {
                            gameBorders.Controls.Remove(cannon);
                            cannon.Dispose();
                            return;
                        }
                        break;
                    case false:
                        if (detecter.detectEnemyCollisionWithCannon(enemyTanks, cannon.Bounds))
                        {
                            gameBorders.Controls.Remove(cannon);
                            cannon.Dispose();
                            return;
                        }
                        break;
                }
            }
            else
            {
                gameBorders.Controls.Remove(cannon);
                cannon.Dispose();
                return;
            }
        }

        public void shootDown(object sender, EventArgs e, PictureBox cannon, List<BrickWall> gameWalls, List<EnemyTank> enemyTanks, PictureBox gameBorders, Player player, bool isEnemy)
        {
            if (!detecter.detectWallCollisionWithCannon(gameWalls, cannon))
            {
                cannon.Location = new Point(cannon.Location.X, cannon.Location.Y + 10);
                switch (isEnemy)
                {
                    case true:
                        if (detecter.detectPlayerCollisionWithCannon(player, cannon.Bounds))
                        {
                            gameBorders.Controls.Remove(cannon);
                            cannon.Dispose();
                            return;
                        }
                        break;
                    case false:
                        if (detecter.detectEnemyCollisionWithCannon(enemyTanks, cannon.Bounds))
                        {
                            gameBorders.Controls.Remove(cannon);
                            cannon.Dispose();
                            return;
                        }
                        break;
                }
            }
            else
            {
                gameBorders.Controls.Remove(cannon);
                cannon.Dispose();
                return;
            }
        }
    }
}
