using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Tanki2016_v2
{
    class TankSpawner
    {
        CollisionDetecter detecter = new CollisionDetecter();

        public void respawnEnemyTank(List<Point> spawnPoints, List<EnemyTank> enemyTanks, EnemyTank enemyTank)
        {
            int temp;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            while (true)
            {
                temp = random.Next(0, spawnPoints.Count);
                Rectangle tempTank = new Rectangle(spawnPoints.ElementAt(temp), new Size(50, 50));
                if(detecter.detectEnemyCollision(enemyTanks, tempTank))
                {
                    continue;
                }
                else
                {
                    enemyTank.Location = spawnPoints.ElementAt(temp);
                    return;
                }
            }
            
        }

    }
        
    
}
