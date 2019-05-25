using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Tanki2016_v2
{
    class GameFileReader
    {
        public List<Point> readCoordinates(string path)
        {
            StreamReader reader = new StreamReader(path);
            List<Point> coordinates = new List<Point>();
            string temporary;
            string[] xAndY = new string[2]; 
            try
            {   
                while ((temporary = reader.ReadLine()) != null)
                {
                    xAndY = temporary.Split(',');
                    coordinates.Add(new Point(int.Parse(xAndY[0]), int.Parse(xAndY[1])));
                }
            }
            catch(FileNotFoundException e)
            {

            }

            return coordinates;
            
        }
    }
}
