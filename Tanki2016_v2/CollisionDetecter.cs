using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tanki2016_v2
{
    class CollisionDetecter
    {
        public bool detectCollision(List<BrickWall> gameWalls, Rectangle nextTankLocation, List<EnemyTank> enemyTanks, EnemyTank enemyTank = null)
        {
            foreach (BrickWall element in gameWalls)
            {
                if (element.Bounds.IntersectsWith(nextTankLocation) || detectEnemyCollision(enemyTanks, nextTankLocation, enemyTank))
                    return true;
            }

            return false;
        }

        public bool detectEnemyCollision(List<EnemyTank> enemyTanks, Rectangle nextTankLocation, EnemyTank enemyTank = null)
        {
            foreach (EnemyTank element in enemyTanks)
            {
                if (element.Equals(enemyTank))
                {
                    continue;
                }
                else
                {
                    if (element.Bounds.IntersectsWith(nextTankLocation))
                    {
                        return true; 
                    }
                }
            }
            return false; 
        }

        public bool detectWallCollisionWithCannon(List<BrickWall> gameWalls, PictureBox cannon)
        {
            foreach (BrickWall element in gameWalls)
            {
                if (element.Bounds.IntersectsWith(cannon.Bounds))
                    return true;
            }

            return false;
        }

        public bool detectEnemyCollisionWithCannon(List<EnemyTank> enemyTanks, Rectangle cannon)
        {
            foreach (EnemyTank element in enemyTanks)
            {
                if (element.Bounds.IntersectsWith(cannon))
                {
                    element.health -= 50;
                    return true; 
                }
            }
            return false; 
        }

        public bool detectPlayerCollisionWithCannon(Player player, Rectangle cannon)
        {
            if (player.Bounds.IntersectsWith(cannon))
            {
                player.health -= 5;
                return true;
            }
            return false; 
        }
    }
}
